using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;

namespace PBTech
{
    class Database
    {
        public string configFile;
        public string BPSfile;
        public string FPSFile;
        public string TranFile;
        public bool Save(Misc.MarkerConfigurationInfo info)
        {
            StreamReader read = new StreamReader(configFile);
            StreamWriter write = new StreamWriter(configFile);
            return true;
        }
        private Misc.MarkerConfigurationInfo CreateConfigFromTxt(string line)
        {
            string ID;
            string Marker;
            string Comments;
            string Description;
            DateTime Modified;
            DateTime Created;
            string[] lines = line.Split('\t');
            ID = lines[0];
            Marker = lines[1];
            Comments = lines[2];
            Description = lines[3];
            Modified = Convert.ToDateTime(lines[4]);
            Created = Convert.ToDateTime(lines[5]);
            Misc.MarkerConfigurationInfo info = new Misc.MarkerConfigurationInfo();
            info.ID = ID;
            info.MarkerName = Marker;
            info.Comments = Comments;
            info.Description = Description;
            info.DateLastModified = Modified;
            info.DateCreated = Created;
            return info;
        }

        private Misc.FPSConstruct CreateFPSFromTxt(string line)
        {
            string ParentID;
            string ID;
            DateTime Time1;
            DateTime Time2;
            float DistInches;
            Misc.FPSConstruct fpsCon = new Misc.FPSConstruct();
            return null;

        }
    }
}
