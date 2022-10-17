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
using ShrimpFlourControl.Missions;
using ShrimpFlourControl.Orders;
using ShrimpFlourControl.Products;

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
        public Station MaterialStation { get { return Stations.Where(s => s.StationId == 0).FirstOrDefault(); } }
        public Station FinishedStation { get { return Stations.Where(s => s.StationId == 6).FirstOrDefault(); } }
        public Station WipStation { get { return Stations.Where(s => s.StationId == 4).FirstOrDefault(); } }
        public List<Mission> Missions { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();
        public List<Product> Products { get; set; }
        public List<ProductOperaction> ProductOperactions { get; set; }
        public Node SelectedNode { get; set; }
        public Node SelectedPathNode1 { get; set; }
        public Node SelectedPathNode2 { get; set; }
        public Path SelectedPath { get; set; }
        public Station SelectedStation { get; set; }
        public AGV SelectedAGV { get; set; }

        public bool SelectState = false;


        public SFCServer()
        {
            _dataBase = new Database();
            _pathPlanner = new AStarPlanner(this);
            this.Nodes = new List<Node>();
            this.Paths = new List<Path>();
            this.AGVs = new List<AGV>();
            this.Stations = new List<Station>();
            this.Products = new List<Product>();
            this.ProductOperactions = new List<ProductOperaction>();
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
                //Missions = _dataBase.GetAllMissions();
                Products = _dataBase.GetAllProducts();
                ProductOperactions = _dataBase.GetAllProductOperactions();
                Products.ForEach(p => p.ProductOperactionList = ProductOperactions.Where(po => po.ProductID == p.ProductId).ToList());
            }

            return result;
        }

        public bool SaveToDatabase()
        {
            int result = 0;
            result += _dataBase.SaveAllNodes(Nodes) ? 1 : 0;
            result += _dataBase.SaveAllAGVs(AGVs) ? 1 : 0;
            result += _dataBase.SaveAllPaths(Paths) ? 1 : 0;
            result += _dataBase.SaveAllStations(Stations) ? 1 : 0;
            if (result != 4)
            {
                return false;
                //MessageBox.Show("Saved to database", "warnning", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else return true;
        }

        public bool ClearAllTables()
        {
            var result = _dataBase.ClearAllMDFKTables();
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
