using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShrimpFlourControl.Maps;
using ShrimpFlourControl.Missions;

namespace ShrimpFlourControl.Stations
{
    public abstract class Station
    {
        #region Enums
        public enum StationType : int
        {
            None = 0,
            FiveAxisCNC,
            ThreeAxisCNC,
            WIP,
            StorageStation,
            Rack,
            ChargeStation,
        }
        public enum StationStatus
        {
            Idle = 0,
            Loading = 1,
            Processing = 2,
            Unloading = 3,
            ProcessingDone = 4
        }
        #endregion

        public int StationId { get; }
        public Node ReferNode { get; }
        public int OffsetX { get; set; }
        public int OffsetY { get; set; }
        public StationType Type { get; }
        public StationStatus Status { get; } = StationStatus.Idle;
        public int PrcoessingTime { get; set; }
        public char Remark { get; set; }
        protected Station(int id, Node refererNode, int offsetX, int offsetY, StationType type, char remark)
        {
            this.StationId = id;
            this.ReferNode = refererNode;
            this.OffsetX = offsetX;
            this.OffsetY = offsetY;
            this.Type = type;
            this.Remark = remark;
        }

        public Point GetStationSize()
        {
            Point pt = new Point();
            switch (this.Type)
            {
                case StationType.FiveAxisCNC:
                    pt.X = 84;
                    pt.Y = 84;
                    break;
                case StationType.ThreeAxisCNC:
                    pt.X = 72;
                    pt.Y = 72;
                    break;
                case StationType.StorageStation:
                case StationType.Rack:
                    pt.X = 64;
                    pt.Y = 64;
                    break;
                case StationType.WIP:
                case StationType.ChargeStation:
                default:
                    pt.X = 32;
                    pt.Y = 32;
                    break;
            }

            return pt;
        }
        public List<Mission> ReservedMissionList { get; set; } = new List<Mission>();
    }
}
