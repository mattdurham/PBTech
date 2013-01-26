using System;
using System.Collections.Generic;
using System.Text;

namespace PBTech
{
    public delegate void DataRetrieved(Dictionary<IDAQ, IDAQPoint[]> readings);

    public interface IDAQ
    {
        int Channel {get;}
    }

    public abstract class DAQ : IDAQ
    {
      
        protected int _channel;

        public int Channel
        {
            get
            {
                return _channel;
            }
        }

        public DAQ( int channel)
        {
            _channel = channel;
        }
    }


    public interface IDAQInterface
    {
        void Setup(DataRetrieved dataRetrieved, IDAQ[] daqs);
        void StartReading();
        void StopReading();
    }

    public interface IDAQPoint
    {
        float Reading {get;}
        int Channel {get;}
        int Time {get;}
    }


}
