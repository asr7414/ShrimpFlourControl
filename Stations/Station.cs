using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShrimpFlourControl.Maps;

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
        #endregion

        public int ID { get; }
        public Node ReferNode { get; }
        public int OffsetX { get; set; }
        public int OffsetY { get; set; }
        public StationType Type { get; }


        protected Station(int id, Node refererNode, int offsetX, int offsetY, StationType type)
        {
            this.ID = id;
            this.ReferNode = refererNode;
            this.OffsetX = offsetX;
            this.OffsetY = offsetY;
            this.Type = type;
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
    }
}
