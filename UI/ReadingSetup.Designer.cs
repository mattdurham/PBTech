namespace PBTech
{
    partial class ReadingSetup
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
            this._channelList = new System.Windows.Forms.CheckedListBox();
            this._cancelButton = new System.Windows.Forms.Button();
            this._saveButton = new System.Windows.Forms.Button();
            this._lblName = new System.Windows.Forms.Label();
            this._lblDescription = new System.Windows.Forms.Label();
            this._txtName = new System.Windows.Forms.TextBox();
            this._txtDescription = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // _channelList
            // 
            this._channelList.Dock = System.Windows.Forms.DockStyle.Right;
            this._channelList.FormattingEnabled = true;
            this._channelList.Location = new System.Drawing.Point(492, 0);
            this._channelList.Name = "_channelList";
            this._channelList.Size = new System.Drawing.Size(144, 319);
            this._channelList.TabIndex = 0;
            // 
            // _cancelButton
            // 
            this._cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._cancelButton.Location = new System.Drawing.Point(12, 284);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(86, 23);
            this._cancelButton.TabIndex = 1;
            this._cancelButton.Text = "Cancel";
            this._cancelButton.UseVisualStyleBackColor = true;
            this._cancelButton.Click += new System.EventHandler(this._cancelButton_Click);
            // 
            // _saveButton
            // 
            this._saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._saveButton.Location = new System.Drawing.Point(411, 284);
            this._saveButton.Name = "_saveButton";
            this._saveButton.Size = new System.Drawing.Size(75, 23);
            this._saveButton.TabIndex = 2;
            this._saveButton.Text = "Save";
            this._saveButton.UseVisualStyleBackColor = true;
            this._saveButton.Click += new System.EventHandler(this._saveButton_Click);
            // 
            // _lblName
            // 
            this._lblName.AutoSize = true;
            this._lblName.Location = new System.Drawing.Point(12, 9);
            this._lblName.Name = "_lblName";
            this._lblName.Size = new System.Drawing.Size(35, 13);
            this._lblName.TabIndex = 3;
            this._lblName.Text = "Name";
            // 
            // _lblDescription
            // 
            this._lblDescription.AutoSize = true;
            this._lblDescription.Location = new System.Drawing.Point(12, 37);
            this._lblDescription.Name = "_lblDescription";
            this._lblDescription.Size = new System.Drawing.Size(60, 13);
            this._lblDescription.TabIndex = 4;
            this._lblDescription.Text = "Description";
            // 
            // _txtName
            // 
            this._txtName.Location = new System.Drawing.Point(78, 6);
            this._txtName.Name = "_txtName";
            this._txtName.Size = new System.Drawing.Size(408, 20);
            this._txtName.TabIndex = 5;
            // 
            // _txtDescription
            // 
            this._txtDescription.Location = new System.Drawing.Point(15, 54);
            this._txtDescription.Multiline = true;
            this._txtDescription.Name = "_txtDescription";
            this._txtDescription.Size = new System.Drawing.Size(471, 224);
            this._txtDescription.TabIndex = 6;
            // 
            // ReadingSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 319);
            this.Controls.Add(this._txtDescription);
            this.Controls.Add(this._txtName);
            this.Controls.Add(this._lblDescription);
            this.Controls.Add(this._lblName);
            this.Controls.Add(this._saveButton);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this._channelList);
            this.Name = "ReadingSetup";
            this.Text = "ReadingSetup";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox _channelList;
        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.Button _saveButton;
        private System.Windows.Forms.Label _lblName;
        private System.Windows.Forms.Label _lblDescription;
        private System.Windows.Forms.TextBox _txtName;
        private System.Windows.Forms.TextBox _txtDescription;
    }
}