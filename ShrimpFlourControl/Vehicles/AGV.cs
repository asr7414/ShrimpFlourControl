using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShrimpFlourControl.Maps;

namespace ShrimpFlourControl.Vehicles
{
    public abstract class AGV : IEquatable<AGV>
    {
        #region Enums
        public enum AGVStates : byte
        {
            // Normal States        //0xxx xxxx = normal states
            Idle = 0x00,
            Moving = 0x01,
            Loading = 0x02,
            Unloading = 0x03,

            // Error States         //1xxx xxxx = error states
            Disconnected = 0x80,    //1000 0000
            Error = 0x81,           //1000 0001
        }
        #endregion

        public int ID { get; private protected set; }
        public float X { get; set; } // private protected (為啥)
        public float Y { get; set; } // private protected (為啥)

        public Node CurrentNode { get; set; } // private protected (為啥)

        public AGVStates State { get; private protected set;  }

        public abstract bool LoadWorkPiece();
        public abstract bool UnloadWorkPiece();

        public bool Equals(AGV other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return this.ID == other.ID && this.CurrentNode == other.CurrentNode;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((AGV)obj);
        }

        public static bool operator ==(AGV left, AGV right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(AGV left, AGV right)
        {
            return !Equals(left, right);
        }

        public override int GetHashCode()
        {
            return (this.ID.GetHashCode());
        }

        public override string ToString()
        {
            return $"AGV_{this.ID.ToString("000")}";
        }
    }
}




