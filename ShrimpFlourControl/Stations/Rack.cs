using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ShrimpFlourControl.Maps;

namespace ShrimpFlourControl.Stations
{
    public class Rack: Station
    {

        public Rack(int id, Node refererNode, int offsetX, int offsetY, char remark) : base(id, refererNode, offsetX, offsetY, StationType.Rack, remark)
        {

        }
        public void LoadWorkPiece()
        {
            this.Status = StationStatus.Loading;
            Thread.Sleep(1000);
            this.Status = StationStatus.Idle;
        }
        public void UnloadWorkPiece()
        {
            this.Status = StationStatus.Unloading;
            System.Threading.Thread.Sleep(1000);
            this.Status = StationStatus.Idle;
        }
    }
}
