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
            //id0=m1
            //id1=m2
            //id6=m3
            MissionList = new List<Mission>
            {
                new Mission{
                    Id=1,
                    StationRouter=new List<Station>{
                        this.SFC.Stations.Where(s => s.ID == 1).First(),
                        this.SFC.Stations.Where(s => s.ID == 6).First(),
                        this.SFC.Stations.Where(s => s.ID == 0).First(),}
                    ,StationProcessTime=new List<int>(),
                },
                new Mission{
                    Id=2,
                    StationRouter=new List<Station>{
                        this.SFC.Stations.Where(s => s.ID == 0).First(),
                        this.SFC.Stations.Where(s => s.ID == 6).First(),
                        this.SFC.Stations.Where(s => s.ID == 1).First(),}
                },
                new Mission{
                   Id=3,
                    StationRouter=new List<Station>{
                        this.SFC.Stations.Where(s => s.ID == 6).First(),
                        this.SFC.Stations.Where(s => s.ID == 1).First(),
                        this.SFC.Stations.Where(s => s.ID == 0).First(),}
                }
            };
        }
        public Mission GetMissionById(int id)
        {
            return MissionList.Where(a => a.Id == id).FirstOrDefault();
        }
        
        public List<Mission> GetGoodSequenceMission(List<int> GoodSequence)
        {
            return GoodSequence.Select(a => GetMissionById(a)).ToList();
            //List<int> goodSequence = new List<int>() { 2,1,3,1,1,2,3,2,3};
            //OOXX(goodSequence);
        }
        public void RunMissionList(List<int> GoodSequence)
        {
            string finalMsg = "";
            this.MissionListExisted = GetGoodSequenceMission(GoodSequence);
            dataGridView.DataSource = MissionListExisted;
            var stationlist = MissionListExisted.SelectMany(a => a.StationRouter).Distinct().ToList();
            MissionListExisted.ForEach(mission =>
            {
                var station = mission.StationRouter.First();
                stationlist.Where(a => a.ID == station.ID).First().ReservedMissionList.Add(mission);
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
                    if (mission.Status == MissionStatus.Waiting && station.Status == Station.StationStatus.Idle && station.ReservedMissionList.First().Id == mission.Id)
                    {
                        mission.Status = MissionStatus.Processing;
                        //1.三個階段
                        /*
                         * good sequence 轉成任務列表
                         * 任務列表會有mission id 跟
                         */
                        finalMsg += mission.Id + ":" + station.ID + Environment.NewLine;
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
