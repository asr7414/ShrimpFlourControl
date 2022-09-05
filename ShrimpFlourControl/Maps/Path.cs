using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShrimpFlourControl.Maps
{
    public class Path
    {
        #region Enums
        public enum PathType : int
        {
            Line = 0,
            Curve90 = 1,
            CurveAny = 2,
        }

        /// <summary>
        /// This is Path Direction Enumeration.
        /// </summary>
        public enum PathDirection : int
        {
            TwoWay = 0,
            OneWay = 1,
        }

        #endregion


        public int ID { get; }

        public PathType Type { get; }
        public Node StartNode { get; }     ///StartNode
        public Node EndNode { get; }       ///EndNode

        public int CornerPosX { get; }
        public int CornerPosY { get; }
        public int Radius { get; }
        public PathDirection Direction { get; }           ///

        public Path(int id, Node startNode, Node endNode, PathType type = PathType.Line, int cornerPosX = 0, int cornerPosY = 0, int radius = 0, PathDirection direction = PathDirection.TwoWay)
        {
            this.ID = id;
            this.StartNode = startNode;
            this.EndNode = endNode;
            this.Type = type;
            this.CornerPosX = cornerPosX;
            this.CornerPosY = cornerPosY;
            this.Radius = radius;
            this.Direction = direction;
        }
    }
}
