using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShrimpFlourControl.Communications;
using ShrimpFlourControl.Maps;
using ShrimpFlourControl.Stations;
using ShrimpFlourControl.Vehicles;
using ShrimpFlourControl.PathPlanner;

namespace ShrimpFlourControl
{
    public class SFCServer
    {
        private readonly Database _dataBase;

        private AStarPlanner _pathPlanner;

        public List<Node> Nodes { get; private set; }
        public List<Path> Paths { get; private set; }
        public List<AGV> AGVs { get; private set; }
        public List<Station> Stations { get; private set; }
        public Node SelectedNode { get; set; }
        public Node SelectedPathNode1 { get; set; }
        public Node SelectedPathNode2 { get; set; }
        public Path SelectedPath { get; set; }
        public Station SelectedStation { get; set; }
        public AGV SelectedAGV { get; set; }


        public SFCServer()
        {
            _dataBase = new Database();
            _pathPlanner = new AStarPlanner(this);
            this.Nodes = new List<Node>();
            this.Paths = new List<Path>();
            this.AGVs = new List<AGV>();
            this.Stations = new List<Station>();
        }

        public bool ConnectToDatabase()
        {
            if (_dataBase.IsConnected) return true;
            var result = _dataBase.Connect();

            if (result)
            {
                Nodes = _dataBase.GetAllNodes();
                AGVs = _dataBase.GetAllAGVs(Nodes);
                Paths = _dataBase.GetAllPaths(Nodes);
                Stations = _dataBase.GetAllStations(Nodes);
            }

            return result;
        }

        #region Debug Fucntions
        public void DebugPrint(string msg)
        {
           System.Diagnostics.Debug.WriteLine($"{DateTime.Now.ToString("HH:mm:ss")} -> {msg}");
        }

        #endregion

    }
}
