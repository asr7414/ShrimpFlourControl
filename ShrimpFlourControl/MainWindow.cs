using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using ShrimpFlourControl.Visualizations;
using ShrimpFlourControl.Communications;
using ShrimpFlourControl.Vehicles;
using ShrimpFlourControl.Stations;
using ShrimpFlourControl.Missions;
using ShrimpFlourControl.Orders;
using ShrimpFlourControl.Maps;
using static ShrimpFlourControl.PathPlanner.AStarPlanner;
using static ShrimpFlourControl.Stations.Station;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using System.Numerics;
using System.Threading;


namespace ShrimpFlourControl
{
    public partial class MainWindow : Form
    {
        private readonly MapDrawer _mapDrawer;
        public SFCServer SFC { get; }
        public AGVHandler AGVHandler;
        private readonly Database _dataBase;
        private EditMode editMode;
        private Station.StationType stationType;
        public List<int> goodSequence = new List<int>() { 2, 1, 3, 1, 1, 2, 3, 2, 3 };
        public enum EditMode
        {
            AddCar,
            AddStation,
            SelectMode,
            DeleteMode,
            MoveCar,
            Node,
            DrawLine,
            DrawCurve90,
            DrawCurveAny,
            PathSimulation,
        }

        public MainWindow()
        {
            InitializeComponent();
            InitialListView();
            this.SFC = new SFCServer();
            _mapDrawer = new MapDrawer(this.SFC);
            mapRefreshTimer.Enabled = true;
            //var fiveAxis = new FiveAxisCNC(123, new Maps.Node(12, 1, 1), 10, 10);
        }


        #region ToolStrip Menu Item Click Events
        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = this.SFC.ConnectToDatabase();
            if (result)
            {
                ShowInfo("Connected to database!");       
            }
            else
            {
                ShowError("Dailed to connect to database!");
            }
        }

        private void open_file_from_dbToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = this.SFC.ConnectToDatabase();
            if (result)
            {
                ShowInfo("Connected to database!");
            }
            else
            {
                ShowError("Dailed to connect to database!");
            }
        }

        private void save_to_dbToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = this.SFC.SaveToDatabase();
            if (result)
            {
                ShowInfo("Save to database!");
            }
            else
            {
                ShowError("Fail to save to database!");
            }
        }

        private void clear_dbToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = this.SFC.ClearAllTables();
            if (result)
            {
                ShowInfo("Save to database!");
            }
            else
            {
                ShowError("Fail to save to database!");
            }
        }

        private void draw_gridtoolStripButton_Click(object sender, EventArgs e)
        {
            _mapDrawer.DrawGridMap();
            draw_gridtoolStripButton.Enabled = false;
        }

        #endregion

        #region MapViewer Callbacks
        private void pictureBox_mapViewer_MouseDown(object sender, MouseEventArgs e)
        {
            //switch (EditMode)
            //{

            //}
            //if (e.Button == MouseButtons.Left)
            //{
            //    var nearestNode = _mapDrawer.GetNode(e.Location);
            //    switch (editMode)
            //    {
            //        case EditMode.Node:
            //            int newNodeID = 0;
            //            if (SFC.Nodes.Count != 0)
            //            {
            //                newNodeID = SFC.Nodes.Last().ID + 1;
            //            }
            //            NodeLocation = e.Location;
            //            if (NodeLocation.X % initialgridsize != 0 || NodeLocation.Y % initialgridsize != 0)
            //            {
            //                var nearpointx = NodeLocation.X % initialgridsize;
            //                var nearpointy = NodeLocation.Y % initialgridsize;
            //                NodeLocation.X -= nearpointx;
            //                NodeLocation.Y -= nearpointy;
            //            }
            //            var newNode = new Node(newNodeID, NodeLocation.X, NodeLocation.Y);
            //            SFC.Nodes.Add(newNode);
            //            Debug.WriteLine("new node id " + newNodeID + "node x " + newNode.PosX + "node y " + newNode.PosY);
            //            break;

            //        case EditMode.AddCar:
            //            int newAGVID = 0;
            //            if (SFC.AGVs.Count != 0)
            //            {
            //                newAGVID = SFC.AGVs.Last().AgvId + 1;
            //            }
            //            if (nearestNode != null)
            //            {
            //                Debug.WriteLine($"nearest node: {nearestNode.ID}");
            //                var newAGV = new SimulatedAGV(newAGVID, nearestNode);
            //                SFC.AGVs.Add(newAGV);
            //            }
            //            break;

            //        case EditMode.AddStation:
            //            int newStationID = 0;
            //            if (SFC.Stations.Count != 0)
            //            {
            //                newStationID = SFC.Stations.Last().StationId + 1;
            //            }
            //            if (nearestNode != null)
            //            {
            //                var newStation = new Station(newStationID, stationtype, nearestNode, e.Location.X - nearestNode.PosX, e.Location.Y - nearestNode.PosY);
            //                newStation.size_length = sta_length;
            //                newStation.size_width = sta_width;
            //                SFC.Stations.Add(newStation);
            //            }
            //            else
            //            {
            //                MessageBox.Show("No Node Nearby", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            }
            //            break;

            //        case EditMode.SelectMode:
            //            SFC.SelectedStation = _mapDrawer.GetStation(e.Location);
            //            SFC.SelectedAGV = _mapDrawer.GetAGV(e.Location);
            //            SFC.SelectedNode = _mapDrawer.GetNode(e.Location);
            //            SFC.SelectState = true;

            //            break;

            //        case EditMode.DeleteMode:
            //            if (SFC.SelectState == true)
            //            {
            //                SFC.SelectedAGV = _mapDrawer.GetAGV(e.Location);
            //                if (SFC.SelectedAGV != null)
            //                {
            //                    SFC.AGVs.Remove(SFC.SelectedAGV);
            //                    SFC.SelectedAGV = null;
            //                    SFC.SelectState = false;
            //                }

            //                SFC.SelectedStation = _mapDrawer.GetStation(e.Location);
            //                if (SFC.SelectedStation != null)
            //                {
            //                    SFC.Stations.Remove(SFC.SelectedStation);
            //                    SFC.SelectedStation = null;
            //                    SFC.SelectState = false;
            //                }

            //                //selectedLine = GetLineByMousePosition(e.Location);
            //                //if (selectedLine != null)
            //                //{
            //                //    Lines.Remove(selectedLine);
            //                //    selectedLine = null;
            //                //    selectState = false;
            //                //}
            //                SFC.SelectedNode = _mapDrawer.GetNode(e.Location);
            //                if (SFC.SelectedNode != null)
            //                {
            //                    SFC.Nodes.Remove(SFC.SelectedNode);
            //                    SFC.SelectedNode = null;
            //                    SFC.SelectState = false;
            //                }
            //            }
            //            break;

            //        case EditMode.DrawLine:
            //            int newPathID = 0;
            //            int count = 0;
            //            Node StartNode, EndNode;
            //            if (count == 0)
            //            {
            //                double nowx = e.Location.X;
            //                double nowy = e.Location.Y;
            //                double dis, mindis = double.PositiveInfinity;
            //                for (int i = 0; i < SFC.Nodes.Count; i++)
            //                {
            //                    dis = Math.Pow(Math.Pow(nowx - SFC.Nodes[i].PosX, 2) + Math.Pow(nowy - SFC.Nodes[i].PosY, 2), 0.5);
            //                    if (dis < mindis && dis < 30)
            //                    {
            //                        mindis = dis;
            //                        StartNode = SFC.Nodes[i];
            //                    }
            //                }
            //                count++;
            //            }
            //            else if (count == 1)
            //            {
            //                double nowx = e.Location.X;
            //                double nowy = e.Location.Y;
            //                double dis, mindis = double.PositiveInfinity;
            //                for (int i = 0; i < SFC.Nodes.Count; i++)
            //                {
            //                    dis = Math.Pow(Math.Pow(nowx - SFC.Nodes[i].PosX, 2) + Math.Pow(nowy - SFC.Nodes[i].PosY, 2), 0.5);
            //                    if (dis < mindis && dis < 30)
            //                    {
            //                        mindis = dis;
            //                        EndNode = SFC.Nodes[i];
            //                    }
            //                }
            //                count++;
            //            }
            //            if (count == 2)
            //            {
            //                if (SFC.Paths.Count != 0)
            //                {
            //                    newPathID = SFC.Paths.Last().ID + 1;
            //                }
            //                if (StartNode != EndNode)
            //                {
            //                    var newPath = new Path(newPathID, StartNode, EndNode);
            //                    SFC.Paths.Add(newPath);
            //                }
            //                count = 0;
            //            }
            //            break;
            //        case EditMode.DrawCurveAny: ///新增弧線                         
            //            if (_curveNode1 == null)
            //            {
            //                if (nearestNode != null)
            //                {
            //                    _curveNode1 = nearestNode;
            //                }
            //            }
            //            else if (_curveCornerPoint == new Point(-1, -1))
            //            {
            //                _curveCornerPoint = e.Location;
            //            }
            //            else if (_curveNode2 == null)
            //            {
            //                if (nearestNode != null)
            //                {
            //                    _curveNode2 = nearestNode;
            //                    var newID = SFC.Paths.Count > 0 ? SFC.Paths.Last().ID + 1 : 0;
            //                    Paths.Add(new Path(newID, _curveNode1, _curveNode2, Path.PathType.CurveAny, _curveCornerPoint.X, _curveCornerPoint.Y, 30));
            //                    _curveNode1 = null;
            //                    _curveNode2 = null;
            //                    _curveCornerPoint = new Point(-1, -1);
            //                }
            //            }
            //            break;
            //        case EditMode.DrawCurve90:
            //            if (_curveNode1 == null)
            //            {
            //                if (nearestNode != null)
            //                {
            //                    _curveNode1 = nearestNode;
            //                }
            //            }
            //            else if (_curveCornerPoint == new Point(-1, -1))
            //            {
            //                _curveCornerPoint = e.Location;
            //            }
            //            else if (_curveNode2 == null)
            //            {
            //                if (nearestNode != null)
            //                {
            //                    _curveNode2 = nearestNode;

            //                    Vector2 v1c = new Vector2(_curveCornerPoint.X - _curveNode1.PosX, _curveCornerPoint.Y - _curveNode1.PosY);
            //                    Vector2 v12 = new Vector2(_curveNode2.PosX - _curveNode1.PosX, _curveNode2.PosY - _curveNode1.PosY);
            //                    var v1c12Cross = Vector3.Cross(new Vector3(v1c, 0), new Vector3(v12, 0));
            //                    var quadrantcheck = v12.X * v12.Y;
            //                    Debug.WriteLine(v12);
            //                    Debug.WriteLine(quadrantcheck);
            //                    Debug.WriteLine(v1c12Cross);
            //                    if (quadrantcheck < 0) ///v12 一三象限
            //                    {
            //                        if (v1c12Cross.Z > 0)
            //                        {
            //                            _curveCornerPoint = new Point(_curveNode1.PosX, _curveNode2.PosY);
            //                        }
            //                        else
            //                        {
            //                            _curveCornerPoint = new Point(_curveNode2.PosX, _curveNode1.PosY);
            //                        }
            //                    }
            //                    else if (quadrantcheck > 0) ///二四象限
            //                    {
            //                        if (v1c12Cross.Z < 0)
            //                        {
            //                            _curveCornerPoint = new Point(_curveNode1.PosX, _curveNode2.PosY);
            //                        }
            //                        else
            //                        {
            //                            _curveCornerPoint = new Point(_curveNode2.PosX, _curveNode1.PosY);
            //                        }

            //                    }
            //                    else
            //                    {
            //                        MessageBox.Show("路徑水平或垂直，不須直角彎", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                    }

            //                    var newID = SFC.Paths.Count > 0 ? Paths.Last().ID + 1 : 0;
            //                    SFC.Paths.Add(new Path(newID, _curveNode1, _curveNode2, Path.PathType.Curve90, _curveCornerPoint.X, _curveCornerPoint.Y, 30));
            //                    _curveNode1 = null;
            //                    _curveNode2 = null;
            //                    _curveCornerPoint = new Point(-1, -1);
            //                }
            //            }
            //            break;
            //        case EditMode.PathSimulation:
            //            break;
            //    }
            //}
            //SFC.SelectedStation = _mapDrawer.GetStation(e.Location);
            //SFC.SelectedAGV = _mapDrawer.GetAGV(e.Location);
            //SFC.SelectedNode = _mapDrawer.GetNode(e.Location);
        }
        #endregion

        #region Timer Callbacks
        private void mapRefreshTimer_Tick(object sender, EventArgs e)
        {
            this.pictureBox_mapViewer.Image = _mapDrawer.Render(this.pictureBox_mapViewer.Width, this.pictureBox_mapViewer.Height);
        }
        #endregion


        #region Show Message Box
        private void ShowInfo(string msg)
        {
            MessageBox.Show(msg, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);      
            // Log here.
        }
        private void ShowError( string msg)
        {
            MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            // Log here.
        }









        #endregion

        #region 模式設定
        private void selecttoolStripButton_Click(object sender, EventArgs e)
        {
            editMode = EditMode.SelectMode;
        }

        private void delete_itemtoolStripButton_Click(object sender, EventArgs e)
        {
            editMode = EditMode.DeleteMode;
        }
        private void Nodw_toolStripButton_Click(object sender, EventArgs e)
        {
            editMode = EditMode.Node;
        }
        private void add_right_cornertoolStripButton_Click(object sender, EventArgs e)
        {
            editMode = EditMode.DrawCurve90;
        }
        private void add_straight_pathtoolStripButton_Click(object sender, EventArgs e)
        {
            editMode = EditMode.DrawLine;
        }

        private void add_bend_pathtoolStripButton_Click(object sender, EventArgs e)
        {
            editMode = EditMode.DrawCurveAny;
        }

        private void add_agvtoolStripButton_Click(object sender, EventArgs e)
        {
            editMode = EditMode.AddCar;
        }
        private void 五軸加工機ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editMode = EditMode.AddStation;
            stationType = Station.StationType.FiveAxisCNC;
        }

        private void 三軸加工機ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editMode = EditMode.AddStation;
            stationType = Station.StationType.ThreeAxisCNC;
        }

        private void 原料倉ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editMode = EditMode.AddStation;
            //stationType = Station.StationType.;
        }

        private void 出貨倉ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 再製品倉ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 無人車充電站ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        #endregion

        private void testRunToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MissionHandler missionHandler = new MissionHandler(this.SFC);
            
            List<int> goodSequence = new List<int>() { 2, 1, 3, 1, 1, 2, 3, 2, 3 };
            
            var misssions = missionHandler.GetGoodSequenceMission(goodSequence);
            gvMissionList.DataSource = misssions;
            //missionHandler.RunMissionList(goodSequence);
            
        }
        private void InitialListView()
        {
            //listView_missionList.View = View.Details;
            //listView_missionList.GridLines = true;
            //listView_missionList.LabelEdit = false;
            //listView_missionList.FullRowSelect = true;
            //listView_missionList.Columns.Add("Mission ID", 70);
            //listView_missionList.Columns.Add("Operation", 60);
            //listView_missionList.Columns.Add("Machine", 60);
            //listView_missionList.Columns.Add("State", 60);
            //for (int i = 0; i < 10; i++)
            //{
            //    var item = new ListViewItem($"No.{i}");
            //    item.SubItems.Add($"文字{i}");
            //    listView_missionList.Items.Add(item);
            //}
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            
        }

        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            frmAddOrder frm = new frmAddOrder(SFC);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                frm.order.OrderId = SFC.Orders.Count + 1;
                SFC.Orders.Add(frm.order);
                gvOrder.DataSource = null;
                gvOrder.DataSource = SFC.Orders.Select(o => new { o.OrderId, o.Product.ProductId, ProductName = o.Product.Name }).ToList();
                var mission = SFC.Orders.Select(a => a.Product).SelectMany(a => a.ProductOperactionList);
                gvMissionList.DataSource = null;

            }
        }

        private void btnGenerateMission_Click(object sender, EventArgs e)
        {
           
        }
    }
}

