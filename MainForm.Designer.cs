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
            this.configurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveGraphToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorDia = new System.Windows.Forms.ColorDialog();
            this.timeDraw = new System.Windows.Forms.Timer(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.graphTrans = new ZedGraph.ZedGraphControl();
            this.sideView = new System.Windows.Forms.TreeView();
            this.peekPress = new System.Windows.Forms.Timer(this.components);
            this.sideTreeMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addTransducerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusPBTech.SuspendLayout();
            this.menuMain.SuspendLayout();
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
            this.labelPSI.Size = new System.Drawing.Size(29, 17);
            this.labelPSI.Text = "0 psi";
            // 
            // menuMain
            // 
            this.menuMain.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configurationToolStripMenuItem,
            this.startToolStripMenuItem,
            this.stopToolStripMenuItem,
            this.saveGraphToolStripMenuItem});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuMain.Size = new System.Drawing.Size(856, 24);
            this.menuMain.TabIndex = 5;
            // 
            // configurationToolStripMenuItem
            // 
            this.configurationToolStripMenuItem.Name = "configurationToolStripMenuItem";
            this.configurationToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.configurationToolStripMenuItem.Text = "Configuration";
            this.configurationToolStripMenuItem.Click += new System.EventHandler(this.configurationToolStripMenuItem_Click);
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
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.stopToolStripMenuItem.Text = "Stop";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // saveGraphToolStripMenuItem
            // 
            this.saveGraphToolStripMenuItem.Name = "saveGraphToolStripMenuItem";
            this.saveGraphToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.saveGraphToolStripMenuItem.Text = "Save Graph";
            this.saveGraphToolStripMenuItem.Click += new System.EventHandler(this.saveGraphToolStripMenuItem_Click);
            // 
            // timeDraw
            // 
            this.timeDraw.Interval = 133;
            this.timeDraw.Tick += new System.EventHandler(this.timer1_Tick);
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
            this.splitContainer1.Panel2.Controls.Add(this.sideView);
            this.splitContainer1.Size = new System.Drawing.Size(856, 610);
            this.splitContainer1.SplitterDistance = 618;
            this.splitContainer1.TabIndex = 6;
            // 
            // graphTrans
            // 
            this.graphTrans.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphTrans.IsAutoScrollRange = false;
            this.graphTrans.IsEnableHPan = true;
            this.graphTrans.IsEnableHZoom = true;
            this.graphTrans.IsEnableVPan = true;
            this.graphTrans.IsEnableVZoom = true;
            this.graphTrans.IsPrintFillPage = true;
            this.graphTrans.IsPrintKeepAspectRatio = true;
            this.graphTrans.IsScrollY2 = false;
            this.graphTrans.IsShowContextMenu = true;
            this.graphTrans.IsShowCopyMessage = true;
            this.graphTrans.IsShowCursorValues = false;
            this.graphTrans.IsShowHScrollBar = false;
            this.graphTrans.IsShowPointValues = false;
            this.graphTrans.IsShowVScrollBar = false;
            this.graphTrans.IsZoomOnMouseCenter = false;
            this.graphTrans.Location = new System.Drawing.Point(0, 0);
            this.graphTrans.Name = "graphTrans";
            this.graphTrans.PanButtons = System.Windows.Forms.MouseButtons.Left;
            this.graphTrans.PanButtons2 = System.Windows.Forms.MouseButtons.Middle;
            this.graphTrans.PanModifierKeys2 = System.Windows.Forms.Keys.None;
            this.graphTrans.PointDateFormat = "g";
            this.graphTrans.PointValueFormat = "G";
            this.graphTrans.ScrollMaxX = 0;
            this.graphTrans.ScrollMaxY = 0;
            this.graphTrans.ScrollMaxY2 = 0;
            this.graphTrans.ScrollMinX = 0;
            this.graphTrans.ScrollMinY = 0;
            this.graphTrans.ScrollMinY2 = 0;
            this.graphTrans.Size = new System.Drawing.Size(618, 610);
            this.graphTrans.TabIndex = 0;
            this.graphTrans.ZoomButtons = System.Windows.Forms.MouseButtons.Left;
            this.graphTrans.ZoomButtons2 = System.Windows.Forms.MouseButtons.None;
            this.graphTrans.ZoomModifierKeys = System.Windows.Forms.Keys.None;
            this.graphTrans.ZoomModifierKeys2 = System.Windows.Forms.Keys.None;
            this.graphTrans.ZoomStepFraction = 0.1;
            // 
            // sideView
            // 
            this.sideView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sideView.Location = new System.Drawing.Point(0, 0);
            this.sideView.Name = "sideView";
            this.sideView.Size = new System.Drawing.Size(234, 610);
            this.sideView.TabIndex = 0;
            // 
            // peekPress
            // 
            this.peekPress.Tick += new System.EventHandler(this.peekPress_Tick);
            // 
            // sideTreeMenu
            // 
            this.sideTreeMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addTransducerToolStripMenuItem});
            this.sideTreeMenu.Name = "sideTreeMenu";
            this.sideTreeMenu.Size = new System.Drawing.Size(162, 26);
            // 
            // addTransducerToolStripMenuItem
            // 
            this.addTransducerToolStripMenuItem.Name = "addTransducerToolStripMenuItem";
            this.addTransducerToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.addTransducerToolStripMenuItem.Text = "Add Transducer";
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
            this.statusPBTech.ResumeLayout(false);
            this.statusPBTech.PerformLayout();
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.sideTreeMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusPBTech;
        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem configurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel labelPSI;
        private System.Windows.Forms.ColorDialog colorDia;
        private System.Windows.Forms.Timer timeDraw;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private ZedGraph.ZedGraphControl graphTrans;
        private System.Windows.Forms.Timer peekPress;
        private System.Windows.Forms.TreeView sideView;
        private System.Windows.Forms.ContextMenuStrip sideTreeMenu;
        private System.Windows.Forms.ToolStripMenuItem addTransducerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveGraphToolStripMenuItem;
    }
}

