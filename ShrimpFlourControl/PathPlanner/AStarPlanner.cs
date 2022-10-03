using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Priority_Queue;
using ShrimpFlourControl.Maps;

namespace ShrimpFlourControl.PathPlanner
{
    public class AStarPlanner
    {
        private static readonly object _pathPlanningLock = new object();
        public class AStarNode : IEquatable<AStarNode>
        {
            public Node RefererMapNode { get; }
            public AStarNode ParentNode { get; set; }
            public float F { get { return this.G + this.H; } }
            public float G { get; set; }
            public float H { get; set; }

            public AStarNode(Node refererNode)
            {
                this.RefererMapNode = refererNode;
                this.ParentNode = null;
                this.G = float.PositiveInfinity;
            }

            public bool Equals(AStarNode other)
            {
                if (ReferenceEquals(null, other)) return false;
                if (ReferenceEquals(this, other)) return true;
                return string.Equals(this.RefererMapNode.ID, other.RefererMapNode.ID);
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                if (obj.GetType() != this.GetType()) return false;
                return Equals((AStarNode)obj);
            }

            public static bool operator ==(AStarNode left, AStarNode right)
            {
                return Equals(left, right);
            }

            public static bool operator !=(AStarNode left, AStarNode right)
            {
                return !Equals(left, right);
            }

            public override int GetHashCode()
            {
                return this.RefererMapNode.ID.GetHashCode();
            }
        }
        public enum HeuristicFormulas
        {
            Manhattan = 0,
            Euclidean,
        }

        public HeuristicFormulas HeuristicFormula { get; private set; }
        public float TurningPenalty { get; set; } = 3;
        private List<Node> _allNodes;
        private List<Path> _allPaths;
        private Dictionary<int, List<Node>> _adjList;
        private AStarNode[] _allAStarNodes;
        private SimplePriorityQueue<AStarNode> _openList;
        private List<AStarNode> _closedList;

        public AStarPlanner(SFCServer sfc)
        {
            _allNodes = sfc.Nodes;
            _allPaths = sfc.Paths;
        }

        private List<Node> GetNeighborNodes(Node node)
        {
            return _adjList[node.ID];
        }

        private void InitializeAllAStarNodes()
        {        
            _allAStarNodes = new AStarNode[_allNodes.Count];
            for (int i = 0; i < _allNodes.Count; i++)
            {
                _allAStarNodes[i] = new AStarNode(_allNodes[i]);
            }

            _adjList = new Dictionary<int, List<Node>>();
            for (int i = 0; i < _allNodes.Count; i++)
            {
                _adjList[_allNodes[i].ID] = new List<Node>();
            }

            foreach (var path in _allPaths)
            {
                var startNodeID = path.StartNode.ID;
                _adjList[startNodeID].Add(path.EndNode);
            }

            foreach (var path in _allPaths)
            {
                if (path.Direction == Path.PathDirection.TwoWay)
                {
                    var endNodeID = path.EndNode.ID;
                    _adjList[endNodeID].Add(path.StartNode);
                }
            }
        }

        public List<Node> FindPath(Node startMapNode, Node goalMapNode, HeuristicFormulas heuristicFormula = HeuristicFormulas.Euclidean)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            InitializeAllAStarNodes();
            List<Node> path = null;
            _openList = new SimplePriorityQueue<AStarNode>();                                   // Initialize open list
            _closedList = new List<AStarNode>();                                                // Initialize empty closed list
            var startNode = _allAStarNodes.FirstOrDefault(node => node.RefererMapNode == startMapNode);
            startNode.H = this.HeuristicFunction(startMapNode, goalMapNode);                    // Initialize start node h = h(startNode)
            startNode.G = 0;                                                                    // Initialize start node g = 0
            _openList.Enqueue(startNode, startNode.F);                                          // Add start node to open list

            AStarNode currentNode = null;
            while (_openList.Count > 0)                                                         // Scan until open list is empty
            {
                currentNode = _openList.Dequeue();                                              // Get node with lowest f in open                 
                                                                                                //Debug.WriteLine($"CurrentNode = {currentNode.RefererMapNode.Name}, {{F,G,H}} = {{{currentNode.F},{currentNode.G},{currentNode.H}}}");
                if (currentNode.RefererMapNode == goalMapNode) break;                           // End if currentNode == goalNode (A* path found!)                                

                var neighborNodes = GetNeighborNodes(currentNode.RefererMapNode);
                // Go thorough all successor nodes
                foreach (var neighborMapNode in neighborNodes)
                {
                    if (neighborMapNode == currentNode.ParentNode?.RefererMapNode) continue;

                    var successorNode = _allAStarNodes.FirstOrDefault(node => node.RefererMapNode == neighborMapNode);
                    var distance = (float)Math.Pow(Math.Pow(currentNode.RefererMapNode.PosX - successorNode.RefererMapNode.PosX, 2) + Math.Pow(currentNode.RefererMapNode.PosY - successorNode.RefererMapNode.PosY, 2), 0.5);
                    var successorCurrentCost = currentNode.G + distance;                       // Set successor current cost = g(currentNode) + w(currentNode, successorNode) 


                    if (_openList.Contains(successorNode))                              // If successorNode is already in open list
                    {
                        if (successorCurrentCost < successorNode.G)                     // If successor current cost is lower than successorNode.G
                        {
                            successorNode.G = successorCurrentCost;                     // Update successorNode.G with new lower cost
                            successorNode.ParentNode = currentNode;                     // Set successorNode's parent node to currentNode
                            _openList.UpdatePriority(successorNode, successorNode.F);   // Update successorNode's priority with newly calculated f
                        }
                    }
                    else if (_closedList.Contains(successorNode))                       // If successorNode is already in closed list
                    {
                        if (successorCurrentCost < successorNode.G)                     // If successor current cost is lower than successorNode.G
                        {
                            successorNode.G = successorCurrentCost;                     // Update successorNode.G with new lower cost                 
                            successorNode.ParentNode = currentNode;                     // Set successorNode's parent node to currentNode
                            _closedList.Remove(successorNode);                          // Remove successor from closed list
                            _openList.Enqueue(successorNode, successorNode.F);          // Put successor node in open list with newly calculated f
                        }
                    }
                    else                                                                // Neighter successorNode is in open list nor closed list
                    {
                        successorNode.H = HeuristicFunction(successorNode.RefererMapNode, goalMapNode);     // Calculate successorNode.H = h(successorNode)
                        successorNode.G = successorCurrentCost;                                             // Set successorNode.G = current successor cost                        
                        successorNode.ParentNode = currentNode;                                             // Set successorNode's parent node to currentNode                         
                        _openList.Enqueue(successorNode, successorNode.F);                                  // Put successor node in open list with newly calculated f
                    }
                    //Debug.WriteLine($"\tSuccessorNode = {successorNode.RefererMapNode.Name}, {{F,G,H}} = {{{successorNode.F},{successorNode.G},{successorNode.H}}}");
                }



                //Debug.WriteLine($"Dequeue {currentNode.RefererMapNode.Name}");
                _closedList.Add(currentNode);                    // Add currentNode to closed list
            }
            if (currentNode.RefererMapNode != goalMapNode)      // All node are closed but goal node is not found (No available path found)
            {
                Debug.WriteLine($"Path Not Found! Took {stopwatch.ElapsedMilliseconds}ms");
                return path;
            }

            int count = 0;
            path = new List<Node>();
            while (currentNode != null)                          // Travel back to generate path
            {
                count++;
                path.Insert(0, currentNode.RefererMapNode);
                //Debug.WriteLine($"Path Node =  {currentNode.RefererMapNode.Name}");
                currentNode = currentNode.ParentNode;
            }
            Debug.WriteLine($"Path Found! Took {stopwatch.ElapsedMilliseconds}ms");
            return path;
        }

        public float Distance(Node startMapNode, Node goalMapNode, HeuristicFormulas heuristicFormula = HeuristicFormulas.Euclidean)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            InitializeAllAStarNodes();
            //List<Node> path = null;
            _openList = new SimplePriorityQueue<AStarNode>();                                   // Initialize open list
            _closedList = new List<AStarNode>();                                                // Initialize empty closed list
            var startNode = _allAStarNodes.FirstOrDefault(node => node.RefererMapNode == startMapNode);
            startNode.H = this.HeuristicFunction(startMapNode, goalMapNode);                    // Initialize start node h = h(startNode)
            startNode.G = 0;                                                                    // Initialize start node g = 0
            _openList.Enqueue(startNode, startNode.F);                                          // Add start node to open list

            AStarNode currentNode = null;
            while (_openList.Count > 0)                                                         // Scan until open list is empty
            {
                currentNode = _openList.Dequeue();                                              // Get node with lowest f in open                 
                                                                                                //Debug.WriteLine($"CurrentNode = {currentNode.RefererMapNode.Name}, {{F,G,H}} = {{{currentNode.F},{currentNode.G},{currentNode.H}}}");
                if (currentNode.RefererMapNode == goalMapNode) break;                           // End if currentNode == goalNode (A* path found!)                                

                var neighborNodes = GetNeighborNodes(currentNode.RefererMapNode);
                // Go thorough all successor nodes
                foreach (var neighborMapNode in neighborNodes)
                {
                    if (neighborMapNode == currentNode.ParentNode?.RefererMapNode) continue;

                    var successorNode = _allAStarNodes.FirstOrDefault(node => node.RefererMapNode == neighborMapNode);
                    var distance = (float)Math.Pow(Math.Pow(currentNode.RefererMapNode.PosX - successorNode.RefererMapNode.PosX, 2) + Math.Pow(currentNode.RefererMapNode.PosY - successorNode.RefererMapNode.PosY, 2), 0.5);
                    var successorCurrentCost = currentNode.G + distance;                       // Set successor current cost = g(currentNode) + w(currentNode, successorNode) 


                    if (_openList.Contains(successorNode))                              // If successorNode is already in open list
                    {
                        if (successorCurrentCost < successorNode.G)                     // If successor current cost is lower than successorNode.G
                        {
                            successorNode.G = successorCurrentCost;                     // Update successorNode.G with new lower cost
                            successorNode.ParentNode = currentNode;                     // Set successorNode's parent node to currentNode
                            _openList.UpdatePriority(successorNode, successorNode.F);   // Update successorNode's priority with newly calculated f
                        }
                    }
                    else if (_closedList.Contains(successorNode))                       // If successorNode is already in closed list
                    {
                        if (successorCurrentCost < successorNode.G)                     // If successor current cost is lower than successorNode.G
                        {
                            successorNode.G = successorCurrentCost;                     // Update successorNode.G with new lower cost                 
                            successorNode.ParentNode = currentNode;                     // Set successorNode's parent node to currentNode
                            _closedList.Remove(successorNode);                          // Remove successor from closed list
                            _openList.Enqueue(successorNode, successorNode.F);          // Put successor node in open list with newly calculated f
                        }
                    }
                    else                                                                // Neighter successorNode is in open list nor closed list
                    {
                        successorNode.H = HeuristicFunction(successorNode.RefererMapNode, goalMapNode);     // Calculate successorNode.H = h(successorNode)
                        successorNode.G = successorCurrentCost;                                             // Set successorNode.G = current successor cost                        
                        successorNode.ParentNode = currentNode;                                             // Set successorNode's parent node to currentNode                         
                        _openList.Enqueue(successorNode, successorNode.F);                                  // Put successor node in open list with newly calculated f
                    }
                    //Debug.WriteLine($"\tSuccessorNode = {successorNode.RefererMapNode.Name}, {{F,G,H}} = {{{successorNode.F},{successorNode.G},{successorNode.H}}}");
                }



                //Debug.WriteLine($"Dequeue {currentNode.RefererMapNode.Name}");
                _closedList.Add(currentNode);                    // Add currentNode to closed list
            }
            if (currentNode.RefererMapNode != goalMapNode)      // All node are closed but goal node is not found (No available path found)
            {
                Debug.WriteLine($"Path Not Found! Took {stopwatch.ElapsedMilliseconds}ms");
                return currentNode.F;
            }

            Debug.WriteLine($"Path Found! Took {stopwatch.ElapsedMilliseconds}ms");
            return currentNode.F;
        }

        private float HeuristicFunction(Node currentNode, Node goalNode)
        {
            float esitmatedCost;
            switch (this.HeuristicFormula)
            {
                case HeuristicFormulas.Manhattan:
                    esitmatedCost = Math.Abs(goalNode.PosX - currentNode.PosX) + Math.Abs(goalNode.PosY - currentNode.PosY);
                    break;
                case HeuristicFormulas.Euclidean:
                    esitmatedCost = (float)Math.Sqrt(Math.Pow(goalNode.PosX - currentNode.PosX, 2) + Math.Pow(goalNode.PosY - currentNode.PosY, 2));
                    break;
                default:
                    throw new Exception("Unknow Heuristic Formula");
            }
            return esitmatedCost;
        }
        private float HeuristicFunctionMulti(List<Node> nodes)
        {
            float result = 0;
            return result;
        }
    }
}
