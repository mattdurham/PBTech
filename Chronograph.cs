using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;

namespace PBTech
{
    public class Chronograph
    {
        public delegate void CallBack(ChronoStruct cStruct);
        public CallBack callBack;
        public ChronoStruct cStruct;
        public Chronograph(CallBack callBackFunction)
        {
            callBack = callBackFunction;
            System.IO.Ports.SerialPort port1 = new System.IO.Ports.SerialPort("COM1");
            port1.PinChanged += new System.IO.Ports.SerialPinChangedEventHandler(port1_PinChanged);
        }

        void port1_PinChanged(object sender, System.IO.Ports.SerialPinChangedEventArgs e)
        {
            SerialPort port = sender as SerialPort;
            //Ring is the start chronograph (Pin 9)
            if (e.EventType.ToString() == SerialPinChange.Ring.ToString())
                cStruct.time1 = DateTime.Now;
            //Carrier Detect is the end chronograph (pin 1)
            if (e.EventType.ToString() == SerialPinChange.CDChanged.ToString())
            {
                cStruct.time2 = DateTime.Now;
                callBack.Invoke(cStruct);
            }
        }

        public struct ChronoStruct
        {
            public DateTime time1;
            public DateTime time2;
        }
    }
}
