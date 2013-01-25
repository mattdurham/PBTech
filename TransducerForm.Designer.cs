namespace PBTech
{
    partial class TransducerForm
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
            this.labTransName = new System.Windows.Forms.Label();
            this.textTranName = new System.Windows.Forms.TextBox();
            this.labColor = new System.Windows.Forms.Label();
            this.buttColor = new System.Windows.Forms.Button();
            this.labChannelNum = new System.Windows.Forms.Label();
            this.textChanNum = new System.Windows.Forms.TextBox();
            this.labMaxPsi = new System.Windows.Forms.Label();
            this.textMaxPSI = new System.Windows.Forms.TextBox();
            this.buttSave = new System.Windows.Forms.Button();
            this.colorTran = new System.Windows.Forms.ColorDialog();
            this.SuspendLayout();
            // 
            // labTransName
            // 
            this.labTransName.AutoSize = true;
            this.labTransName.Location = new System.Drawing.Point(12, 32);
            this.labTransName.Name = "labTransName";
            this.labTransName.Size = new System.Drawing.Size(95, 13);
            this.labTransName.TabIndex = 0;
            this.labTransName.Text = "Transducer Name:";
            // 
            // textTranName
            // 
            this.textTranName.Location = new System.Drawing.Point(113, 29);
            this.textTranName.Name = "textTranName";
            this.textTranName.Size = new System.Drawing.Size(234, 20);
            this.textTranName.TabIndex = 1;
            // 
            // labColor
            // 
            this.labColor.AutoSize = true;
            this.labColor.Location = new System.Drawing.Point(12, 63);
            this.labColor.Name = "labColor";
            this.labColor.Size = new System.Drawing.Size(34, 13);
            this.labColor.TabIndex = 2;
            this.labColor.Text = "Color:";
            // 
            // buttColor
            // 
            this.buttColor.Location = new System.Drawing.Point(113, 58);
            this.buttColor.Name = "buttColor";
            this.buttColor.Size = new System.Drawing.Size(75, 23);
            this.buttColor.TabIndex = 3;
            this.buttColor.Text = "Color!";
            this.buttColor.UseVisualStyleBackColor = true;
            this.buttColor.Click += new System.EventHandler(this.buttColor_Click);
            // 
            // labChannelNum
            // 
            this.labChannelNum.AutoSize = true;
            this.labChannelNum.Location = new System.Drawing.Point(12, 93);
            this.labChannelNum.Name = "labChannelNum";
            this.labChannelNum.Size = new System.Drawing.Size(89, 13);
            this.labChannelNum.TabIndex = 4;
            this.labChannelNum.Text = "Channel Number:";
            // 
            // textChanNum
            // 
            this.textChanNum.Location = new System.Drawing.Point(113, 87);
            this.textChanNum.Name = "textChanNum";
            this.textChanNum.Size = new System.Drawing.Size(234, 20);
            this.textChanNum.TabIndex = 5;
            this.textChanNum.Text = "0";
            // 
            // labMaxPsi
            // 
            this.labMaxPsi.AutoSize = true;
            this.labMaxPsi.Location = new System.Drawing.Point(12, 120);
            this.labMaxPsi.Name = "labMaxPsi";
            this.labMaxPsi.Size = new System.Drawing.Size(132, 13);
            this.labMaxPsi.TabIndex = 6;
            this.labMaxPsi.Text = "Max Pressure Recordable:";
            // 
            // textMaxPSI
            // 
            this.textMaxPSI.Location = new System.Drawing.Point(150, 117);
            this.textMaxPSI.Name = "textMaxPSI";
            this.textMaxPSI.Size = new System.Drawing.Size(197, 20);
            this.textMaxPSI.TabIndex = 7;
            this.textMaxPSI.Text = "1000";
            // 
            // buttSave
            // 
            this.buttSave.Location = new System.Drawing.Point(272, 143);
            this.buttSave.Name = "buttSave";
            this.buttSave.Size = new System.Drawing.Size(75, 23);
            this.buttSave.TabIndex = 8;
            this.buttSave.Text = "Save";
            this.buttSave.UseVisualStyleBackColor = true;
            this.buttSave.Click += new System.EventHandler(this.buttSave_Click_1);
            // 
            // TransducerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 185);
            this.Controls.Add(this.buttSave);
            this.Controls.Add(this.textMaxPSI);
            this.Controls.Add(this.labMaxPsi);
            this.Controls.Add(this.textChanNum);
            this.Controls.Add(this.labChannelNum);
            this.Controls.Add(this.buttColor);
            this.Controls.Add(this.labColor);
            this.Controls.Add(this.textTranName);
            this.Controls.Add(this.labTransName);
            this.Name = "TransducerForm";
            this.Text = "Transducer Record";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labTransName;
        private System.Windows.Forms.TextBox textTranName;
        private System.Windows.Forms.Label labColor;
        private System.Windows.Forms.Button buttColor;
        private System.Windows.Forms.Label labChannelNum;
        private System.Windows.Forms.TextBox textChanNum;
        private System.Windows.Forms.Label labMaxPsi;
        private System.Windows.Forms.TextBox textMaxPSI;
        private System.Windows.Forms.Button buttSave;
        private System.Windows.Forms.ColorDialog colorTran;
    }
}