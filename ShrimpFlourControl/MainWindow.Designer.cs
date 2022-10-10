
namespace ShrimpFlourControl
{
    partial class MainWindow
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.connectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mapRefreshTimer = new System.Windows.Forms.Timer(this.components);
            this.cOnnectionToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.connectToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.connectionToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.connectToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox_mapViewer = new System.Windows.Forms.PictureBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.connectionToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.connectToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.testRunToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.檔案ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.open_file_from_dbToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.save_to_dbToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clear_dbToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.selecttoolStripButton = new System.Windows.Forms.ToolStripButton();
            this.delete_itemtoolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.Nodw_toolStripButton = new System.Windows.Forms.ToolStripButton();
            this.add_straight_pathtoolStripButton = new System.Windows.Forms.ToolStripButton();
            this.add_bend_pathtoolStripButton = new System.Windows.Forms.ToolStripButton();
            this.add_right_cornertoolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.add_agvtoolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.五軸加工機ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.三軸加工機ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.原料倉ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.出貨倉ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.再製品倉ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.無人車充電站ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.draw_gridtoolStripButton = new System.Windows.Forms.ToolStripButton();
            this.groupBox_AGVinfo = new System.Windows.Forms.GroupBox();
            this.txtMsg = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gvMissionList = new System.Windows.Forms.DataGridView();
            this.AGV_StatetextBox = new System.Windows.Forms.TextBox();
            this.AGV_NodetextBox = new System.Windows.Forms.TextBox();
            this.AGV_IDtextBox = new System.Windows.Forms.TextBox();
            this.label_AGVstate = new System.Windows.Forms.Label();
            this.label_referNode = new System.Windows.Forms.Label();
            this.label_AGVID = new System.Windows.Forms.Label();
            this.groupBox_stationinfo = new System.Windows.Forms.GroupBox();
            this.gvOrder = new System.Windows.Forms.DataGridView();
            this.OrderId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAddOrder = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_mapViewer)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.groupBox_AGVinfo.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvMissionList)).BeginInit();
            this.groupBox_stationinfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvOrder)).BeginInit();
            this.SuspendLayout();
            // 
            // connectionToolStripMenuItem
            // 
            this.connectionToolStripMenuItem.Name = "connectionToolStripMenuItem";
            this.connectionToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.connectionToolStripMenuItem.Text = "Connection";
            // 
            // connectToolStripMenuItem
            // 
            this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            this.connectToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.connectToolStripMenuItem.Text = "Connect";
            this.connectToolStripMenuItem.Click += new System.EventHandler(this.connectToolStripMenuItem_Click);
            // 
            // mapRefreshTimer
            // 
            this.mapRefreshTimer.Interval = 33;
            this.mapRefreshTimer.Tick += new System.EventHandler(this.mapRefreshTimer_Tick);
            // 
            // cOnnectionToolStripMenuItem1
            // 
            this.cOnnectionToolStripMenuItem1.Name = "cOnnectionToolStripMenuItem1";
            this.cOnnectionToolStripMenuItem1.Size = new System.Drawing.Size(84, 20);
            this.cOnnectionToolStripMenuItem1.Text = "Connection";
            // 
            // connectToolStripMenuItem1
            // 
            this.connectToolStripMenuItem1.Name = "connectToolStripMenuItem1";
            this.connectToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.connectToolStripMenuItem1.Text = "Connect";
            this.connectToolStripMenuItem1.Click += new System.EventHandler(this.connectToolStripMenuItem_Click);
            // 
            // connectionToolStripMenuItem2
            // 
            this.connectionToolStripMenuItem2.Name = "connectionToolStripMenuItem2";
            this.connectionToolStripMenuItem2.Size = new System.Drawing.Size(84, 20);
            this.connectionToolStripMenuItem2.Text = "Connection";
            // 
            // connectToolStripMenuItem2
            // 
            this.connectToolStripMenuItem2.Name = "connectToolStripMenuItem2";
            this.connectToolStripMenuItem2.Size = new System.Drawing.Size(180, 22);
            this.connectToolStripMenuItem2.Text = "Connect";
            this.connectToolStripMenuItem2.Click += new System.EventHandler(this.connectToolStripMenuItem_Click);
            // 
            // pictureBox_mapViewer
            // 
            this.pictureBox_mapViewer.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.pictureBox_mapViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox_mapViewer.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_mapViewer.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox_mapViewer.Name = "pictureBox_mapViewer";
            this.pictureBox_mapViewer.Size = new System.Drawing.Size(1799, 894);
            this.pictureBox_mapViewer.TabIndex = 1;
            this.pictureBox_mapViewer.TabStop = false;
            this.pictureBox_mapViewer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_mapViewer_MouseDown);
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectionToolStripMenuItem3,
            this.檔案ToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1799, 28);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";
            // 
            // connectionToolStripMenuItem3
            // 
            this.connectionToolStripMenuItem3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectToolStripMenuItem3,
            this.testRunToolStripMenuItem});
            this.connectionToolStripMenuItem3.Name = "connectionToolStripMenuItem3";
            this.connectionToolStripMenuItem3.Size = new System.Drawing.Size(102, 24);
            this.connectionToolStripMenuItem3.Text = "Connection";
            // 
            // connectToolStripMenuItem3
            // 
            this.connectToolStripMenuItem3.Name = "connectToolStripMenuItem3";
            this.connectToolStripMenuItem3.Size = new System.Drawing.Size(224, 26);
            this.connectToolStripMenuItem3.Text = "Connect";
            this.connectToolStripMenuItem3.Click += new System.EventHandler(this.connectToolStripMenuItem_Click);
            // 
            // testRunToolStripMenuItem
            // 
            this.testRunToolStripMenuItem.Name = "testRunToolStripMenuItem";
            this.testRunToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.testRunToolStripMenuItem.Text = "TestRun";
            this.testRunToolStripMenuItem.Click += new System.EventHandler(this.testRunToolStripMenuItem_Click);
            // 
            // 檔案ToolStripMenuItem
            // 
            this.檔案ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.open_file_from_dbToolStripMenuItem,
            this.save_to_dbToolStripMenuItem,
            this.clear_dbToolStripMenuItem});
            this.檔案ToolStripMenuItem.Name = "檔案ToolStripMenuItem";
            this.檔案ToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.檔案ToolStripMenuItem.Text = "檔案";
            // 
            // open_file_from_dbToolStripMenuItem
            // 
            this.open_file_from_dbToolStripMenuItem.Name = "open_file_from_dbToolStripMenuItem";
            this.open_file_from_dbToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.open_file_from_dbToolStripMenuItem.Text = "開啟舊檔";
            this.open_file_from_dbToolStripMenuItem.Click += new System.EventHandler(this.open_file_from_dbToolStripMenuItem_Click);
            // 
            // save_to_dbToolStripMenuItem
            // 
            this.save_to_dbToolStripMenuItem.Name = "save_to_dbToolStripMenuItem";
            this.save_to_dbToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.save_to_dbToolStripMenuItem.Text = "另存新檔";
            this.save_to_dbToolStripMenuItem.Click += new System.EventHandler(this.save_to_dbToolStripMenuItem_Click);
            // 
            // clear_dbToolStripMenuItem
            // 
            this.clear_dbToolStripMenuItem.Name = "clear_dbToolStripMenuItem";
            this.clear_dbToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.clear_dbToolStripMenuItem.Text = "刪除舊檔";
            this.clear_dbToolStripMenuItem.Click += new System.EventHandler(this.clear_dbToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selecttoolStripButton,
            this.delete_itemtoolStripButton,
            this.toolStripSeparator1,
            this.Nodw_toolStripButton,
            this.add_straight_pathtoolStripButton,
            this.add_bend_pathtoolStripButton,
            this.add_right_cornertoolStripButton,
            this.toolStripSeparator2,
            this.add_agvtoolStripButton,
            this.toolStripSplitButton1,
            this.toolStripSeparator3,
            this.draw_gridtoolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 28);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1799, 35);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // selecttoolStripButton
            // 
            this.selecttoolStripButton.AutoSize = false;
            this.selecttoolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.selecttoolStripButton.Image = global::ShrimpFlourControl.Properties.Resources.select;
            this.selecttoolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.selecttoolStripButton.Margin = new System.Windows.Forms.Padding(3, 1, 3, 2);
            this.selecttoolStripButton.Name = "selecttoolStripButton";
            this.selecttoolStripButton.Size = new System.Drawing.Size(24, 25);
            this.selecttoolStripButton.Text = "Select Mode";
            this.selecttoolStripButton.Click += new System.EventHandler(this.selecttoolStripButton_Click);
            // 
            // delete_itemtoolStripButton
            // 
            this.delete_itemtoolStripButton.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.delete_itemtoolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.delete_itemtoolStripButton.Image = global::ShrimpFlourControl.Properties.Resources.del;
            this.delete_itemtoolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.delete_itemtoolStripButton.Margin = new System.Windows.Forms.Padding(3, 1, 3, 2);
            this.delete_itemtoolStripButton.Name = "delete_itemtoolStripButton";
            this.delete_itemtoolStripButton.Size = new System.Drawing.Size(29, 32);
            this.delete_itemtoolStripButton.Text = "Delete Item";
            this.delete_itemtoolStripButton.Click += new System.EventHandler(this.delete_itemtoolStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 35);
            // 
            // Nodw_toolStripButton
            // 
            this.Nodw_toolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Nodw_toolStripButton.Image = global::ShrimpFlourControl.Properties.Resources.normal_node;
            this.Nodw_toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Nodw_toolStripButton.Name = "Nodw_toolStripButton";
            this.Nodw_toolStripButton.Size = new System.Drawing.Size(29, 32);
            this.Nodw_toolStripButton.Text = "toolStripButton1";
            this.Nodw_toolStripButton.Click += new System.EventHandler(this.Nodw_toolStripButton_Click);
            // 
            // add_straight_pathtoolStripButton
            // 
            this.add_straight_pathtoolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.add_straight_pathtoolStripButton.Image = global::ShrimpFlourControl.Properties.Resources.nodes1;
            this.add_straight_pathtoolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.add_straight_pathtoolStripButton.Margin = new System.Windows.Forms.Padding(3, 1, 3, 2);
            this.add_straight_pathtoolStripButton.Name = "add_straight_pathtoolStripButton";
            this.add_straight_pathtoolStripButton.Size = new System.Drawing.Size(29, 32);
            this.add_straight_pathtoolStripButton.Text = "Add Straight Path";
            this.add_straight_pathtoolStripButton.Click += new System.EventHandler(this.add_straight_pathtoolStripButton_Click);
            // 
            // add_bend_pathtoolStripButton
            // 
            this.add_bend_pathtoolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.add_bend_pathtoolStripButton.Image = global::ShrimpFlourControl.Properties.Resources.arc;
            this.add_bend_pathtoolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.add_bend_pathtoolStripButton.Margin = new System.Windows.Forms.Padding(3, 1, 3, 2);
            this.add_bend_pathtoolStripButton.Name = "add_bend_pathtoolStripButton";
            this.add_bend_pathtoolStripButton.Size = new System.Drawing.Size(29, 32);
            this.add_bend_pathtoolStripButton.Text = "Add Bend Path";
            this.add_bend_pathtoolStripButton.Click += new System.EventHandler(this.add_bend_pathtoolStripButton_Click);
            // 
            // add_right_cornertoolStripButton
            // 
            this.add_right_cornertoolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.add_right_cornertoolStripButton.Image = global::ShrimpFlourControl.Properties.Resources.RIGHTCORNER1;
            this.add_right_cornertoolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.add_right_cornertoolStripButton.Margin = new System.Windows.Forms.Padding(3, 1, 3, 2);
            this.add_right_cornertoolStripButton.Name = "add_right_cornertoolStripButton";
            this.add_right_cornertoolStripButton.Size = new System.Drawing.Size(29, 32);
            this.add_right_cornertoolStripButton.Text = "Add Right Corner Path";
            this.add_right_cornertoolStripButton.Click += new System.EventHandler(this.add_right_cornertoolStripButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 35);
            // 
            // add_agvtoolStripButton
            // 
            this.add_agvtoolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.add_agvtoolStripButton.Image = global::ShrimpFlourControl.Properties.Resources.self_driving;
            this.add_agvtoolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.add_agvtoolStripButton.Margin = new System.Windows.Forms.Padding(3, 1, 3, 2);
            this.add_agvtoolStripButton.Name = "add_agvtoolStripButton";
            this.add_agvtoolStripButton.Size = new System.Drawing.Size(29, 32);
            this.add_agvtoolStripButton.Text = "Add AGV";
            this.add_agvtoolStripButton.Click += new System.EventHandler(this.add_agvtoolStripButton_Click);
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.五軸加工機ToolStripMenuItem,
            this.三軸加工機ToolStripMenuItem,
            this.原料倉ToolStripMenuItem,
            this.出貨倉ToolStripMenuItem,
            this.再製品倉ToolStripMenuItem,
            this.無人車充電站ToolStripMenuItem});
            this.toolStripSplitButton1.Image = global::ShrimpFlourControl.Properties.Resources.workstation1;
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(39, 32);
            this.toolStripSplitButton1.Text = "toolStripSplitButton1";
            // 
            // 五軸加工機ToolStripMenuItem
            // 
            this.五軸加工機ToolStripMenuItem.Name = "五軸加工機ToolStripMenuItem";
            this.五軸加工機ToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.五軸加工機ToolStripMenuItem.Text = "五軸加工機";
            this.五軸加工機ToolStripMenuItem.Click += new System.EventHandler(this.五軸加工機ToolStripMenuItem_Click);
            // 
            // 三軸加工機ToolStripMenuItem
            // 
            this.三軸加工機ToolStripMenuItem.Name = "三軸加工機ToolStripMenuItem";
            this.三軸加工機ToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.三軸加工機ToolStripMenuItem.Text = "三軸加工機";
            this.三軸加工機ToolStripMenuItem.Click += new System.EventHandler(this.三軸加工機ToolStripMenuItem_Click);
            // 
            // 原料倉ToolStripMenuItem
            // 
            this.原料倉ToolStripMenuItem.Name = "原料倉ToolStripMenuItem";
            this.原料倉ToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.原料倉ToolStripMenuItem.Text = "原料倉";
            this.原料倉ToolStripMenuItem.Click += new System.EventHandler(this.原料倉ToolStripMenuItem_Click);
            // 
            // 出貨倉ToolStripMenuItem
            // 
            this.出貨倉ToolStripMenuItem.Name = "出貨倉ToolStripMenuItem";
            this.出貨倉ToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.出貨倉ToolStripMenuItem.Text = "成品倉";
            this.出貨倉ToolStripMenuItem.Click += new System.EventHandler(this.出貨倉ToolStripMenuItem_Click);
            // 
            // 再製品倉ToolStripMenuItem
            // 
            this.再製品倉ToolStripMenuItem.Name = "再製品倉ToolStripMenuItem";
            this.再製品倉ToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.再製品倉ToolStripMenuItem.Text = "再製品倉";
            this.再製品倉ToolStripMenuItem.Click += new System.EventHandler(this.再製品倉ToolStripMenuItem_Click);
            // 
            // 無人車充電站ToolStripMenuItem
            // 
            this.無人車充電站ToolStripMenuItem.Name = "無人車充電站ToolStripMenuItem";
            this.無人車充電站ToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.無人車充電站ToolStripMenuItem.Text = "無人車充電站";
            this.無人車充電站ToolStripMenuItem.Click += new System.EventHandler(this.無人車充電站ToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 35);
            // 
            // draw_gridtoolStripButton
            // 
            this.draw_gridtoolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.draw_gridtoolStripButton.Image = global::ShrimpFlourControl.Properties.Resources.grid;
            this.draw_gridtoolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.draw_gridtoolStripButton.Margin = new System.Windows.Forms.Padding(3, 1, 3, 2);
            this.draw_gridtoolStripButton.Name = "draw_gridtoolStripButton";
            this.draw_gridtoolStripButton.Size = new System.Drawing.Size(29, 32);
            this.draw_gridtoolStripButton.Text = "Draw Grid";
            this.draw_gridtoolStripButton.Click += new System.EventHandler(this.draw_gridtoolStripButton_Click);
            // 
            // groupBox_AGVinfo
            // 
            this.groupBox_AGVinfo.Controls.Add(this.txtMsg);
            this.groupBox_AGVinfo.Controls.Add(this.groupBox1);
            this.groupBox_AGVinfo.Controls.Add(this.AGV_StatetextBox);
            this.groupBox_AGVinfo.Controls.Add(this.AGV_NodetextBox);
            this.groupBox_AGVinfo.Controls.Add(this.AGV_IDtextBox);
            this.groupBox_AGVinfo.Controls.Add(this.label_AGVstate);
            this.groupBox_AGVinfo.Controls.Add(this.label_referNode);
            this.groupBox_AGVinfo.Controls.Add(this.label_AGVID);
            this.groupBox_AGVinfo.Controls.Add(this.groupBox_stationinfo);
            this.groupBox_AGVinfo.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox_AGVinfo.Location = new System.Drawing.Point(1435, 63);
            this.groupBox_AGVinfo.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox_AGVinfo.Name = "groupBox_AGVinfo";
            this.groupBox_AGVinfo.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox_AGVinfo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox_AGVinfo.Size = new System.Drawing.Size(364, 831);
            this.groupBox_AGVinfo.TabIndex = 3;
            this.groupBox_AGVinfo.TabStop = false;
            this.groupBox_AGVinfo.Text = "AGV information";
            // 
            // txtMsg
            // 
            this.txtMsg.Location = new System.Drawing.Point(8, 745);
            this.txtMsg.Margin = new System.Windows.Forms.Padding(4);
            this.txtMsg.Multiline = true;
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.Size = new System.Drawing.Size(339, 68);
            this.txtMsg.TabIndex = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gvMissionList);
            this.groupBox1.Location = new System.Drawing.Point(0, 320);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(356, 417);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mission List";
            // 
            // gvMissionList
            // 
            this.gvMissionList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvMissionList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvMissionList.Location = new System.Drawing.Point(4, 22);
            this.gvMissionList.Name = "gvMissionList";
            this.gvMissionList.RowHeadersVisible = false;
            this.gvMissionList.RowHeadersWidth = 51;
            this.gvMissionList.RowTemplate.Height = 27;
            this.gvMissionList.Size = new System.Drawing.Size(348, 391);
            this.gvMissionList.TabIndex = 0;
            // 
            // AGV_StatetextBox
            // 
            this.AGV_StatetextBox.Location = new System.Drawing.Point(83, 84);
            this.AGV_StatetextBox.Margin = new System.Windows.Forms.Padding(4);
            this.AGV_StatetextBox.Name = "AGV_StatetextBox";
            this.AGV_StatetextBox.Size = new System.Drawing.Size(132, 25);
            this.AGV_StatetextBox.TabIndex = 9;
            // 
            // AGV_NodetextBox
            // 
            this.AGV_NodetextBox.Location = new System.Drawing.Point(83, 51);
            this.AGV_NodetextBox.Margin = new System.Windows.Forms.Padding(4);
            this.AGV_NodetextBox.Name = "AGV_NodetextBox";
            this.AGV_NodetextBox.Size = new System.Drawing.Size(132, 25);
            this.AGV_NodetextBox.TabIndex = 8;
            // 
            // AGV_IDtextBox
            // 
            this.AGV_IDtextBox.Location = new System.Drawing.Point(83, 21);
            this.AGV_IDtextBox.Margin = new System.Windows.Forms.Padding(4);
            this.AGV_IDtextBox.Name = "AGV_IDtextBox";
            this.AGV_IDtextBox.Size = new System.Drawing.Size(132, 25);
            this.AGV_IDtextBox.TabIndex = 7;
            // 
            // label_AGVstate
            // 
            this.label_AGVstate.AutoSize = true;
            this.label_AGVstate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label_AGVstate.Location = new System.Drawing.Point(32, 96);
            this.label_AGVstate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_AGVstate.Name = "label_AGVstate";
            this.label_AGVstate.Size = new System.Drawing.Size(35, 15);
            this.label_AGVstate.TabIndex = 6;
            this.label_AGVstate.Text = "State";
            // 
            // label_referNode
            // 
            this.label_referNode.AutoSize = true;
            this.label_referNode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label_referNode.Location = new System.Drawing.Point(32, 64);
            this.label_referNode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_referNode.Name = "label_referNode";
            this.label_referNode.Size = new System.Drawing.Size(37, 15);
            this.label_referNode.TabIndex = 5;
            this.label_referNode.Text = "Node";
            // 
            // label_AGVID
            // 
            this.label_AGVID.AutoSize = true;
            this.label_AGVID.Location = new System.Drawing.Point(32, 34);
            this.label_AGVID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_AGVID.Name = "label_AGVID";
            this.label_AGVID.Size = new System.Drawing.Size(22, 15);
            this.label_AGVID.TabIndex = 4;
            this.label_AGVID.Text = "ID";
            // 
            // groupBox_stationinfo
            // 
            this.groupBox_stationinfo.Controls.Add(this.gvOrder);
            this.groupBox_stationinfo.Controls.Add(this.btnAddOrder);
            this.groupBox_stationinfo.Location = new System.Drawing.Point(0, 134);
            this.groupBox_stationinfo.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox_stationinfo.Name = "groupBox_stationinfo";
            this.groupBox_stationinfo.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox_stationinfo.Size = new System.Drawing.Size(356, 178);
            this.groupBox_stationinfo.TabIndex = 4;
            this.groupBox_stationinfo.TabStop = false;
            this.groupBox_stationinfo.Text = "Order information";
            // 
            // gvOrder
            // 
            this.gvOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvOrder.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OrderId,
            this.ProductId,
            this.ProductName});
            this.gvOrder.Location = new System.Drawing.Point(8, 29);
            this.gvOrder.Name = "gvOrder";
            this.gvOrder.RowHeadersVisible = false;
            this.gvOrder.RowHeadersWidth = 51;
            this.gvOrder.RowTemplate.Height = 15;
            this.gvOrder.Size = new System.Drawing.Size(339, 142);
            this.gvOrder.TabIndex = 1;
            // 
            // OrderId
            // 
            this.OrderId.DataPropertyName = "OrderId";
            this.OrderId.HeaderText = "OrderId";
            this.OrderId.MinimumWidth = 6;
            this.OrderId.Name = "OrderId";
            this.OrderId.Width = 70;
            // 
            // ProductId
            // 
            this.ProductId.DataPropertyName = "ProductId";
            this.ProductId.HeaderText = "ProductId";
            this.ProductId.MinimumWidth = 6;
            this.ProductId.Name = "ProductId";
            this.ProductId.Width = 70;
            // 
            // ProductName
            // 
            this.ProductName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ProductName.DataPropertyName = "ProductName";
            this.ProductName.HeaderText = "ProductName";
            this.ProductName.MinimumWidth = 6;
            this.ProductName.Name = "ProductName";
            // 
            // btnAddOrder
            // 
            this.btnAddOrder.Location = new System.Drawing.Point(125, 0);
            this.btnAddOrder.Name = "btnAddOrder";
            this.btnAddOrder.Size = new System.Drawing.Size(75, 23);
            this.btnAddOrder.TabIndex = 0;
            this.btnAddOrder.Text = "新增Order";
            this.btnAddOrder.UseVisualStyleBackColor = true;
            this.btnAddOrder.Click += new System.EventHandler(this.btnAddOrder_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1799, 894);
            this.Controls.Add(this.groupBox_AGVinfo);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.pictureBox_mapViewer);
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainWindow";
            this.Text = "SFC";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_mapViewer)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox_AGVinfo.ResumeLayout(false);
            this.groupBox_AGVinfo.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvMissionList)).EndInit();
            this.groupBox_stationinfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvOrder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem connectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
        private System.Windows.Forms.Timer mapRefreshTimer;
        private System.Windows.Forms.ToolStripMenuItem cOnnectionToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem connectionToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem2;
        private System.Windows.Forms.PictureBox pictureBox_mapViewer;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem connectionToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem 檔案ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem open_file_from_dbToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem save_to_dbToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton selecttoolStripButton;
        private System.Windows.Forms.ToolStripButton delete_itemtoolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton add_straight_pathtoolStripButton;
        private System.Windows.Forms.ToolStripButton add_bend_pathtoolStripButton;
        private System.Windows.Forms.ToolStripButton add_right_cornertoolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton add_agvtoolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton draw_gridtoolStripButton;
        private System.Windows.Forms.ToolStripMenuItem clear_dbToolStripMenuItem;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripMenuItem 五軸加工機ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 三軸加工機ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 原料倉ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 出貨倉ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 再製品倉ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 無人車充電站ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testRunToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox_AGVinfo;
        private System.Windows.Forms.Label label_AGVID;
        private System.Windows.Forms.GroupBox groupBox_stationinfo;
        private System.Windows.Forms.Label label_AGVstate;
        private System.Windows.Forms.Label label_referNode;
        private System.Windows.Forms.TextBox AGV_StatetextBox;
        private System.Windows.Forms.TextBox AGV_NodetextBox;
        private System.Windows.Forms.TextBox AGV_IDtextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtMsg;
        private System.Windows.Forms.Button btnAddOrder;
        private System.Windows.Forms.ToolStripButton Nodw_toolStripButton;
        private System.Windows.Forms.DataGridView gvOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridView gvMissionList;
    }
}

