#region Using directives

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Windows;

#endregion

namespace PBTech
{
    /// <summary>
    /// Class used for all DAQ functions
    /// </summary>
    public class DAQRead
    {
        public delegate void transCallback( List<float> listArr);
        private int BoardNum;
        private int firstChan;
        private int lastChan;
        private MccDaq.Range tranRange;
        private int scanRate;
        private List<float> tranArr;
        private transCallback thisCallback;
        private Int64 timer;
        private DateTime timeToEnd;
        /// <summary>
        /// Used to instantiate the class and setup the basic parameters.
        /// </summary>
        /// <param name="boardnum">The board number as setup via the MMCDAQ software</param>
        /// <param name="firstchan">The first channel to pole</param>
        /// <param name="lastchan">The last channel to pole</param>
        /// <param name="range">The range that th DAQ will be reading, more than likely 0-5v</param>
        /// <param name="scan">Scan Rate</param>
        /// <param name="array">An array to return</param>
        /// <param name="tranCall">Callback function to support psuedo real time operations</param>
        /// <param name="timeToLast">How long the system should read, 0 for foerever</param>
        public DAQRead(int boardnum, int firstchan, int lastchan, MccDaq.Range range, int scan, ref List<float> array, transCallback tranCall, Int64 timeToLast)
        {
            BoardNum = boardnum;
            firstChan = firstchan;
            lastChan = lastchan;
            tranRange = range;
            scanRate = scan;
            tranArr = array;
            thisCallback = tranCall;
            timer = timeToLast;
            timeToEnd = DateTime.Now.AddMilliseconds(timer);

        }
        /// <summary>
        /// Starts the Reading
        /// </summary>
        public void DAQStartRead()
        {
            int MemHandle = 0;
            while ((timer == 0 || DateTime.Now.Millisecond < timeToEnd.Millisecond))
            {

                MemHandle = MccDaq.MccService.WinBufAlloc(scanRate);
                MccDaq.MccBoard theBoard = new MccDaq.MccBoard(BoardNum);
                ushort[] buffer = new ushort[(int)scanRate];
                float[] outVal = new float[(int)scanRate];
                MccDaq.ErrorInfo Stat = new MccDaq.ErrorInfo();
                int rate = 1000;
                Stat = theBoard.AInScan(firstChan, lastChan, scanRate, ref rate, tranRange, MemHandle, MccDaq.ScanOptions.Default);
                Stat = MccDaq.MccService.WinBufToArray(MemHandle, out buffer[0], 0, buffer.Length);
                for (int i = 0; i < buffer.Length; i++)
                {
                    theBoard.ToEngUnits(tranRange, buffer[i], out outVal[i]);
                    outVal[i] = outVal[i];
                    tranArr.Add(outVal[i]);
                }
                MccDaq.MccService.WinBufFree(MemHandle);
                thisCallback( tranArr);
                tranArr.Clear();
            }
            
        }




        }

       
}

