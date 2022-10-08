using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShrimpFlourControl.Missions
{
    public class WorkOrder
    {
        /// <summary>
        /// good sequence 的Jobid
        /// </summary>
        public int No { get; set; }
        public int OperactionSequence { get; set; }
        public string OperactionMachine { get; set; }
        

        public MissionStatus OperactionStatus { get; set; } = MissionStatus.Waiting;

    }
}
