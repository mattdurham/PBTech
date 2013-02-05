using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PBTech
{
    class DAQReader : IDAQInterface
    {
        IDAQ[] _daqs;
        DataRetrieved _dataRetrieved;
        volatile bool _continueReading = true;
        const int SCAN_RATE = 1000;
        StopFinished _stopFinishedCallback;
        #region IDAQInterface Members

        public void Setup(DataRetrieved dataRetrieved, IDAQ[] daqs)
        {
            _daqs = daqs;
            _dataRetrieved = dataRetrieved;
        }

        public void StartReading()
        {
            //We always want to read SCAN_RATE samples per channel
            int scanRate = _daqs.Length * SCAN_RATE;
            int iteration = 0;
            while (_continueReading)
            {
                int memHandle = MccDaq.MccService.WinBufAlloc(scanRate);
                MccDaq.MccBoard theBoard = new MccDaq.MccBoard(0);
                ushort[] buffer = new ushort[scanRate];
                float[] outVal = new float[(int)scanRate];
                MccDaq.ErrorInfo stat = new MccDaq.ErrorInfo();
                int scannedRate = 1000;
                stat = theBoard.AInScan(0, _daqs.Length - 1, scanRate, ref scannedRate, MccDaq.Range.Bip5Volts, memHandle, MccDaq.ScanOptions.Default);
                stat = MccDaq.MccService.WinBufToArray(memHandle, out buffer[0], 0, scanRate);
                for (int i = 0; i < buffer.Length; i++)
                {
                    theBoard.ToEngUnits(MccDaq.Range.Bip5Volts, buffer[i], out outVal[i]);
                }
                MccDaq.MccService.WinBufFree(memHandle);

                
                Dictionary<IDAQ, IDAQPoint[]> readingDictionary = new Dictionary<IDAQ, IDAQPoint[]>();
                foreach (IDAQ daq in _daqs)
                {
                    readingDictionary.Add(daq, new IDAQPoint[SCAN_RATE]);
                }

                for (int i = 0; i < scanRate;)
                {
                    foreach (IDAQ daq in _daqs)
                    {
                        DAQChannel chDaq = (DAQChannel)daq;
                        ReadingDetail rd = new ReadingDetail();
                        int currentIndex = i / _daqs.Length;
                        rd.ParentChannel = chDaq;
                        rd.Time = currentIndex + (iteration * SCAN_RATE);
                        rd.Reading = outVal[i];
                        readingDictionary[daq][currentIndex] = rd;
                        i++;
                    }
                }
                iteration++;
                _dataRetrieved(readingDictionary);
            }
            lock (this)
            {
                _stopFinishedCallback();
            }
        }

        public void StopReading(StopFinished stopFinishedCallback)
        {
            _continueReading = false;
            _stopFinishedCallback = stopFinishedCallback;
        }



        #endregion

        private class DAQPoint : IDAQPoint
        {
            float _reading;
            int _channel;
            int _time;

            public DAQPoint(float reading, int channel, int time)
            {
                _reading = reading;
                _channel = channel;
                _time = time;
            }

            public override string ToString()
            {
                return _time.ToString() + " : " + _reading.ToString();
            }


            #region IDAQPoint Members

            public float Reading
            {
                get
                {
                    return _reading;
                }
            }

            public int Channel
            {
                get
                {
                    return _channel;
                }
            }

            public int Time
            {
                get
                {
                    return _time;
                }
            }

            public float PSI
            {
                get
                {
                    return _reading;
                }
            }

            #endregion
        }

       
    }
}
