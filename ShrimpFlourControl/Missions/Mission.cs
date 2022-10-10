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
        Waiting = 0, // (waiting)
        Processing = 1,                                                                                                                             
        Unloading = 2,
        ProcessingDone = 3,
        Finished = 4,
    }
    #endregion
    public class Mission
    {
        /// <summary>
        /// MissionId
        /// </summary>
        public int MissionId { get; set; }
        /// <summary>
        /// 訂單ID
        /// </summary>
        public int OrderId { get; set; }
        /// <summary>
        /// 該ORDER目前是第幾個工序
        /// </summary>
        public int ProductOperactionNo { get; set; }
        /// <summary>
        /// 機台編號
        /// </summary>
        public int StationId { get; set; }
       
        public Orders.Order Order { get; set; } 
        public Stations.Station Station { get; set; }   

       
        public MissionStatus Status { get; set; } = MissionStatus.Waiting;


        //public Station CurrentStation { get; set; }
        //public Station NextStation { get; set; }
        public List<Station> StationRouter { get; set; }
        public List<Station> StationRouterBak { get; set; } = new List<Station>();
        //public List<Station> StationRouterDone { get; set; } = new List<Station>();
        //public List<int> StationProcessTime { get; set; }
    }
}
