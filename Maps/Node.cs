using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShrimpFlourControl.Maps
{
    public class Node
    {
        public int PosX { get; }
        public int PosY { get; }
        public int ID { get; }
        public Node(int id, int x, int y)
        {
            this.ID = id;
            this.PosX = x;
            this.PosY = y;
        }

        public override string ToString()
        {
            return $"Node_{ID.ToString("000")}_{PosX.ToString("000")}_{PosY.ToString("000")}";
        }
    }
}
