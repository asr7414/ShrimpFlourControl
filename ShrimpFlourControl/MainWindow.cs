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

namespace ShrimpFlourControl
{
    public partial class MainWindow : Form
    {
        private readonly MapDrawer _mapDrawer;
        public SFCServer SFC { get; }

        private readonly Database _dataBase;
        private EditMode editMode;
        private Station.StationType stationType;
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
            this.SFC = new SFCServer();
            _mapDrawer = new MapDrawer(this.SFC);
            mapRefreshTimer.Enabled = true;
            var fiveAxis = new FiveAxisCNC(123, new Maps.Node(12, 1, 1), 10, 10);
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
            //gridState = true;

            //var bitMap = new Bitmap(Grid_picturebox.Width, Grid_picturebox.Height);
            //using (var g = Graphics.FromImage(bitMap))
            //{
            //    float startx, starty, endx, endy;
            //    startx = 0;
            //    starty = 0;
            //    endx = canvasSize.Width;
            //    endy = canvasSize.Height;

            //    for (int i = 1; i < canvasSize.Width; i++)
            //    {
            //        g.DrawLine(new Pen(Color.FromArgb(128, 220, 220, 220), 1), (startx + initialgridsize) * i * gridscale, starty * i * gridscale, (startx + initialgridsize) * i * gridscale, endy * i * gridscale);
            //        for (int j = 1; j < canvasSize.Height; j++)
            //        {
            //            g.DrawLine(new Pen(Color.FromArgb(128, 220, 220, 220), 1), startx * j * gridscale, (starty + initialgridsize) * j * gridscale, endx * j * gridscale, (starty + initialgridsize) * j * gridscale);
            //        }
            //    }
            //}
            //Grid_button.Enabled = false;
            //Grid_picturebox.Image = bitMap;
        }

        #endregion

        #region MapViewer Callbacks
        private void pictureBox_mapViewer_MouseDown(object sender, MouseEventArgs e)
        {
            //switch (EditMode)
            //{

            //}
            SFC.SelectedStation = _mapDrawer.GetStation(e.Location);
            SFC.SelectedAGV = _mapDrawer.GetAGV(e.Location);
            SFC.SelectedNode = _mapDrawer.GetNode(e.Location);
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
            missionHandler.RunMissionList(goodSequence);
        }
    }
}

