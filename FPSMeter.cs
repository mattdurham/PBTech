using System;
using System.Collections.Generic;
using System.Text;

namespace PBTech
{
    public class FPSMeter
    {
        #region Private Variable
        private string _name;
        private string _id;
        private FPSPoint[] _points;
        private float _distInches;
        #endregion

        #region Public Accessors
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public float DistanceInches
        {
            get { return _distInches;}
            set { _distInches = value;}
        }

        public string ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public FPSPoint[] Points
        {
            get { return _points; }
            set { _points = value; }
        }

        public float MaxFPS
        {
            get { return GetMaxFPS(); }
        }

        public float AvgFPS
        {
            get { return GetAvgFPS(); }
        }

        public float LowFPS
        {
            get { return GetLowFPS(); }
        }

        public float RangeFPS
        {
            get { return (MaxFPS - LowFPS); }
        }

        /// <summary>
        /// Gets the highest FPS from a set
        /// </summary>
        /// <returns>The highest FPS</returns>
        private float GetMaxFPS()
        {
            float maxFPS = 0; 
            for (int i = 0; i < _points.Length; i++)
            {
                if (_points[i].GetFPS() > maxFPS)
                    maxFPS = _points[i].GetFPS();

            }
            return maxFPS;
        }

        /// <summary>
        /// Gets the lowest FPS from a set
        /// </summary>
        /// <returns>The lowest FPS</returns>
        private float GetLowFPS()
        {
            float lowFPS = _points[1].GetFPS();
            for (int i = 1; i < _points.Length; i++)
            {
                if (_points[i].GetFPS() < lowFPS)
                    lowFPS = _points[i].GetFPS();

            }
            return lowFPS;
        }

        /// <summary>
        /// Retrieves the average FPS
        /// </summary>
        /// <returns></returns>
        private float GetAvgFPS()
        {
            float total = 0;
            for (int i = 0; i < _points.Length; i++)
                total += _points[i].GetFPS();
            return total / _points.Length;

        }

        #endregion

        /// <summary>
        /// Raw Time Holder
        /// </summary>
        public class FPSPoint
        {
            public DateTime Time1; //Time ball crosses reader one
            public DateTime Time2; //Time ball cross reader two
            public float distInches; //Distance between readers
            public FPSPoint()
            {

            }
            public FPSPoint(DateTime time1, DateTime time2, float distanceInches)
            {
                Time1 = time1;
                Time2 = time2;
                distInches = distanceInches;
            }
            public float GetFPS()
            {
                TimeSpan timeSpan =Time2.Subtract(Time1);
               //A tick is 100 nanoseconds, there are 1,000,000 nanoseconds in a millesecond, therefore each millesecond is equal to 10,000 nanos
                // and each second as 100000000 ticks
                return (timeSpan.Ticks / 100000000)  * distInches / 12 ; 
            }
        }

        

    }
}
