using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShrimpFlourControl.Maps;

namespace ShrimpFlourControl.Stations
{
    public class WIP : Station
    {
        public WIP(int id, Node refererNode, int offsetX, int offsetY, char remark) : base(id, refererNode, offsetX, offsetY, StationType.WIP, remark)
        {

        }
        public override bool StartProcessing(Missions.Mission mission)
        {
            this.Status = StationStatus.Processing;
            System.Threading.Thread.Sleep(mission.ProductOperaction.OperactionTime * 1000);
            this.Status = StationStatus.ProcessingDone;
            return true;
        }
    }
}
