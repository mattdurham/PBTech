using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PBTech
{
    public partial class TransducerForm : Form
    {
        public Transducer tran;
        public TransducerForm()
        {
            InitializeComponent();
            tran = new Transducer();
        }
        public TransducerForm(Transducer Tran)
        {
            InitializeComponent();
            tran = Tran;
            this.textChanNum.Text = tran.TransChannel.ToString();
            this.buttColor.ForeColor = tran.TransColor;
            this.textMaxPSI.Text = tran.TransMaxPsi.ToString();
            this.textTranName.Text = tran.TransName;

        }

        private void buttColor_Click(object sender, EventArgs e)
        {
            colorTran.ShowDialog();
            tran.TransColor = colorTran.Color;
            this.buttColor.ForeColor = colorTran.Color;

        }

        private void buttSave_Click_1(object sender, EventArgs e)
        {
            tran.TransChannel = Convert.ToInt16(this.textChanNum.Text);
            tran.TransColor = buttColor.ForeColor;
            tran.TransMaxPsi = Convert.ToInt32(this.textMaxPSI.Text);
            tran.TransName = this.textTranName.Text;
            this.Close();
        }
    }
}