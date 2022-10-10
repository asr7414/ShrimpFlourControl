using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ShrimpFlourControl.Stations;
using ShrimpFlourControl.Vehicles;

namespace ShrimpFlourControl.Missions
{
    public class MissionHandler
    {
        public SFCServer SFC;
        public List<Mission> MissionList = new List<Mission>();
        public List<Mission> MissionListExisted = new List<Mission>();
        public DataGridView dataGridView;
        public MissionHandler(SFCServer SFC)
        {
            this.SFC = SFC;
            
        }

        /// <summary>
        /// 依照optimalSequence 產生MissionList
        /// </summary>
        /// <param name="optimalSequence"></param>
        /// <returns></returns>
        public List<Mission> GetOptimalSequenceMission(List<int> optimalSequence)
        {
            List<Mission> missions = new List<Mission>();
            int idx = 1;
            optimalSequence.ForEach(orderId =>
            {
                var order = SFC.Orders.Where(o => o.OrderId == orderId).First();
                var ProductOperactionListIndex = missions.Where(a => a.OrderId == orderId).Count();
                var stationId = order.Product.ProductOperactionList[ProductOperactionListIndex].StationId;
                var station = SFC.Stations.Where(a => a.StationId == stationId).FirstOrDefault();
                Mission mission = new Mission
                {
                    MissionId = idx++,
                    OrderId = orderId,
                    Order = order,
                    ProductOperactionNo = ProductOperactionListIndex + 1,
                    StationId = stationId,
                    Station = station
                };
                missions.Add(mission);
            });
            return missions;
            //return GoodSequence.Select(a => GetMissionById(a)).ToList();
            //List<int> goodSequence = new List<int>() { 2,1,3,1,1,2,3,2,3};
            //OOXX(goodSequence);
        }
        public List<Mission> GetMissionList()
        {
            var sss = SFC.Orders.Select(a => a.Product);
            throw new NotImplementedException();
        }
        public List<int> GenerateOptimalSequence()
        {
            //TODO 學生作業, 用SFC.Orders 產生OptimalSequence
            //SFC.Orders
            return new List<int>() { 2, 1, 3, 1, 1, 2, 3, 2, 3 };
        }
        public void RunMissionList(List<int> optimalSequence)
        {
            string finalMsg = "";
            this.MissionListExisted = GetOptimalSequenceMission(optimalSequence);
            
            //dataGridView.DataSource = MissionListExisted;
            var stationlist = MissionListExisted.SelectMany(a => a.StationRouter).Distinct().ToList();
            MissionListExisted.ForEach(mission =>
            {
                var station = mission.StationRouter.First();
                stationlist.Where(a => a.StationId == station.StationId).First().ReservedMissionList.Add(mission);
                mission.StationRouterBak.Add(station); 
                mission.StationRouter.Remove(station);
            });
            new Thread(() =>
            {
                for (int i = 0; i < MissionListExisted.Count; i++)
                {
                    var mission = MissionListExisted[i];
                    if (i == 1)
                    {
                        //break;
                    }
                    //
                    AGVHandler aGVHandler = new AGVHandler(SFC);
                    var station = mission.StationRouterBak.First();
                    #region
                    if (mission.Status == MissionStatus.Waiting && station.Status == Station.StationStatus.Idle && station.ReservedMissionList.First().MissionId == mission.MissionId)
                    {
                        mission.Status = MissionStatus.Processing;
                        //1.三個階段
                        /*
                         * good sequence 轉成任務列表
                         * 任務列表會有mission id 跟
                         */
                        finalMsg += mission.MissionId + ":" + station.StationId + Environment.NewLine;
                        Console.WriteLine(finalMsg);
                        mission.StationRouterBak.Remove(station);
                        var agv = aGVHandler.FindFitnessAGV(station.ReferNode);
                        Thread t = aGVHandler.SendAGVTo(station.ReferNode, agv);
                        t.Start();
                        while (t.IsAlive)
                        {
                        }
                        System.Threading.Thread.Sleep(station.PrcoessingTime);
                        mission.Status = MissionStatus.Finished;
                        var ssss = 1;
                        if (station.ReservedMissionList.Count > 0)
                        {
                            station.ReservedMissionList.RemoveAt(0);
                        }
                    }
                    else
                    {
                        var sss2 = 2;
                    }
                    #endregion

                };
            }).Start();
        }
        public void Do()
        {

        }
    }
}
