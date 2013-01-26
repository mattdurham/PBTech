using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace PBTech
{
    /// <summary>
    /// Class contains information on one instance of a _transducer item
    /// </summary>
    public class Transducer
    {
        #region Private Variables
        private string _transName;
        private string _transID;
        private int _transChannel;
        private TranRes.Points _transPoints;
        private System.Drawing.Color _drawColor;
        private int _maxPsi;
        private bool _visible;
        private bool _active;
        #endregion

        public int LastPoint;
        public Transducer()
        {
            TransPoints = new TranRes.Points();
        }

        #region Public Accessors
        public string TransName
        {
            get { return _transName; }
            set { _transName = value; }
        }

        public string TransID
        {
            get { return _transID; }
            set { _transID = value; }
        }

        public int TransChannel
        {
            get { return _transChannel; }
            set { _transChannel = value; }
        }

        public TranRes.Points TransPoints
        {
            get { return _transPoints; }
            set { _transPoints = value; }
        }

        public TranRes.Pnt this[int point]
        {
            get { return _transPoints[point]; }
            set { _transPoints[point] = value; }
        }

        public bool Active
        {
            get { return this._active; }
            set { this._active = value; }
        }
        public bool Visible
        {
            get { return _visible; }
            set { _visible = value; }
        }

        public int TransMaxPsi
        {
            get { return _maxPsi; }
            set { _maxPsi = value; }
        }

        public Color TransColor
        {
            get { return this._drawColor; }
            set { _drawColor = value; }
        }

        public float Hi
        {
            get
            {
                float hi = 0;
                if (TransPoints.Count > 0)
                    hi = TransPoints[0].Result;
                for (int i = 1; i < this.TransPoints.Count; i++)
                {
                    if (TransPoints[i].Result > hi)
                        hi = TransPoints[i].Result;
                }
                return hi;
            }
        }

        public float Low
        {
            get
            {
                float low = 0;
                if (TransPoints.Count > 0)
                    low = TransPoints[0].Result;
                for (int i = 1; i < this.TransPoints.Count; i++)
                {
                    if (TransPoints[i].Result < low)
                        low = TransPoints[i].Result;
                }
                return low;
            }
        }

        public float Avg
        {
            get
            {
                float total = 0;
                for (int i = 0; i < TransPoints.Count; i++)
                {
                    total = total + TransPoints[0].Result;
                }
                return total / TransPoints.Count;
            }
        }
        #endregion



        }

        ///
        /// Class to handle the data structure of the _transducer reading.
        /// </summary>
        public class TranRes
        {
            /// <summary>
            /// A collection of points
            /// </summary>
            public class Points
            {
                Pnt[] pArray;

                public Points(Pnt[] pointArr)
                {
                    pArray = pointArr;

                }
                public Points()
                {
                    pArray = new Pnt[0];

                }
                public void AddPoint(Pnt point)
                {
                    Pnt[] tempPoint = new Pnt[pArray.Length + 1];
                    for (int i = 0; i < pArray.Length; i++)
                    {
                        tempPoint[i] = pArray[i];
                    }
                    tempPoint[pArray.Length] = point;
                    pArray = tempPoint;
                }

                public Pnt this[int point]
                {
                    get { return pArray[point]; }
                    set { pArray[point] = value; }
                }


                public int Count
                {
                    get
                    {
                        return this.pArray.Length;
                    }
                }
            }
            public struct Pnt
            {
                public int Position;
                public float Result;
            }
        }
    }
