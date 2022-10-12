using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ShrimpFlourControl.PathPlanner;
using ShrimpFlourControl.Stations;
using ShrimpFlourControl.Vehicles;
using static ShrimpFlourControl.Vehicles.AGV;

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
                    ProductOperaction = order.Product.ProductOperactionList[ProductOperactionListIndex],
                    StationId = stationId,
                    Station = station,
                    PreviousMission = missions.Where(m => m.OrderId == orderId).FirstOrDefault(),
                };
                missions.Add(mission);
            });
            var stations = missions.Select(a => a.Station).Distinct().ToList();
            stations.ForEach(s =>
            {
                s.ReservedMissionList = missions.Where(m => m.StationId == s.StationId).OrderBy(m => m.MissionId).ToList();
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
        public void RunMissionListOld(List<int> optimalSequence)
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
                        Thread t = aGVHandler.SendAGVTo(station.ReferNode, agv, agv.LoadWorkPiece);
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
        public void RunMissionList(List<Mission> missions)
        {
            AGVHandler aGVHandler = new AGVHandler(SFC);
            AStarPlanner PathPlanner = new AStarPlanner(SFC);
            var mission = missions.First();
            //foreach (var mission in missions)
            {
               
                var agv = aGVHandler.FindFitnessAGV(mission.Station.ReferNode);
                Debug.WriteLine(mission.MissionId + "," + agv.AgvId);
                switch(mission.Status)
                {
                    case MissionStatus.Waiting:
                        if (mission.ProductOperactionNo == 1)//第一個工序, 必須要額外多做一個動作, 先去原料倉取料
                        {
                            if (agv != null)
                            {
                                mission.Status = MissionStatus.Processing;
                                agv.State = AGVStates.Moving;//agv狀態有問題, 待處理
                                mission.AssignAGV(agv);
                                var t = aGVHandler.SendAGVTo(mission.Order.LastStation.ReferNode, agv, agv.LoadWorkPiece);
                                t.Start();
                            }
                        }
                        else if (mission.PreviousMission.Status == MissionStatus.Finished)
                        {
                            if (agv != null)
                            {
                                mission.Status = MissionStatus.Processing;
                                mission.AssignAGV(agv);
                                var t = aGVHandler.SendAGVTo(mission.Order.LastStation.ReferNode, agv, agv.LoadWorkPiece);
                                t.Start();
                            }
                        }
                        break;
                    case MissionStatus.Processing:
                        Thread.Sleep(mission.ProductOperaction.OperactionTime);
                        mission.Status = MissionStatus.ProcessingDone;
                        break;
                    case MissionStatus.ProcessingDone:
                        break;
                    case MissionStatus.Finished:
                        break;
                    default:
                        break;
                }
            }
        }
        public void LoadWorkPiece(AGV agv)
        {
            agv.State = AGVStates.Loading;
            //mission.Order.LastStation.Status = Station.StationStatus.Unloading;
            Thread.Sleep(1000);
        }
        public void test()
        {

        }
        public void RunMission()
        {

        }
    }
}
