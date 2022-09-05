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



namespace ShrimpFlourControl
{
    public partial class MainWindow : Form
    {
        private readonly MapDrawer _mapDrawer;
        public SFCServer SFC { get; }
        
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

       
    }
}

