using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using PBTech;

namespace PBTech
{
    /// <summary>
    /// This concerns itself only with BPS, so it just needs to pass the list to add to the current list. 
    /// </summary>
    public class BPSMeter
    {

        public BPSMeter(Chronograph.ChronoStruct[] list, string name, string id)
        {
            BPSPoint[] tempBPS = new BPSPoint[this._points.Length + list.Length];
            for(int i = 0; i < Points.Length;i++)
            {
                tempBPS[i] = this._points[i];
            }
            for (int i = this._points.Length; i < list.Length + _points.Length; i++)
            {
                tempBPS[i] = this._points[i];
            }
            _points = tempBPS;

            this.Name = name;
            this.ID = id;
            

        }
        #region Private Variables
        private BPSPoint[] _points;
        private string _name;
        private string _id;
        private Int32 _reads;
        #endregion

        #region Public Accessors
        public BPSPoint[] Points
        {
            get { return _points; }
            set { _points = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public Int32 Reads
        {
            get { return _reads; }
            set { _reads = value; }
        }

        #endregion

        #region Functions
        /// <summary>
        /// Retrieves the highest BPS for a specified time period
        /// </summary>
        /// <param name="milliseconds"></param>
        /// <returns></returns>
        public float GetHighBP(Int32 milliseconds)
        {
            float bps = 0;
            for (int i = 0; i < _points.Length; i++)
            {
                for (int j = i; j < _points.Length; j++)
                {
                    if ((_points[j].Time - _points[i].Time) > milliseconds)
                    {
                        bps = j - i - 1;
                    }
                }

            }
            return bps;
        }

        /// <summary>
        /// Returns the fastest theoretical BPS, ie take the two closest points and the time between them and divide them into 1000
        /// </summary>
        /// <returns>highest theoretical BPS </returns>
        public float GetHighestPossibleBPS()
        {
            float timeBetween = 0;
            for (int i = 0; i < _points.Length - 1; i++)
            {
                float tempTimeBetween = _points[i + 1].Time - _points[i].Time;
                if (tempTimeBetween > timeBetween)
                    timeBetween = tempTimeBetween;
        
            }
            return 1000 / timeBetween;


        }

        #endregion


        public class BPSPoint
        {
            public Int32 Time;
            public Int32 Number;
            public BPSPoint(Int32 first,Int32 number)
            {
                Time = first;
                Number = number;

            }
        }
    }
}
