using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Threading;
using ZedGraph;
using System.Data.SQLite;
using MccDaq;
using OfficeOpenXml.Table;
using System.IO;
using OfficeOpenXml;





namespace PBTech
{
    public partial class MainForm : Form
    {
        
        Thread _readingThread;
        IDAQInterface _daqInterface;
        bool _reading = false;
        Database _db;
        Reading _currentReading;
        MccDaq.MccBoard _peekBoard;
        ChannelConfig _defaultChannel;

        public MainForm()
        { 
            InitializeComponent();
            peekPress.Start();
            _db = new Database(Properties.Settings.Default.DEFAULT_DB_PATH);
            
            foreach (Reading r in _db.GetReadings())
            {
                _listReadings.Items.Add(r);
            }

            ZedGraph.GraphPane pane = graphTrans.GraphPane;
            pane.Title.Text = "Transducer";
            pane.XAxis.Title.Text = " Time (ms) ";
            pane.YAxis.Title.Text = " Pressure (psi) ";
            pane.YAxis.Scale.Max = 1000;
            pane.YAxis.Scale.Min = 0;
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReadingSetup rs = new ReadingSetup(_db);
            if (rs.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }
            peekPress.Stop();
            graphTrans.GraphPane.CurveList.Clear();
            graphTrans.AxisChange();
            graphTrans.Refresh();
            _listReadings.Items.Add(rs.Reading);
            _listReadings.SelectedItem = _reading;
            _listReadings.Enabled = false;
            _currentReading = rs.Reading;
            if(_currentReading == null)
            {
                MessageBox.Show("Start a new reading");
                return;
            }
            _reading = true;
            _daqInterface = new DAQReader();
            List<DAQ> daqChannel = new List<DAQ>();
            foreach (DAQChannel ch in _currentReading.ChannelList)
            {
                graphTrans.GraphPane.AddCurve(ch.Config.Name, null, Color.Red, ZedGraph.SymbolType.None);
            }
            _daqInterface.Setup(new DataRetrieved(RetrievedData), _currentReading.ChannelList.ToArray());
            _readingThread = new Thread(new ThreadStart(_daqInterface.StartReading));
            _readingThread.Start();
        }


        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _daqInterface.StopReading(new StopFinished(ThreadHasFinished));
        }

        private void ThreadHasFinished()
        {
            if (_listReadings.InvokeRequired)
            {
                _listReadings.Invoke(new StopFinished(ThreadHasFinished));
                return;
            }
            _db.BeginTransaction();
            foreach (DAQChannel ch in _currentReading.ChannelList)
            {
                foreach (ReadingDetail rd in ch.ReadingDetails)
                {
                    _db.SaveReadingDetail(rd);
                }
            }
            _db.CommitTransaction();
            _listReadings.Enabled = true;
            peekPress.Start();
        }

        /// <summary>
        /// Quick peek at the volts
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void peekPress_Tick(object sender, EventArgs e)
        {
            try
            {
                if (_peekBoard == null)
                {
                    _peekBoard = new MccDaq.MccBoard();
                }
                short dValue;
                ErrorInfo ei = _peekBoard.AIn(0, MccDaq.Range.Bip5Volts, out dValue);
                float engVal;
                MccDaq.ErrorInfo info = _peekBoard.ToEngUnits(MccDaq.Range.Bip5Volts, dValue, out engVal);
                
                if (engVal < 0)
                {
                    engVal = -1;
                }
                else
                {
                    if (_defaultChannel == null)
                    {
                        foreach (ChannelConfig dq in _db.GetChannelConfigs())
                        {
                            if (dq.DefaultChannel == 0)
                            {
                                _defaultChannel = dq;
                                break;
                            }
                        }
                    }
                    if (_defaultChannel != null)
                    {
                        labelPSI.Text = Convert.ToInt32(_defaultChannel.GetPsi(engVal)).ToString() + " psi";
                    }
                    else
                    {
                        labelPSI.Text = engVal.ToString() + " psi";
                    }
                }
            }
            catch (Exception ex)
            {
                labelPSI.Text = "Error occurred " + ex.ToString();
            }
            
        }

   
        private void startTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _reading = true;
            graphTrans.GraphPane.CurveList.Clear();
            graphTrans.AxisChange();
            graphTrans.Refresh();
            DAQTestHarness.DAQTest daTest1 = new DAQTestHarness.DAQTest(0);
            LineItem lItem = graphTrans.GraphPane.AddCurve("Test", null, Color.Red, ZedGraph.SymbolType.None);
            _daqInterface = new DAQTestHarness.DAQInterfaceTest();
            _daqInterface.Setup(new DataRetrieved(RetrievedData), new IDAQ[] { daTest1 });
            DataRetrieved dataRetrieved = new DataRetrieved(RetrievedData);
            _readingThread = new Thread(new ThreadStart(_daqInterface.StartReading));
            _readingThread.Start();
        }

        private void RetrievedData(Dictionary<IDAQ, IDAQPoint[]> readings)
        {
            if (this.InvokeRequired)
            {
                lock (this)
                {
                    if (!_reading)
                    {
                        return;
                    }
                    DataRetrieved dr = new DataRetrieved(RetrievedData);
                    this.Invoke(dr, new object[] { readings });
                    return;
                }
            }
            if (!_reading)
            {
                return;
            }

            graphTrans.GraphPane.Legend.IsVisible = true;
            int curveListIndex = 0;
            foreach (KeyValuePair<IDAQ, IDAQPoint[]> readingItem in readings)
            {
                foreach (IDAQPoint point in readingItem.Value)
                {
                    
                    graphTrans.GraphPane.CurveList[curveListIndex].AddPoint(point.Time, point.PSI);
                }
                curveListIndex++;

            }
            graphTrans.AxisChange();
            graphTrans.Refresh();
            
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            peekPress.Stop();
            lock (this)
            {
                if (_daqInterface != null)
                {
                    _daqInterface.StopReading(new StopFinished(ThreadHasFinished));
                }
                _reading = false;
            }
        }

        private void channelSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChannelSetup cs = new ChannelSetup(_db);
            cs.ShowDialog();
        }

        private void _listReadings_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_listReadings.SelectedItem == null)
            {
                return;
            }
            _currentReading = (Reading)_listReadings.SelectedItem;
            graphTrans.GraphPane.CurveList.Clear();
            graphTrans.GraphPane.Legend.IsVisible = true;
            int curveListIndex = 0;
            foreach (DAQChannel ch in _currentReading.ChannelList)
            {
                lock (ch)
                {
                    graphTrans.GraphPane.AddCurve(ch.Config.Name, null, Color.Red, ZedGraph.SymbolType.None);
                    foreach (ReadingDetail rd in ch.ReadingDetails)
                    {
                        graphTrans.GraphPane.CurveList[curveListIndex].AddPoint(rd.Time, rd.PSI);
                    }
                    curveListIndex++;
                }
            }
            graphTrans.AxisChange();
            graphTrans.Refresh();
        }

        private void saveSelectedToExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_currentReading == null)
            {
                return;
            }
            FileInfo newFile = new FileInfo(_currentReading.Name + ".xlsx");

            ExcelPackage pck = new ExcelPackage(newFile);
            //Add the Content sheet
            var ws = pck.Workbook.Worksheets.Add(_currentReading.Name);
            int columnIndex = 1;
            ws.InsertRow(1, _currentReading.ChannelList[0].ReadingDetails.Count);
            foreach (DAQChannel ch in _currentReading.ChannelList)
            {
                ws.Cells[1, columnIndex].Value = ch.Config.Name;
                columnIndex++;
            }
            columnIndex = 1;
            int rowIndex = 2;
            foreach (DAQChannel ch in _currentReading.ChannelList)
            {
                foreach (ReadingDetail reading in ch.ReadingDetails)
                {
                    ws.Cells[rowIndex, columnIndex].Value = reading.PSI;
                    rowIndex++;
                }
                rowIndex = 2;
                columnIndex++;
            }
            pck.Save();
        }

    }
}