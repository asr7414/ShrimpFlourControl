using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShrimpFlourControl.Maps;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ShrimpFlourControl.Stations
{
    public class ChargeStation : Station
    {

        public ChargeStation(int id, Node refererNode, int offsetX, int offsetY, char remark) : base(id, refererNode, offsetX, offsetY, StationType.ChargeStation, remark)
        {

        }

    }
}
