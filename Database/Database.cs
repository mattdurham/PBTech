using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;
using System.Data.SQLite;

namespace PBTech
{
    public class Database : IDisposable
    {
        SQLiteConnection _connection;
        
        /// <summary>
        /// Default Name for the database if none is specified
        /// </summary>
        public const string DB_NAME = "pbtech.db3";

        #region Public

        /// <summary>
        /// This will delete the database specified in Database.DB_NAME
        /// </summary>
        public static void DeleteDatabase()
        {
            DeleteDatabase(DB_NAME);
        }

        public static void DeleteDatabase(string name)
        {
            if (System.IO.File.Exists(name))
            {
                System.IO.File.Delete(name);
            }
        }

        public Database(string name) 
        {
            SetupDatabase(name);
        }

        /// <summary>
        /// This will use the default database as specified in Database.DB_NAME
        /// </summary>
        public Database() 
        {
            SetupDatabase(DB_NAME);
        }

        public void CloseDatabase()
        {
            if (_connection != null &&  _connection.State == ConnectionState.Open)
            {
                _connection.Close();
                _connection.Dispose();
                _connection = null;
            }
        }

        /// <summary>
        /// Erases all data in the tables
        /// </summary>
        public void EmptyDatabase()
        {
            ExecuteNonQuery("DELETE FROM READING; DELETE FROM CHANNEL; DELETE FROM READING_DETAIL; DELETE FROM CHANNEL_CONFIG;");
        }

        public Reading CreateReading(string name, string description)
        {
            Reading r = new Reading();
            r.Name = name;
            r.Description = description;
            SQLiteCommand cmd = _connection.CreateCommand();
            cmd.CommandText = Properties.Settings.Default.INSERT_READING;
            DateTime dt = DateTime.Now;
            r.Date = dt;
            cmd.Parameters.Add(new SQLiteParameter("@date", dt.ToUniversalTime().ToString("u")));
            cmd.Parameters.Add(new SQLiteParameter("@name",name));
            cmd.Parameters.Add(new SQLiteParameter("@description",description));
            int rid = Convert.ToInt32(cmd.ExecuteScalar());
            r.ID = rid;
            return r;
        }

        public DAQChannel CreateChannelForReading(Reading r,ChannelConfig cc, string details,int number)
        {
            SQLiteCommand cmd = _connection.CreateCommand();
            cmd.CommandText = Properties.Settings.Default.INSERT_CHANNEL;
            cmd.Parameters.Add(new SQLiteParameter("@rid",r.ID));
            cmd.Parameters.Add(new SQLiteParameter("@details",details));
            cmd.Parameters.Add(new SQLiteParameter("@number",number));
            cmd.Parameters.Add(new SQLiteParameter("@channelconfig", cc.ID));
            int cid = Convert.ToInt32(cmd.ExecuteScalar());

            DAQChannel ch = new DAQChannel();
            ch.ID = cid;
            ch.Details = details;
            ch.ParentReading = r;
            ch.Channel = number;
            ch.Config = cc;
            r.ChannelList.Add(ch);
            return ch;
        }

        public ReadingDetail CreateDetailForChannelandReading(DAQChannel ch, int time, int reading)
        {
            ReadingDetail rd = new ReadingDetail();
            rd.Time = time;
            rd.Reading = reading;
            rd.ParentChannel = ch;
            SQLiteCommand cmd = _connection.CreateCommand();
            cmd.CommandText = Properties.Settings.Default.INSERT_READING_DETAIL;
            cmd.Parameters.Add(new SQLiteParameter("@rid", ch.ParentReading.ID));
            cmd.Parameters.Add(new SQLiteParameter("@cid", ch.ID));
            cmd.Parameters.Add(new SQLiteParameter("@time", time));
            cmd.Parameters.Add(new SQLiteParameter("@point", reading));
            int rdid = Convert.ToInt32(cmd.ExecuteScalar());
            rd.ID = rdid;
            ch.ReadingDetails.Add(rd);
            return rd;
        }

        public ChannelConfig CreateChannelConfig(string name, int psi, OutputVoltRange range, float offset, int defaultChannel)
        {
            int outputRange = 0;
            switch (range)
            {
                case OutputVoltRange.ZeroToFiveVolts:
                    outputRange = 5;
                    break;
                case OutputVoltRange.PointFiveToFourPointFive:
                    outputRange = 4;
                    break;
                default:
                    throw new Exception("Invalid output range");
            }
            SQLiteCommand cmd = _connection.CreateCommand();
            cmd.CommandText = Properties.Settings.Default.INSERT_CHANNEL_CONFIG;
            cmd.Parameters.Add(new SQLiteParameter("@name", name));
            cmd.Parameters.Add(new SQLiteParameter("@psi", psi));
            cmd.Parameters.Add(new SQLiteParameter("@outputvolts", outputRange));
            cmd.Parameters.Add(new SQLiteParameter("@offset", offset));
            cmd.Parameters.Add(new SQLiteParameter("@defaultchannel",defaultChannel));
            int ccid = Convert.ToInt32(cmd.ExecuteScalar());
            ChannelConfig cc = new ChannelConfig();
            cc.ID = ccid;
            cc.Name = name;
            cc.Offset = offset;
            cc.PSI = psi;
            cc.VoltRange = range;
            cc.DefaultChannel = defaultChannel;
            return cc;
        }

        public void SaveReadingDetail(ReadingDetail rd)
        {
            SQLiteCommand cmd = _connection.CreateCommand();
            cmd.CommandText = Properties.Settings.Default.INSERT_READING_DETAIL;
            cmd.Parameters.Add(new SQLiteParameter("@rid", rd.ParentChannel.ParentReading.ID));
            cmd.Parameters.Add(new SQLiteParameter("@cid", rd.ParentChannel.ID));
            cmd.Parameters.Add(new SQLiteParameter("@time", rd.Time));
            cmd.Parameters.Add(new SQLiteParameter("@point", rd.Reading));
            rd.ID = Convert.ToInt32(cmd.ExecuteScalar());
        }

        public IDataReader ExecuteQuery(string sql)
        {
            SQLiteCommand cmd = _connection.CreateCommand();
            cmd.CommandText = sql;
            return cmd.ExecuteReader();
        }

        public IDataReader ExecuteQuery(string sql, Dictionary<string, object> parameters)
        {
            SQLiteCommand cmd = _connection.CreateCommand();
            cmd.CommandText = sql;
            foreach (KeyValuePair<string, object> map in parameters)
            {
                cmd.Parameters.Add(new SQLiteParameter(map.Key, map.Value == null ? DBNull.Value : map.Value));
            }
            return cmd.ExecuteReader();
        }
      
        public Reading[] GetReadings()
        {
            BeginTransaction();
            List<Reading> readings = new List<Reading>();
            IDataReader reader = ExecuteQuery("SELECT r_id,r_date,r_name,r_description FROM READING order by r_date asc");
            while (reader.Read())
            {
                Reading r = new Reading();
                r.ID = reader.GetInt32(0);
                r.Date = Convert.ToDateTime(reader.GetString(1));
                r.Name = reader.GetString(2);
                r.Description = reader.GetString(3);
                readings.Add(r);
            }
            reader.Close();
            foreach (Reading r in readings)
            {
                GetChannelsForReading(r);
            }
            CommitTransaction();
            return readings.ToArray();

        }

        public ChannelConfig[] GetChannelConfigs()
        {
            List<ChannelConfig> configs = new List<ChannelConfig>();
            IDataReader reader = ExecuteQuery("SELECT CC_ID,cc_name,cc_psi,cc_outputvolts,cc_offset,cc_defaultchannel from CHANNEL_CONFIG");
            while (reader.Read())
            {
                ChannelConfig cc = new ChannelConfig();
                cc.ID = reader.GetInt32(0);
                cc.Name = reader.GetString(1);
                cc.PSI = reader.GetInt32(2);
                int voltRange = reader.GetInt32(3);
                switch (voltRange)
                {
                    case 5:
                        cc.VoltRange = OutputVoltRange.ZeroToFiveVolts;
                        break;
                    case 4:
                        cc.VoltRange = OutputVoltRange.PointFiveToFourPointFive;
                        break;
                    default:
                        throw new Exception("Invalid volt range");
                }
                cc.Offset = reader.GetFloat(4);
                cc.DefaultChannel = reader.GetInt32(5);
                configs.Add(cc);
            }
            return configs.ToArray();
        }

        public void BeginTransaction()
        {
            ExecuteNonQuery("BEGIN TRANSACTION");
        }


        public void CommitTransaction()
        {
            ExecuteNonQuery("COMMIT TRANSACTION");
        }

        #endregion

        #region Private

        private void SetupDatabase(string name)
        {
            bool needsCreation = false;
            if (name.ToLower().Contains("memory"))
            {
                needsCreation = true;
            }
            else
            {
                if (!System.IO.File.Exists(name))
                {
                    SQLiteConnection.CreateFile(name);
                    needsCreation = true;
                }
            }
            _connection = new SQLiteConnection("Data Source=" + name + ";Version=3;");
            _connection.Open();
            IDataReader reader = ExecuteQuery("SELECT name FROM sqlite_master WHERE type='table' and name = 'READING'");
            bool noTables = !reader.Read();
            reader.Close();
            if (noTables || needsCreation)
            {
                CreateDatabase();
            }
        }

        private void GetChannelsForReading(Reading r)
        {
            Dictionary<int, ChannelConfig> configDictionary = new Dictionary<int, ChannelConfig>();
            foreach (ChannelConfig cc in GetChannelConfigs())
            {
                configDictionary.Add(cc.ID, cc);
            }
            Dictionary<string,object> parameters = new Dictionary<string,object>();
            parameters.Add("@rid",r.ID);
            IDataReader reader = ExecuteQuery("SELECT c_id,c_details,c_channelnumber,c_ccid from channel where c_rid = @rid ORDER by c_channelnumber asc", parameters);
            while (reader.Read())
            {
                DAQChannel ch = new DAQChannel();
                int ccid = reader.GetInt32(3);
                ch.Config = configDictionary[ccid];
                ch.ID = reader.GetInt32(0);
                ch.Details = reader.GetString(1);
                ch.Channel = reader.GetInt32(2);
                ch.ParentReading = r;
                r.ChannelList.Add(ch);
            }
            reader.Close();
            foreach (DAQChannel ch in r.ChannelList)
            {
                GetReadingDetailsForChannel(ch);
            }

        }

        private void GetReadingDetailsForChannel(DAQChannel ch)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@cid",ch.ID);
            IDataReader reader = ExecuteQuery("SELECT rd_id,rd_time,rd_point from READING_DETAIL where rd_cid = @cid order by rd_time asc", parameters);
            while (reader.Read())
            {
                ReadingDetail rd = new ReadingDetail();
                rd.ID = reader.GetInt32(0);
                rd.ParentChannel = ch;
                rd.Time = reader.GetInt32(1);
                rd.Reading = Convert.ToInt32(reader.GetFloat(2));
                ch.ReadingDetails.Add(rd);
            }
            reader.Close();
        }

        private void CreateDatabase()
        {
            ExecuteNonQuery(Properties.Settings.Default.CREATE_READING);
            ExecuteNonQuery(Properties.Settings.Default.CREATE_CHANNEL);
            ExecuteNonQuery(Properties.Settings.Default.CREATE_READING_DETAIL);
            ExecuteNonQuery(Properties.Settings.Default.CREATE_CHANNEL_CONFIG);
        }

        private void ExecuteNonQuery(string sql)
        {
            SQLiteCommand cmd = _connection.CreateCommand();
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
        }


        
        public void Dispose()
        {
            CloseDatabase();
            _connection = null;
        }

        #endregion
    }

    public class Reading
    {
        public int ID;
        public string Name;
        public string Description;
        public DateTime Date;

        public List<DAQChannel> ChannelList = new List<DAQChannel>();

        public DAQChannel GetChannelAtNumber(int channelNumber)
        {
            foreach (DAQChannel ch in ChannelList)
            {
                if (ch.Channel == channelNumber)
                {
                    return ch;
                }
            }
            return null;
        }

        public override string ToString()
        {
            return Name + " " + Date.ToString();
        }

    }

    public class DAQChannel : IDAQ
    {
        public int ID;
        public int Channel { get; set; }
        
        public string Details;
        public Reading ParentReading;
        public ChannelConfig Config;
        public List<ReadingDetail> ReadingDetails = new List<ReadingDetail>();

    }

    public class ReadingDetail : IDAQPoint
    {
        public int ID;
        public int Time {get;set;}
        public float Reading;
        public DAQChannel ParentChannel;
        public Reading ParentReading
        {
            get
            {
                return ParentChannel.ParentReading;
            }
        }

        public float PSI
        {
            get
            {
                return ParentChannel.Config.GetPsi(Reading);
            }
        }

        public override string ToString()
        {
            return Time.ToString() + ":" + Reading.ToString();
        }


        #region IDAQPoint Members

        float IDAQPoint.Reading
        {
            get { return (float)Reading; }
        }

        public int Channel
        {
            get { return ParentChannel.Channel; }
        }


        #endregion
    }

    public enum OutputVoltRange { ZeroToFiveVolts, PointFiveToFourPointFive};

    public class ChannelConfig
    {
        public int ID;
        public string Name;
        public int PSI;
        public OutputVoltRange VoltRange;
        public float Offset;
        public int DefaultChannel;

        /// <summary>
        /// This returns the actual PSI calculation taking into account all the parameters of the channel
        /// </summary>
        /// <param name="volts"></param>
        /// <returns></returns>
        public float GetPsi(float volts)
        {
            float percentage = 0F;
            switch(VoltRange)
            {
                case OutputVoltRange.ZeroToFiveVolts:
                    percentage  = (volts - Offset) / 5;
                    return percentage * PSI;
                case OutputVoltRange.PointFiveToFourPointFive:
                    percentage = ((volts - .5F) - Offset) / 4;
                    return percentage * PSI;
                default:
                    throw new Exception("Invalid Volt Range");
            }
           
        }

        public override string ToString()
        {
            return Name + " DAQChannel: " + DefaultChannel.ToString() + " PSI: " + PSI.ToString();
        }
    }
}
