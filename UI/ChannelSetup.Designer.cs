namespace PBTech
{
    partial class ChannelSetup
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
            this._listChannelConfig = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.addButton = new System.Windows.Forms.Button();
            this._lblName = new System.Windows.Forms.Label();
            this._textName = new System.Windows.Forms.TextBox();
            this._psiLabel = new System.Windows.Forms.Label();
            this._txtPSI = new System.Windows.Forms.TextBox();
            this._lblOutput = new System.Windows.Forms.Label();
            this._cmbOutput = new System.Windows.Forms.ComboBox();
            this._lblOffset = new System.Windows.Forms.Label();
            this._txtOffset = new System.Windows.Forms.TextBox();
            this._lblDefaultChannel = new System.Windows.Forms.Label();
            this._txtDefaultChannel = new System.Windows.Forms.TextBox();
            this._buttonSave = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _listChannelConfig
            // 
            this._listChannelConfig.Dock = System.Windows.Forms.DockStyle.Left;
            this._listChannelConfig.FormattingEnabled = true;
            this._listChannelConfig.Location = new System.Drawing.Point(0, 0);
            this._listChannelConfig.Name = "_listChannelConfig";
            this._listChannelConfig.Size = new System.Drawing.Size(217, 241);
            this._listChannelConfig.TabIndex = 0;
            this._listChannelConfig.SelectedIndexChanged += new System.EventHandler(this._listChannelConfig_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.addButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(217, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(614, 46);
            this.panel1.TabIndex = 1;
            // 
            // addButton
            // 
            this.addButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addButton.Location = new System.Drawing.Point(445, 12);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(157, 23);
            this.addButton.TabIndex = 0;
            this.addButton.Text = "Add DAQChannel Config";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // _lblName
            // 
            this._lblName.AutoSize = true;
            this._lblName.Location = new System.Drawing.Point(244, 65);
            this._lblName.Name = "_lblName";
            this._lblName.Size = new System.Drawing.Size(35, 13);
            this._lblName.TabIndex = 2;
            this._lblName.Text = "Name";
            // 
            // _textName
            // 
            this._textName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._textName.Enabled = false;
            this._textName.Location = new System.Drawing.Point(390, 62);
            this._textName.Name = "_textName";
            this._textName.Size = new System.Drawing.Size(429, 20);
            this._textName.TabIndex = 3;
            // 
            // _psiLabel
            // 
            this._psiLabel.AutoSize = true;
            this._psiLabel.Location = new System.Drawing.Point(244, 91);
            this._psiLabel.Name = "_psiLabel";
            this._psiLabel.Size = new System.Drawing.Size(24, 13);
            this._psiLabel.TabIndex = 4;
            this._psiLabel.Text = "PSI";
            // 
            // _txtPSI
            // 
            this._txtPSI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._txtPSI.Enabled = false;
            this._txtPSI.Location = new System.Drawing.Point(719, 88);
            this._txtPSI.Name = "_txtPSI";
            this._txtPSI.Size = new System.Drawing.Size(100, 20);
            this._txtPSI.TabIndex = 5;
            // 
            // _lblOutput
            // 
            this._lblOutput.AutoSize = true;
            this._lblOutput.Location = new System.Drawing.Point(244, 117);
            this._lblOutput.Name = "_lblOutput";
            this._lblOutput.Size = new System.Drawing.Size(65, 13);
            this._lblOutput.TabIndex = 6;
            this._lblOutput.Text = "Output Volts";
            // 
            // _cmbOutput
            // 
            this._cmbOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._cmbOutput.Enabled = false;
            this._cmbOutput.FormattingEnabled = true;
            this._cmbOutput.Items.AddRange(new object[] {
            "0 - 5 Volts",
            ".5 - 4.5 Volts"});
            this._cmbOutput.Location = new System.Drawing.Point(592, 114);
            this._cmbOutput.Name = "_cmbOutput";
            this._cmbOutput.Size = new System.Drawing.Size(227, 21);
            this._cmbOutput.TabIndex = 7;
            // 
            // _lblOffset
            // 
            this._lblOffset.AutoSize = true;
            this._lblOffset.Location = new System.Drawing.Point(244, 144);
            this._lblOffset.Name = "_lblOffset";
            this._lblOffset.Size = new System.Drawing.Size(72, 13);
            this._lblOffset.TabIndex = 8;
            this._lblOffset.Text = "Offset in Volts";
            // 
            // _txtOffset
            // 
            this._txtOffset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._txtOffset.Enabled = false;
            this._txtOffset.Location = new System.Drawing.Point(719, 141);
            this._txtOffset.Name = "_txtOffset";
            this._txtOffset.Size = new System.Drawing.Size(100, 20);
            this._txtOffset.TabIndex = 9;
            // 
            // _lblDefaultChannel
            // 
            this._lblDefaultChannel.AutoSize = true;
            this._lblDefaultChannel.Location = new System.Drawing.Point(244, 170);
            this._lblDefaultChannel.Name = "_lblDefaultChannel";
            this._lblDefaultChannel.Size = new System.Drawing.Size(106, 13);
            this._lblDefaultChannel.TabIndex = 10;
            this._lblDefaultChannel.Text = "Default DAQChannel";
            // 
            // _txtDefaultChannel
            // 
            this._txtDefaultChannel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._txtDefaultChannel.Enabled = false;
            this._txtDefaultChannel.Location = new System.Drawing.Point(719, 167);
            this._txtDefaultChannel.Name = "_txtDefaultChannel";
            this._txtDefaultChannel.Size = new System.Drawing.Size(100, 20);
            this._txtDefaultChannel.TabIndex = 11;
            // 
            // _buttonSave
            // 
            this._buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._buttonSave.Enabled = false;
            this._buttonSave.Location = new System.Drawing.Point(744, 206);
            this._buttonSave.Name = "_buttonSave";
            this._buttonSave.Size = new System.Drawing.Size(75, 23);
            this._buttonSave.TabIndex = 12;
            this._buttonSave.Text = "Save";
            this._buttonSave.UseVisualStyleBackColor = true;
            this._buttonSave.Click += new System.EventHandler(this._buttonSave_Click);
            // 
            // ChannelSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 241);
            this.Controls.Add(this._buttonSave);
            this.Controls.Add(this._txtDefaultChannel);
            this.Controls.Add(this._lblDefaultChannel);
            this.Controls.Add(this._txtOffset);
            this.Controls.Add(this._lblOffset);
            this.Controls.Add(this._cmbOutput);
            this.Controls.Add(this._lblOutput);
            this.Controls.Add(this._txtPSI);
            this.Controls.Add(this._psiLabel);
            this.Controls.Add(this._textName);
            this.Controls.Add(this._lblName);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this._listChannelConfig);
            this.Name = "ChannelSetup";
            this.Text = "ChannelSetup";
            this.Load += new System.EventHandler(this.ChannelSetup_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox _listChannelConfig;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Label _lblName;
        private System.Windows.Forms.TextBox _textName;
        private System.Windows.Forms.Label _psiLabel;
        private System.Windows.Forms.TextBox _txtPSI;
        private System.Windows.Forms.Label _lblOutput;
        private System.Windows.Forms.ComboBox _cmbOutput;
        private System.Windows.Forms.Label _lblOffset;
        private System.Windows.Forms.TextBox _txtOffset;
        private System.Windows.Forms.Label _lblDefaultChannel;
        private System.Windows.Forms.TextBox _txtDefaultChannel;
        private System.Windows.Forms.Button _buttonSave;
    }
}