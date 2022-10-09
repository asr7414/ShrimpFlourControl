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

        public void StartMan()
        {

        }
    }
}
