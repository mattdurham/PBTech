using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PBTech
{
    public partial class ReadingSetup : Form
    {
        Database _db;
        Reading _reading;

        public ReadingSetup()
        {
            InitializeComponent();
        }

        public ReadingSetup(Database db)
        {
            InitializeComponent();
            _db = db;
            foreach (ChannelConfig cc in _db.GetChannelConfigs())
            {
                _channelList.Items.Add(cc);
            }
        }

        public Reading Reading
        {
            get
            {
                return _reading;
            }
        }

        private void _saveButton_Click(object sender, EventArgs e)
        {
            if (_channelList.SelectedIndices.Count == 0)
            {
                MessageBox.Show("Must select a channel");
                return;
            }
            if (_txtName.Text.Length == 0)
            {
                MessageBox.Show("Must enter a name");
                return;
            }
            _reading = _db.CreateReading(_txtName.Text, _txtDescription.Text);
            foreach(object obj in _channelList.CheckedItems)
            {
                ChannelConfig cc = (ChannelConfig)obj;
                _db.CreateChannelForReading(_reading, cc, "", cc.DefaultChannel);
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void _cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }
    }
}
