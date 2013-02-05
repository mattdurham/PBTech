namespace PBTech
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.statusPBTech = new System.Windows.Forms.StatusStrip();
            this.labelPSI = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.channelSetupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorDia = new System.Windows.Forms.ColorDialog();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.graphTrans = new ZedGraph.ZedGraphControl();
            this._listReadings = new System.Windows.Forms.ListBox();
            this.peekPress = new System.Windows.Forms.Timer(this.components);
            this.sideTreeMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addTransducerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveSelectedToExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusPBTech.SuspendLayout();
            this.menuMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.sideTreeMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusPBTech
            // 
            this.statusPBTech.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelPSI});
            this.statusPBTech.Location = new System.Drawing.Point(0, 634);
            this.statusPBTech.Name = "statusPBTech";
            this.statusPBTech.Size = new System.Drawing.Size(856, 22);
            this.statusPBTech.TabIndex = 0;
            this.statusPBTech.Text = "statusStrip1";
            // 
            // labelPSI
            // 
            this.labelPSI.Name = "labelPSI";
            this.labelPSI.Size = new System.Drawing.Size(31, 17);
            this.labelPSI.Text = "0 psi";
            // 
            // menuMain
            // 
            this.menuMain.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.stopToolStripMenuItem,
            this.channelSetupToolStripMenuItem,
            this.startTestToolStripMenuItem,
            this.saveSelectedToExcelToolStripMenuItem});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuMain.Size = new System.Drawing.Size(856, 24);
            this.menuMain.TabIndex = 5;
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.startToolStripMenuItem.Text = "Start";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.stopToolStripMenuItem.Text = "Stop";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // channelSetupToolStripMenuItem
            // 
            this.channelSetupToolStripMenuItem.Name = "channelSetupToolStripMenuItem";
            this.channelSetupToolStripMenuItem.Size = new System.Drawing.Size(121, 20);
            this.channelSetupToolStripMenuItem.Text = "DAQChannel Setup";
            this.channelSetupToolStripMenuItem.Click += new System.EventHandler(this.channelSetupToolStripMenuItem_Click);
            // 
            // startTestToolStripMenuItem
            // 
            this.startTestToolStripMenuItem.Name = "startTestToolStripMenuItem";
            this.startTestToolStripMenuItem.Size = new System.Drawing.Size(125, 20);
            this.startTestToolStripMenuItem.Text = "Start Graph UnitTest";
            this.startTestToolStripMenuItem.Click += new System.EventHandler(this.startTestToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.graphTrans);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this._listReadings);
            this.splitContainer1.Size = new System.Drawing.Size(856, 610);
            this.splitContainer1.SplitterDistance = 618;
            this.splitContainer1.TabIndex = 6;
            // 
            // graphTrans
            // 
            this.graphTrans.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphTrans.Location = new System.Drawing.Point(0, 0);
            this.graphTrans.Name = "graphTrans";
            this.graphTrans.ScrollGrace = 0D;
            this.graphTrans.ScrollMaxX = 0D;
            this.graphTrans.ScrollMaxY = 0D;
            this.graphTrans.ScrollMaxY2 = 0D;
            this.graphTrans.ScrollMinX = 0D;
            this.graphTrans.ScrollMinY = 0D;
            this.graphTrans.ScrollMinY2 = 0D;
            this.graphTrans.Size = new System.Drawing.Size(618, 610);
            this.graphTrans.TabIndex = 0;
            // 
            // _listReadings
            // 
            this._listReadings.Dock = System.Windows.Forms.DockStyle.Fill;
            this._listReadings.FormattingEnabled = true;
            this._listReadings.Location = new System.Drawing.Point(0, 0);
            this._listReadings.Name = "_listReadings";
            this._listReadings.Size = new System.Drawing.Size(234, 610);
            this._listReadings.TabIndex = 0;
            this._listReadings.SelectedIndexChanged += new System.EventHandler(this._listReadings_SelectedIndexChanged);
            // 
            // peekPress
            // 
            this.peekPress.Interval = 1000;
            this.peekPress.Tick += new System.EventHandler(this.peekPress_Tick);
            // 
            // sideTreeMenu
            // 
            this.sideTreeMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addTransducerToolStripMenuItem});
            this.sideTreeMenu.Name = "sideTreeMenu";
            this.sideTreeMenu.Size = new System.Drawing.Size(159, 26);
            // 
            // addTransducerToolStripMenuItem
            // 
            this.addTransducerToolStripMenuItem.Name = "addTransducerToolStripMenuItem";
            this.addTransducerToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.addTransducerToolStripMenuItem.Text = "Add Transducer";
            // 
            // saveSelectedToExcelToolStripMenuItem
            // 
            this.saveSelectedToExcelToolStripMenuItem.Name = "saveSelectedToExcelToolStripMenuItem";
            this.saveSelectedToExcelToolStripMenuItem.Size = new System.Drawing.Size(136, 20);
            this.saveSelectedToExcelToolStripMenuItem.Text = "Save Selected To Excel";
            this.saveSelectedToExcelToolStripMenuItem.Click += new System.EventHandler(this.saveSelectedToExcelToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 656);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusPBTech);
            this.Controls.Add(this.menuMain);
            this.MainMenuStrip = this.menuMain;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PBTech v2 Alpha";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.statusPBTech.ResumeLayout(false);
            this.statusPBTech.PerformLayout();
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.sideTreeMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusPBTech;
        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel labelPSI;
        private System.Windows.Forms.ColorDialog colorDia;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private ZedGraph.ZedGraphControl graphTrans;
        private System.Windows.Forms.Timer peekPress;
        private System.Windows.Forms.ContextMenuStrip sideTreeMenu;
        private System.Windows.Forms.ToolStripMenuItem addTransducerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem channelSetupToolStripMenuItem;
        private System.Windows.Forms.ListBox _listReadings;
        private System.Windows.Forms.ToolStripMenuItem saveSelectedToExcelToolStripMenuItem;
    }
}

