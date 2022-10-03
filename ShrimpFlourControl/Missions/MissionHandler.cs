using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShrimpFlourControl.Stations;

namespace ShrimpFlourControl.Missions
{
    public class MissionHandler
    {
        public SFCServer SFC;
        public List<Mission> MissionList = new List<Mission>();
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
            var missionList = GetGoodSequenceMission(GoodSequence);
            var stationlist = missionList.SelectMany(a => a.StationRouter).Distinct().ToList();
            missionList.ForEach(mission =>
            {
                var station = mission.StationRouter.First();
                stationlist.Where(a => a.ID == station.ID).First().ReservedMissionList.Add(mission);
                mission.StationRouterBak.Add(station); 
                mission.StationRouter.Remove(station);
            });
            missionList.ForEach(mission =>
            {
                var station = mission.StationRouterBak.First();
                if (mission.Status == MissionStatus.Idle && station.Status == Station.StationStatus.Idle && station.ReservedMissionList.First().Id == mission.Id)
                {
                    var sss = 1;
                }
                else
                {
                    var sss2 = 2;
                }
            });
        }
    }
}
