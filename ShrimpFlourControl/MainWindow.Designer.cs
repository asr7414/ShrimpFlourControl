
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_mapViewer)).BeginInit();
            this.menuStrip.SuspendLayout();
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
            this.pictureBox_mapViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox_mapViewer.Location = new System.Drawing.Point(0, 24);
            this.pictureBox_mapViewer.Name = "pictureBox_mapViewer";
            this.pictureBox_mapViewer.Size = new System.Drawing.Size(1050, 548);
            this.pictureBox_mapViewer.TabIndex = 1;
            this.pictureBox_mapViewer.TabStop = false;
            this.pictureBox_mapViewer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_mapViewer_MouseDown);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectionToolStripMenuItem3});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1050, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";
            // 
            // connectionToolStripMenuItem3
            // 
            this.connectionToolStripMenuItem3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectToolStripMenuItem3});
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
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 572);
            this.Controls.Add(this.pictureBox_mapViewer);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainWindow";
            this.Text = "SFC";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_mapViewer)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
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
    }
}

