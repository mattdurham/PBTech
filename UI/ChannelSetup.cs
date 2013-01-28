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
    public partial class ChannelSetup : Form
    {
        Database _db;
        List<ChannelConfig> _configs = new List<ChannelConfig>();

        public ChannelSetup()
        {
            InitializeComponent();
        }

        public ChannelSetup(Database db)
        {
            InitializeComponent();
            _db = db;
        }

        private void ChannelSetup_Load(object sender, EventArgs e)
        {
            _configs.AddRange(_db.GetChannelConfigs());
            foreach (ChannelConfig config in _configs)
            {
                _listChannelConfig.Items.Add(config);
            }

        }

        private void addButton_Click(object sender, EventArgs e)
        {
            FlipFieldsTo(true);
            _textName.Text = "";
            _txtDefaultChannel.Text = "";
            _txtOffset.Text = "";
            _cmbOutput.SelectedIndex = 0;
            _txtPSI.Text = "";
            _buttonSave.Enabled = true;
        }

        private void FlipFieldsTo(bool enabled)
        {
            _textName.Enabled = enabled;
            _txtDefaultChannel.Enabled = enabled;
            _txtOffset.Enabled = enabled;
            _cmbOutput.Enabled = enabled;
            _txtPSI.Enabled = enabled;
        }

        private void _listChannelConfig_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChannelConfig cc = (ChannelConfig)_listChannelConfig.SelectedItem;
            FlipFieldsTo(false);
            FillFields(cc);
        }

        private void FillFields(ChannelConfig cc)
        {
            _textName.Text = cc.Name;
            _txtDefaultChannel.Text = cc.DefaultChannel.ToString();
            _txtOffset.Text = cc.Offset.ToString();
            _cmbOutput.SelectedIndex = 0;
            _txtPSI.Text = cc.PSI.ToString();
        }

        private void _buttonSave_Click(object sender, EventArgs e)
        {
            int channel = 0;
            if (!Int32.TryParse(_txtDefaultChannel.Text, out channel))
            {
                MessageBox.Show("Default DAQChannel must be a whole number");
                return;
            }

            float offset = 0;
            if (!float.TryParse(_txtOffset.Text, out offset))
            {
                MessageBox.Show("Offset must be a number");
                return;
            }
            
            int psi = 0;
            if (!Int32.TryParse(_txtPSI.Text, out psi))
            {
                MessageBox.Show("PSI needs to be a number");
                return;
            }

            ChannelConfig cc = _db.CreateChannelConfig(_textName.Text, psi, OutputVoltRange.ZeroToFiveVolts, offset, channel);
            _listChannelConfig.Items.Add(cc);
        }
    }
}
