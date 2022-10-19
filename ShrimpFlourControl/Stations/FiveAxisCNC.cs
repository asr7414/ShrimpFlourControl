using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShrimpFlourControl.Maps;
using System.Threading;
namespace ShrimpFlourControl.Stations
{
    public class FiveAxisCNC : Station
    {
        public FiveAxisCNC(int id, Node refererNode, int offsetX, int offsetY, char remark) : base(id, refererNode, offsetX, offsetY, StationType.FiveAxisCNC, remark)
        {

        }
        public bool Connect()
        {
            return true;
        }
        /*  Idle = 0,
            Loading = 1,
            Processing = 2,
            Unloading = 3,
            ProcessingDone = 4
         */
        public void LoadWorkPiece()
        {
            this.Status = StationStatus.Loading;
            System.Threading.Thread.Sleep(1000);
        }


        public void UnloadWorkPiece()
        {
            this.Status = StationStatus.Unloading;
            System.Threading.Thread.Sleep(1000);
            this.Status = StationStatus.Idle;
        }
    }
}
