using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ShrimpFlourControl.Maps;

namespace ShrimpFlourControl.Stations
{
    public class StorageStation : Station
    {
        public StorageStation(int id, Node refererNode, int offsetX, int offsetY, char remark) : base(id, refererNode, offsetX, offsetY, StationType.StorageStation, remark)
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
