using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Threading;




namespace PBTech
{
    public partial class MainForm : Form
    {
        private DAQRead.transCallback _callback;
        Thread _daqThread;
        private Transducer _transducer;
        DAQRead _dq;
        List<Transducer> _activeTransList;
       
        public MainForm()
        { 
            InitializeComponent();
            peekPress.Start();
            _callback = new DAQRead.transCallback(UpdateList);
            _activeTransList = new List<Transducer>();
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            peekPress.Stop();
            _transducer = new Transducer();
            _transducer.TransName = "";
            _transducer.TransChannel = 0;
            _transducer.Visible = true;
            List<float> list = new List<float>();
            _dq = new DAQRead(0, 0, -1+_activeTransList.Count, MccDaq.Range.Bip5Volts, 1000 * _activeTransList.Count, ref list, _callback, 0);
            ZedGraph.GraphPane pane = graphTrans.GraphPane;
            pane.Title = "Transducer";
            pane.XAxis.Title = " Time (ms) " ;
            pane.YAxis.Title = " Pressure (psi) " ;
            pane.YAxis.Max = 1000;
            pane.YAxis.Min = 0;
            foreach(Transducer tran in _activeTransList)
            {
                graphTrans.GraphPane.AddCurve(tran.TransName, null, tran.TransColor,ZedGraph.SymbolType.None);
            }
            pane.Legend.IsVisible = true;
            _daqThread = new Thread(new ThreadStart(_dq.DAQStartRead));
            _daqThread.Priority = ThreadPriority.AboveNormal;
            timeDraw.Start();
            _daqThread.Start();
            //_dq.DAQStartRead();
        }

        private void UpdateList( List<float> list)
        {
            List<float> tempList = new List<float>();
            
            lock (list)
            {
                tempList.AddRange(list.ToArray());
            }
            lock (_activeTransList)
            {
                int currentTran = 0;
                for (int i = 0; i < tempList.Count; i++)
                {
                    Transducer trans = _activeTransList[currentTran];
                    float val = tempList[i];
                    val = val * trans.TransMaxPsi / 5;
                    TranRes.Pnt pnt = new TranRes.Pnt();
                    pnt.Result = val;
                    pnt.Position = trans.TransPoints.Count + 1;
                    trans.TransPoints.AddPoint(pnt);
                    currentTran++;
                    if (currentTran == _activeTransList.Count)
                    {
                        currentTran = 0;
                    }
                }
            }
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_daqThread != null)
            {
                _daqThread.Abort();
            }
            foreach (TreeNode node in sideView.Nodes)
            {
                node.Nodes.Clear();
                node.Nodes.Add("Avg: " + ((Transducer)node.Tag).Avg.ToString());
                node.Nodes.Add("High: " + ((Transducer)node.Tag).Hi.ToString());
                node.Nodes.Add("Low: " + ((Transducer)node.Tag).Low.ToString());
            }
            timeDraw.Stop();
            peekPress.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            lock (_activeTransList)
            {                   
                for (int t = 0; t < _activeTransList.Count; t++)
                {
                    Transducer transd = _activeTransList[t];
                    transd = _activeTransList[t] as Transducer;
                    for (int i = transd.LastPoint; i < transd.TransPoints.Count; i++)
                    {
                        TranRes.Pnt pnt = transd.TransPoints[i];
                        graphTrans.GraphPane.CurveList[t].AddPoint(pnt.Position,pnt.Result);
                        transd.LastPoint++;
                    } 
                }
            }

            graphTrans.GraphPane.Legend.IsVisible = true;
            graphTrans.AxisChange();
            graphTrans.Refresh();
        
        }

        /// <summary>
        /// Quick peek at the volts
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void peekPress_Tick(object sender, EventArgs e)
        {
            MccDaq.MccBoard theBoard = new MccDaq.MccBoard(0);
            short dValue;
            theBoard.AIn(0,MccDaq.Range.Bip5Volts,out dValue);
            float engVal;
            MccDaq.ErrorInfo info = theBoard.ToEngUnits(MccDaq.Range.Bip5Volts, dValue, out engVal);
            if (engVal < 0)
            {
                engVal = -1;
            }
            if (_activeTransList.Count > 0)
            {
                engVal = engVal * _activeTransList[0].TransMaxPsi / 5;
                labelPSI.Text = engVal.ToString() + " volts";
            }
            else
            {
                labelPSI.Text = engVal.ToString() + " psi";
            }
            
        }

      

        private void saveGraphToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.IO.StreamWriter write = new System.IO.StreamWriter("c:\\output.txt");
            foreach (Transducer tran in _activeTransList)
            {
                write.WriteLine(tran.TransName + "\t" + tran.TransMaxPsi);
                for (int i = 0; i < tran.TransPoints.Count; i++)
                {
                    TranRes.Pnt p = tran.TransPoints[i];
                    write.WriteLine(p.Position.ToString() + "\t" + p.Result.ToString());
                }
            }
            write.Close();
        }

        private void configurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TransducerForm tranForm = new TransducerForm();
            tranForm.ShowDialog();
            _activeTransList.Add(tranForm.tran);
            TreeNode node = new TreeNode(tranForm.tran.TransName);
            node.Tag = tranForm.tran;
            sideView.Nodes.Add(node);
        }

        
    }
}