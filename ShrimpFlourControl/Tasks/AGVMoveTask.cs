using ShrimpFlourControl.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShrimpFlourControl.Tasks
{
    public class AGVMoveTask : AGVTask
    {
        public enum TaskStatus
        {
            Initialzied,
            AssigningPath,
            NoAvailablePathFound,
            Arrived,
        }
        private int _lastDequeuedNodeIndex = -1;
        public Node Destination { get; private set; }
        public List<Node> FullPath { get; private set; }
        public Queue<Node> RemainingPath { get; private set; }
        public TaskStatus Status { get; private set; }
        public AGVMoveTask(AGVTaskHandler handler, Node destination) : base(handler)
        {
            this.Destination = destination;
            this.Status = TaskStatus.Initialzied;
        }
        public override void Execute()
        {
            //bool pathNotFound = false;
            lock (_agvTaskLock)
            {
                //var vcs = AssignedAGV.Handler.VCS;
                //var AGVCurrentNode = this.AssignedAGV.CurrentNode;
                //switch (this.Status)
                //{
                //    case TaskStatus.Initialzied:
                //        if (this.Destination == AGVCurrentNode)
                //        {
                //            this.Status = TaskStatus.Arrived;
                //            this.Finished = true;
                //            this.FinishTimeStamp = DateTimeOffset.Now.ToUnixTimeSeconds();
                //            break;
                //        }
                //        this.FullPath = vcs.PathPlanner.FindPath(AGVCurrentNode, this.Destination, this.AssignedAGV.BoundRack != null, this.AssignedAGV.BoundRack == null ? 0 : 1);
                //        if (this.FullPath != null)
                //        {
                //            for (int i = 0; i < FullPath.Count; i++)
                //            {
                //                var node = this.FullPath[i];
                //                if (i == 0)
                //                {
                //                    if (vcs.AGVNodeQueue[node.Location.Y, node.Location.X].FirstOrDefault() != this.AssignedAGV)
                //                    {
                //                        vcs.AGVNodeQueue[node.Location.Y, node.Location.X].AddFirst(this.AssignedAGV);
                //                    }
                //                }
                //                else
                //                {
                //                    vcs.AGVNodeQueue[node.Location.Y, node.Location.X].AddLast(this.AssignedAGV);
                //                }
                //            }
                //            this.RemainingPath = new Queue<Node>(this.FullPath);
                //            this.AssignedAGV.StartNewPath(new List<Node>() { RemainingPath.Dequeue() });
                //            vcs.OccupancyGrid[Destination.Location.Y, Destination.Location.X] |= this.AssignedAGV.BoundRack == null ? (byte)0x01 : (byte)0x03;
                //            vcs.OccupancyGrid[AGVCurrentNode.Location.Y, AGVCurrentNode.Location.X] &= this.AssignedAGV.BoundRack == null ? (byte)0xFE : (byte)0xFC;

                //            // Poor performance, must impove                   
                //            foreach (var agv in vcs.AGVHandler.AGVList)
                //            {
                //                if (agv.TaskHandler.CurrentTask == null) continue;
                //                if (!(agv.TaskHandler.CurrentTask is AGVMoveTask)) continue;
                //                if (((AGVMoveTask)agv.TaskHandler.CurrentTask).Destination == AGVCurrentNode)
                //                {
                //                    vcs.OccupancyGrid[AGVCurrentNode.Location.Y, AGVCurrentNode.Location.X] |= agv.BoundRack == null ? (byte)0x01 : (byte)0x03;
                //                }
                //            }
                //            this.Status = TaskStatus.AssigningPath;
                //        }
                //        else
                //        {
                //            //pathNotFound = true;
                //            System.Diagnostics.Debug.WriteLine($"{this.AssignedAGV.Name} path not found");
                //            //throw new ApplicationException("No path found!");
                //        }
                //        break;
                //    case TaskStatus.AssigningPath:

                //        if (this.RemainingPath.Count > 0)
                //        {
                //            int nextGoalIndex = 0;
                //            var nextGoalNode = this.RemainingPath.ElementAt(nextGoalIndex);
                //            // Find next node that allows AGV wainting on
                //            while (nextGoalNode.DisallowWaitingOnNode == true)
                //            {
                //                if (nextGoalIndex >= this.RemainingPath.Count - 1)
                //                {
                //                    break;
                //                }
                //                nextGoalIndex++;
                //                nextGoalNode = this.RemainingPath.ElementAt(nextGoalIndex);
                //            }

                //            int testIndex = 0;
                //            var testNode = this.RemainingPath.ElementAt(testIndex);
                //            while (true)
                //            {
                //                bool testFlag = false;
                //                var testAGVNodeQueue = vcs.AGVNodeQueue[testNode.Location.Y, testNode.Location.X];
                //                if (this.AssignedAGV.BoundRack == null)
                //                {
                //                    if (testAGVNodeQueue.FirstOrDefault() == this.AssignedAGV)
                //                    {
                //                        testFlag = true;
                //                    }
                //                    else if ((vcs.OccupancyGrid[testNode.Location.Y, testNode.Location.X] & 0x02) > 0)
                //                    {
                //                        var firstAGVWithoutRack = testAGVNodeQueue.FirstOrDefault(agv => agv.BoundRack == null);
                //                        if (firstAGVWithoutRack == this.AssignedAGV)
                //                        {
                //                            testFlag = true;
                //                            testAGVNodeQueue.Remove(firstAGVWithoutRack);
                //                            testAGVNodeQueue.AddFirst(firstAGVWithoutRack);
                //                        }
                //                    }
                //                }
                //                else
                //                {
                //                    // Slow but works, could be optimized in the future.
                //                    if (testAGVNodeQueue.FirstOrDefault() == this.AssignedAGV && vcs.RackList.FirstOrDefault(rack => rack.CurrentNode == testNode) == null)
                //                    {
                //                        testFlag = true;
                //                    }
                //                }
                //                if (testFlag == false)
                //                {
                //                    testIndex = -1;
                //                    break;
                //                }
                //                if (testIndex + 1 <= nextGoalIndex)
                //                {
                //                    testIndex++;
                //                    testNode = this.RemainingPath.ElementAt(testIndex);
                //                }
                //                else
                //                {
                //                    break;
                //                }
                //            }

                //            if (testIndex == nextGoalIndex)
                //            {
                //                for (int i = 0; i <= nextGoalIndex; i++)
                //                {
                //                    this.AssignedAGV.AddNodeToPath(this.RemainingPath.Dequeue());
                //                }
                //            }

                //            if (this.RemainingPath.Count == 0) this.AssignedAGV.EndPath();
                //        }


                //        var currentIndex = this.FullPath.FindIndex(node => node == AGVCurrentNode);
                //        for (int i = _lastDequeuedNodeIndex + 1; i < currentIndex; i++)
                //        {
                //            var passedNode = this.FullPath[i];
                //            var targetAGVNodeQueue = vcs.AGVNodeQueue[passedNode.Location.Y, passedNode.Location.X];
                //            if (targetAGVNodeQueue.Count > 0)
                //            {
                //                if (targetAGVNodeQueue.First() == this.AssignedAGV)
                //                {
                //                    targetAGVNodeQueue.RemoveFirst();
                //                    _lastDequeuedNodeIndex = i;
                //                }
                //                else
                //                {
                //                    System.Diagnostics.Debug.WriteLine($"!!!!!!{this.AssignedAGV.Name} error!!!!!!!! first is {targetAGVNodeQueue.First().Name} at {passedNode.Name}");
                //                }
                //            }
                //        }

                //        if (AGVCurrentNode == this.Destination)
                //        {
                //            //vcsServer.AGVNodeQueue[this.Destination.Location.Y, this.Destination.Location.X].RemoveFirst();
                //            vcs.OccupancyGrid[Destination.Location.Y, Destination.Location.X] |= this.AssignedAGV.BoundRack == null ? (byte)0x01 : (byte)0x03;
                //            this.Finished = true;
                //            this.FinishTimeStamp = DateTimeOffset.Now.ToUnixTimeSeconds();
                //        }
                //        break;
                //}
            }

        }

    }
}
