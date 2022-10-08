using ShrimpFlourControl.Maps;
using ShrimpFlourControl.PathPlanner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ShrimpFlourControl.Vehicles.AGV;

namespace ShrimpFlourControl.Vehicles
{
    public class AGVHandler
    {
        public SFCServer SFC;
        public AGVHandler(SFCServer SFC)
        {
            this.SFC = SFC;
            
        }
        public AGV FindFitnessAGV(Node machineNode)
        {
            AStarPlanner _pathPlanner = new AStarPlanner(SFC);
            var result = this.SFC.AGVs.Where(a => a.State == AGVStates.Idle);
            if (result.Count() == 1)
            {
                return result.First();

            }else if (result.Count() >= 2)
            {
                return result.Select(a => new { agv = a, distinct = GetDistinceFromMachine(a.CurrentNode, machineNode) }).OrderBy(a => a.distinct).First().agv;
            }
            else
            {
                return null;
            }
        }

        public float GetDistinceFromMachine(Node AGVNode, Node MachineNode)
        {
            Random rd = new Random();
            return (float)rd.Next();
        }
    }
}
