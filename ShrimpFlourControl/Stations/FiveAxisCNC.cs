using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShrimpFlourControl.Maps;

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

        public void StartMan()
        {
            
        }
    }
}
