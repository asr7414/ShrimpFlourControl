using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShrimpFlourControl.Maps;

namespace ShrimpFlourControl.Stations
{
    public class StorageStation : Station
    {
        public StorageStation(int id, Node refererNode, int offsetX, int offsetY) : base(id, refererNode, offsetX, offsetY, StationType.StorageStation)
        {

        }
    }
}
