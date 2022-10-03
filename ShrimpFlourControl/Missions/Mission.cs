using ShrimpFlourControl.Stations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShrimpFlourControl.Missions
{
    #region Enums
    public enum MissionStatus : int
    {
        Idle = 0,
        Loading = 1,
        Processing = 2,
        Unloading = 3,
        Done = 4,
    }
    #endregion
    public class Mission
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public MissionStatus Status { get; set; } = MissionStatus.Idle;
        public Station CurrentStation { get; set; }
        public Station NextStation { get; set; }
        public List<Station> StationRouter { get; set; }
        public List<Station> StationRouterBak { get; set; } = new List<Station>();
        public List<int> StationProcessTime { get; set; }
    }
}
