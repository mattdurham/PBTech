using System;
using System.Collections.Generic;
using System.Text;

namespace PBTech
{
    public class DAQTestHarness
    {
        public class DAQTest : DAQ
        {
            public DAQTest(int channel) : base(channel)
            {

            }
        }

        public class DAQInterfaceTest : IDAQInterface
        {
            IDAQ[] _daqArray;
            volatile bool _read = true;
            DataRetrieved _dataRetrieved;

            #region IDAQInterface Members
           
            public void Setup(DataRetrieved dataRetrieved, IDAQ[] daqs)
            {
                _daqArray = daqs;
                _dataRetrieved = dataRetrieved;
            }

            /// <summary>
            /// This method create some random seeds, then fills each daq value with variations from the seed
            /// </summary>
            /// <param name="dataRetrieved"></param>
            /// <param name="daqs"></param>
            public void StartReading()
            {
               
                Dictionary<IDAQ, int> idaqSeed = new Dictionary<IDAQ, int>();
                foreach (IDAQ daq in _daqArray)
                {
                    System.Random random = new Random();
                    int seed = random.Next(100,300);
                    idaqSeed.Add(daq, seed);
                }
                Dictionary<IDAQ, int> currentReadingTimeDictionary = new Dictionary<IDAQ, int>();
                foreach (IDAQ daq in _daqArray)
                {
                    currentReadingTimeDictionary.Add(daq, 0);
                }
                while (_read)
                {
                    
                    Dictionary<IDAQ,IDAQPoint[]> pointsInDAQ = new Dictionary<IDAQ,IDAQPoint[]>();
                    foreach(IDAQ daq in _daqArray)
                    {
                        IDAQPoint[] points = new IDAQPoint[1000];
                        System.Random random = new Random();
                        for (int i = 0; i < 1000; i++)
                        {
                            int currentReadingTime = currentReadingTimeDictionary[daq];
                            float previous = i == 0 ? idaqSeed[daq] : points[i - 1].Reading;
                            int readingAdjustment = random.Next(-20, 20);
                            float reading = previous + readingAdjustment;
                            DAQTestPoint point = new DAQTestPoint(reading, daq.Channel, currentReadingTime);
                            points[i] = point;
                            currentReadingTimeDictionary[daq]++;
                        }
                        pointsInDAQ.Add(daq, points);
                    }
                    System.Threading.Thread.Sleep(1000);
                    _dataRetrieved(pointsInDAQ);
                }
            }

            public void StopReading()
            {
                _read = false;
            }

            #endregion

           
        }

        public class DAQTestPoint : IDAQPoint
        {
            float _reading;
            int _channel;
            int _time;

            public DAQTestPoint(float reading, int channel, int time)
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

            #endregion
        }
    }
}
