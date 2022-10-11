using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShrimpFlourControl.Maps;

namespace ShrimpFlourControl.Stations
{
    public class ThreeAxisCNC : Station
    {
        public ThreeAxisCNC(int id, Node refererNode, int offsetX, int offsetY, char remark) : base(id, refererNode, offsetX, offsetY, StationType.ThreeAxisCNC, remark)
        {

        }
        public bool Connect()
        {
            return true;
        }

        public void LoadWorkPiece()
        {
            this.Status = StationStatus.Loading;
            System.Threading.Thread.Sleep(1000);
        }
        public void StartProcessing(Missions.Mission mission)
        {
            this.Status = StationStatus.Processing;
            System.Threading.Thread.Sleep(mission.Station.PrcoessingTime);
            this.Status = StationStatus.ProcessingDone;
        }

        public void UnloadWorkPiece()
        {
            this.Status = StationStatus.Unloading;
            System.Threading.Thread.Sleep(1000);
            this.Status = StationStatus.Idle;
        }
    }
}
