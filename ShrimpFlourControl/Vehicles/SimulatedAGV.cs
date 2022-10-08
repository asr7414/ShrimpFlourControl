using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ShrimpFlourControl.Maps;

namespace ShrimpFlourControl.Vehicles
{
    public class SimulatedAGV : AGV
    {
        private readonly CancellationTokenSource _cts;
        private List<Node> _route;
        private const float _speedFactor = 5.0f;
        public SimulatedAGV(int id, Node currentNode)
        {
            this.AgvId = id;
            this.CurrentNode = currentNode;
            this.X = currentNode.PosX;
            this.Y = currentNode.PosY;
            this.State = AGVStates.Idle;
            _route = new List<Node>();
            _cts = new CancellationTokenSource();
            Task.Run(AGVSimulation);
        }
        public void Move(List<Node> route)
        {
            if (this.State != AGVStates.Idle && route.First() == this.CurrentNode)
            {                
                _route = route;
                this.State = AGVStates.Moving;
            }
        }
        public override bool LoadWorkPiece()
        {
            if (this.State != AGVStates.Idle)
            {

            }
            return true;
        }
        public override bool UnloadWorkPiece()
        {
            if (this.State != AGVStates.Idle)
            {

            }
            return true;
        }
        public void AGVSimulation()
        {
            while (!_cts.Token.IsCancellationRequested)
            {
                switch (this.State)
                {
                    case AGVStates.Idle:
                        break;
                    case AGVStates.Moving:
                        var nextNode = _route?.FirstOrDefault();
                        if (nextNode == null)
                        {
                            this.State = AGVStates.Idle;
                            break;  
                        }
                        if(nextNode == this.CurrentNode)
                        {
                            _route.RemoveAt(0);
                            break;
                        }

                        break;
                    case AGVStates.Loading:
                        break;
                    case AGVStates.Unloading:
                        break;
                    case AGVStates.Error:
                        throw new ApplicationException($"{this.ToString()}Error!");                        
                }
            }
        }

    }
}

