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
        
        private readonly CancellationTokenSource _cts = new CancellationTokenSource();
        public MissionHandler(SFCServer SFC)
        {
            this.SFC = SFC;
            
            Task.Run(HandleMissions);
            
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
                order.LastStation = SFC.Stations.Where(a => a.StationId == 0).FirstOrDefault();
                var ProductOperactionListIndex = missions.Where(a => a.OrderId == orderId).Count();
                var stationId = order.Product.ProductOperactionList[ProductOperactionListIndex].StationId;
                var station = SFC.Stations.Where(a => a.StationId == stationId).FirstOrDefault();
                Mission mission = new Mission
                {
                    MissionId = idx++,
                    OrderId = orderId,
                    Order = order,
                    //Status = ProductOperactionListIndex == 0 ? MissionStatus.LoadingWorkPiece : MissionStatus.Waiting,
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
        int cnt = 1;
        public void RunMissionList(List<Mission> missions)
        {
            var aGVHandler = new AGVHandler(SFC);
            foreach (var mission in missions)
            {
                var agv = aGVHandler.FindFitnessAGV(mission.Order.LastStation.ReferNode);
                switch (mission.Status)
                {
                    case MissionStatus.Waiting:
                        if (mission.PreviousMission != null && mission.PreviousMission.Status != MissionStatus.Finished)
                        {
                            continue;
                        }
                        if (agv != null)
                        {
                            new Thread(() =>
                            {
                                agv.IsOccupied = true;
                                mission.Status = MissionStatus.Processing;
                                mission.AssignAGV(agv);
                                //if(mission.Station.StationId != mission.Order.LastStation.StationId)
                                //{
                                aGVHandler.SendAGVTo2(mission.Order.LastStation.ReferNode, agv);
                                agv.LoadWorkPiece();
                                //}

                                aGVHandler.SendAGVTo2(mission.Station.ReferNode, agv);
                                agv.UnloadWorkPiece();
                                mission.Order.LastStation = mission.Station;
                                new Thread(() =>
                                {
                                    aGVHandler.SendAGVTo2(agv.HomeNode, agv);
                                    agv.IsOccupied = false;
                                    Debug.WriteLine("target AGV occupied? " + agv.IsOccupied);
                                }).Start();
                                mission.Station.StartProcessing(mission);
                                mission.Status = MissionStatus.ProcessingDone;
                            }).Start();
                        }
                        //else Debug.WriteLine("Cant find a car missionstate wait");
                        break;
                    case MissionStatus.ProcessingDone:
                        //var nextStation = missions.Where(a => a.OrderId == mission.OrderId && a.ProductOperactionNo == mission.ProductOperactionNo + 1).FirstOrDefault()?.Station;
                        if (agv != null)
                        {
                            //if (nextStation == null)
                            //{
                                new Thread(() =>
                                {
                                    agv.IsOccupied = true;
                                    mission.AssignAGV(agv);
                                    aGVHandler.SendAGVTo2(SFC.WipStation.ReferNode, agv);
                                    agv.UnloadWorkPiece();
                                    aGVHandler.SendAGVTo2(agv.HomeNode, agv);
                                    agv.IsOccupied = false;
                                    mission.Status = MissionStatus.Finished;
                                    mission.Order.LastStation = SFC.WipStation;
                                }).Start();
                            //}
                        }
                        else Debug.WriteLine("cant find a car");
                        break;
                    case MissionStatus.Finished:
                        break;
                    default:
                        break;
                }
                Thread.Sleep(10);
            }
            //if (cnt <=250)
            {
                cnt++;
                Debug.WriteLine("count = " + cnt);
                Debug.WriteLine("mission len = " + missions.Count);
                RunMissionList(missions.Where(m => m.Status != MissionStatus.Finished).ToList());
            }
        }
        private void HandleMissions()
        { 
            
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
