using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace PBTech
{
    class Database : IDisposable
    {
        SQLiteConnection _connection;
        public const string DB_NAME = "pbtech.db3";

        public static void DeleteDatabase()
        {
            if(System.IO.File.Exists(DB_NAME))
            {
                System.IO.File.Delete(DB_NAME);
            }
        }

        public Database()
        {
            bool needsCreation = false;
            if (!System.IO.File.Exists(DB_NAME))
            {
                SQLiteConnection.CreateFile(DB_NAME);
                needsCreation = true;
            }
            _connection = new SQLiteConnection("Data Source=" + DB_NAME + ";Version=3;");
            _connection.Open();
            IDataReader reader = ExecuteQuery("SELECT name FROM sqlite_master WHERE type='table' and name = 'READING'");
            bool noTables = !reader.Read();
            reader.Close();
            if (noTables || needsCreation)
            {
                CreateDatabase();
            }
        }

        public Reading CreateReading(string name, string description)
        {
            Reading r = new Reading();
            r.Name = name;
            r.Description = description;
            SQLiteCommand cmd = _connection.CreateCommand();
            cmd.CommandText = Properties.Settings.Default.INSERT_READING;
            cmd.Parameters.Add(new SQLiteParameter("@date",DateTime.Now.ToShortDateString() + " : " + DateTime.Now.ToShortTimeString()));
            cmd.Parameters.Add(new SQLiteParameter("@name",name));
            cmd.Parameters.Add(new SQLiteParameter("@description",description));
            int rid = Convert.ToInt32(cmd.ExecuteScalar());
            r.ID = rid;
            return r;
        }

        public Channel CreateChannelForReading(Reading r, string details,int number)
        {
            SQLiteCommand cmd = _connection.CreateCommand();
            cmd.CommandText = Properties.Settings.Default.INSERT_CHANNEL;
            cmd.Parameters.Add(new SQLiteParameter("@rid",r.ID));
            cmd.Parameters.Add(new SQLiteParameter("@details",details));
            cmd.Parameters.Add(new SQLiteParameter("@number",number));
            int cid = Convert.ToInt32(cmd.ExecuteScalar());
            Channel ch = new Channel();
            ch.ID = cid;
            ch.Details = details;
            ch.ParentReading = r;
            ch.ChannelNumber = number;
            r.ChannelList.Add(ch);
            return ch;
        }

        public ReadingDetail CreateDetailForChannelandReading(Channel ch, int time, int reading)
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
            return rd;
        }

        public IDataReader ExecuteQuery(string sql)
        {
            SQLiteCommand cmd = _connection.CreateCommand();
            cmd.CommandText = sql;
            return cmd.ExecuteReader();
        }

        private void CreateDatabase()
        {
            ExecuteNonQuery(Properties.Settings.Default.CREATE_READING);
            ExecuteNonQuery(Properties.Settings.Default.CREATE_CHANNEL);
            ExecuteNonQuery(Properties.Settings.Default.CREATE_READING_DETAIL);
        }

        private void ExecuteNonQuery(string sql)
        {
            SQLiteCommand cmd = _connection.CreateCommand();
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
        }

        public void CloseDatabase()
        {
            if (_connection != null && _connection.State == ConnectionState.Open)
            {
                _connection.Close();
            }
        }

        ~Database()
        {
            CloseDatabase();
        }


        #region IDisposable Members

        public void Dispose()
        {
            CloseDatabase();
        }

        #endregion
    }

    public class Reading
    {
        public int ID;
        public string Name;
        public string Description;

        public List<Channel> ChannelList = new List<Channel>();
    }

    public class Channel
    {
        public int ID;
        public int ChannelNumber;
        public string Details;
        public Reading ParentReading;
    }

    public class ReadingDetail
    {
        public int ID;
        public int Time;
        public int Reading;
        public Channel ParentChannel;
        public Reading ParentReading
        {
            get
            {
                return ParentChannel.ParentReading;
            }
        }
    }
}
