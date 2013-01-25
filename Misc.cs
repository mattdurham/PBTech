using System;
using System.Collections.Generic;
using System.Text;

namespace PBTech
{
    public class Misc
    {

        public class MarkerConfigurationInfo
        {
            public TransducerConstruct TranC;
            public BPSConstruct BpsC;
            public FPSConstruct FpsC;
            public DateTime DateCreated;
            public DateTime DateLastModified;
            public string Description;
            public string Comments;
            public string MarkerName;
            public string ID;

        }

        public class TransducerConstruct
        {
            
            public Transducer Trans;
            public System.Drawing.Color Color;
            public MarkerConfigurationInfo Parent;
            
        }
        
        public class BPSConstruct
        {
            public BPSMeter Meter;
            public MarkerConfigurationInfo Parent;
            
        }

        public class FPSConstruct
        {
            public FPSMeter Meter;
            public MarkerConfigurationInfo Parent;
            

        }

        public class Configuration
        {
            public TransducerInfo[] tInfo;
            public class TransducerInfo
            {
                string Channel;
                string Voltage;
            }
        }
    }
}
