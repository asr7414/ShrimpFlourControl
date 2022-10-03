
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
            this.檔案ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.open_file_from_dbToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.save_to_dbToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clear_dbToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.selecttoolStripButton = new System.Windows.Forms.ToolStripButton();
            this.delete_itemtoolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.add_straight_pathtoolStripButton = new System.Windows.Forms.ToolStripButton();
            this.add_bend_pathtoolStripButton = new System.Windows.Forms.ToolStripButton();
            this.add_right_cornertoolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.add_agvtoolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.draw_gridtoolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.五軸加工機ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.三軸加工機ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.原料倉ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.出貨倉ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.再製品倉ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.無人車充電站ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testRunToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_mapViewer)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.toolStrip1.SuspendLayout();
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
            this.pictureBox_mapViewer.Name = "pictureBox_mapViewer";
            this.pictureBox_mapViewer.Size = new System.Drawing.Size(1159, 585);
            this.pictureBox_mapViewer.TabIndex = 1;
            this.pictureBox_mapViewer.TabStop = false;
            this.pictureBox_mapViewer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_mapViewer_MouseDown);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectionToolStripMenuItem3,
            this.檔案ToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1159, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";
            // 
            // connectionToolStripMenuItem3
            // 
            this.connectionToolStripMenuItem3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectToolStripMenuItem3,
            this.testRunToolStripMenuItem});
            this.connectionToolStripMenuItem3.Name = "connectionToolStripMenuItem3";
            this.connectionToolStripMenuItem3.Size = new System.Drawing.Size(84, 20);
            this.connectionToolStripMenuItem3.Text = "Connection";
            // 
            // connectToolStripMenuItem3
            // 
            this.connectToolStripMenuItem3.Name = "connectToolStripMenuItem3";
            this.connectToolStripMenuItem3.Size = new System.Drawing.Size(121, 22);
            this.connectToolStripMenuItem3.Text = "Connect";
            this.connectToolStripMenuItem3.Click += new System.EventHandler(this.connectToolStripMenuItem_Click);
            // 
            // 檔案ToolStripMenuItem
            // 
            this.檔案ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.open_file_from_dbToolStripMenuItem,
            this.save_to_dbToolStripMenuItem,
            this.clear_dbToolStripMenuItem});
            this.檔案ToolStripMenuItem.Name = "檔案ToolStripMenuItem";
            this.檔案ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.檔案ToolStripMenuItem.Text = "檔案";
            // 
            // open_file_from_dbToolStripMenuItem
            // 
            this.open_file_from_dbToolStripMenuItem.Name = "open_file_from_dbToolStripMenuItem";
            this.open_file_from_dbToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.open_file_from_dbToolStripMenuItem.Text = "開啟舊檔";
            this.open_file_from_dbToolStripMenuItem.Click += new System.EventHandler(this.open_file_from_dbToolStripMenuItem_Click);
            // 
            // save_to_dbToolStripMenuItem
            // 
            this.save_to_dbToolStripMenuItem.Name = "save_to_dbToolStripMenuItem";
            this.save_to_dbToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.save_to_dbToolStripMenuItem.Text = "另存新檔";
            this.save_to_dbToolStripMenuItem.Click += new System.EventHandler(this.save_to_dbToolStripMenuItem_Click);
            // 
            // clear_dbToolStripMenuItem
            // 
            this.clear_dbToolStripMenuItem.Name = "clear_dbToolStripMenuItem";
            this.clear_dbToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
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
            this.add_straight_pathtoolStripButton,
            this.add_bend_pathtoolStripButton,
            this.add_right_cornertoolStripButton,
            this.toolStripSeparator2,
            this.add_agvtoolStripButton,
            this.toolStripSplitButton1,
            this.toolStripSeparator3,
            this.draw_gridtoolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1159, 28);
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
            this.delete_itemtoolStripButton.Size = new System.Drawing.Size(24, 25);
            this.delete_itemtoolStripButton.Text = "Delete Item";
            this.delete_itemtoolStripButton.Click += new System.EventHandler(this.delete_itemtoolStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 28);
            // 
            // add_straight_pathtoolStripButton
            // 
            this.add_straight_pathtoolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.add_straight_pathtoolStripButton.Image = global::ShrimpFlourControl.Properties.Resources.nodes1;
            this.add_straight_pathtoolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.add_straight_pathtoolStripButton.Margin = new System.Windows.Forms.Padding(3, 1, 3, 2);
            this.add_straight_pathtoolStripButton.Name = "add_straight_pathtoolStripButton";
            this.add_straight_pathtoolStripButton.Size = new System.Drawing.Size(24, 25);
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
            this.add_bend_pathtoolStripButton.Size = new System.Drawing.Size(24, 25);
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
            this.add_right_cornertoolStripButton.Size = new System.Drawing.Size(24, 25);
            this.add_right_cornertoolStripButton.Text = "Add Right Corner Path";
            this.add_right_cornertoolStripButton.Click += new System.EventHandler(this.add_right_cornertoolStripButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 28);
            // 
            // add_agvtoolStripButton
            // 
            this.add_agvtoolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.add_agvtoolStripButton.Image = global::ShrimpFlourControl.Properties.Resources.self_driving;
            this.add_agvtoolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.add_agvtoolStripButton.Margin = new System.Windows.Forms.Padding(3, 1, 3, 2);
            this.add_agvtoolStripButton.Name = "add_agvtoolStripButton";
            this.add_agvtoolStripButton.Size = new System.Drawing.Size(24, 25);
            this.add_agvtoolStripButton.Text = "Add AGV";
            this.add_agvtoolStripButton.Click += new System.EventHandler(this.add_agvtoolStripButton_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 28);
            // 
            // draw_gridtoolStripButton
            // 
            this.draw_gridtoolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.draw_gridtoolStripButton.Image = global::ShrimpFlourControl.Properties.Resources.grid;
            this.draw_gridtoolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.draw_gridtoolStripButton.Margin = new System.Windows.Forms.Padding(3, 1, 3, 2);
            this.draw_gridtoolStripButton.Name = "draw_gridtoolStripButton";
            this.draw_gridtoolStripButton.Size = new System.Drawing.Size(24, 25);
            this.draw_gridtoolStripButton.Text = "Draw Grid";
            this.draw_gridtoolStripButton.Click += new System.EventHandler(this.draw_gridtoolStripButton_Click);
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
            this.toolStripSplitButton1.Size = new System.Drawing.Size(36, 25);
            this.toolStripSplitButton1.Text = "toolStripSplitButton1";
            // 
            // 五軸加工機ToolStripMenuItem
            // 
            this.五軸加工機ToolStripMenuItem.Name = "五軸加工機ToolStripMenuItem";
            this.五軸加工機ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.五軸加工機ToolStripMenuItem.Text = "五軸加工機";
            this.五軸加工機ToolStripMenuItem.Click += new System.EventHandler(this.五軸加工機ToolStripMenuItem_Click);
            // 
            // 三軸加工機ToolStripMenuItem
            // 
            this.三軸加工機ToolStripMenuItem.Name = "三軸加工機ToolStripMenuItem";
            this.三軸加工機ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.三軸加工機ToolStripMenuItem.Text = "三軸加工機";
            this.三軸加工機ToolStripMenuItem.Click += new System.EventHandler(this.三軸加工機ToolStripMenuItem_Click);
            // 
            // 原料倉ToolStripMenuItem
            // 
            this.原料倉ToolStripMenuItem.Name = "原料倉ToolStripMenuItem";
            this.原料倉ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.原料倉ToolStripMenuItem.Text = "原料倉";
            this.原料倉ToolStripMenuItem.Click += new System.EventHandler(this.原料倉ToolStripMenuItem_Click);
            // 
            // 出貨倉ToolStripMenuItem
            // 
            this.出貨倉ToolStripMenuItem.Name = "出貨倉ToolStripMenuItem";
            this.出貨倉ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.出貨倉ToolStripMenuItem.Text = "成品倉";
            this.出貨倉ToolStripMenuItem.Click += new System.EventHandler(this.出貨倉ToolStripMenuItem_Click);
            // 
            // 再製品倉ToolStripMenuItem
            // 
            this.再製品倉ToolStripMenuItem.Name = "再製品倉ToolStripMenuItem";
            this.再製品倉ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.再製品倉ToolStripMenuItem.Text = "再製品倉";
            this.再製品倉ToolStripMenuItem.Click += new System.EventHandler(this.再製品倉ToolStripMenuItem_Click);
            // 
            // 無人車充電站ToolStripMenuItem
            // 
            this.無人車充電站ToolStripMenuItem.Name = "無人車充電站ToolStripMenuItem";
            this.無人車充電站ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.無人車充電站ToolStripMenuItem.Text = "無人車充電站";
            this.無人車充電站ToolStripMenuItem.Click += new System.EventHandler(this.無人車充電站ToolStripMenuItem_Click);
            // 
            // testRunToolStripMenuItem
            // 
            this.testRunToolStripMenuItem.Name = "testRunToolStripMenuItem";
            this.testRunToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.testRunToolStripMenuItem.Text = "TestRun";
            this.testRunToolStripMenuItem.Click += new System.EventHandler(this.testRunToolStripMenuItem_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1159, 585);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.pictureBox_mapViewer);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainWindow";
            this.Text = "SFC";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_mapViewer)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
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
    }
}

