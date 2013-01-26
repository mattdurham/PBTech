using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Data;

namespace PBTech
{
    [TestFixture]
    public class DatabaseTest
    {
        [Test]
        public void TestCreation()
        {
            
            Database db = new Database();
            Assert.IsTrue(System.IO.File.Exists(Database.DB_NAME));
            db.CloseDatabase();

        }

        [Test]
        public void TestDeletion()
        {
            /*
            Database db = new Database();
            db.CloseDatabase();
            System.Threading.Thread.Sleep(100);
            Database.DeleteDatabase();
            Assert.IsFalse(System.IO.File.Exists(Database.DB_NAME));
             */
        }

        [Test]
        public void TestCreationOfTables()
        {

            Database db = new Database();
            try
            {
                IDataReader reader = db.ExecuteQuery("SELECT count(*) FROM READING");
                if (reader.Read())
                {
                    Assert.IsTrue(true);
                }
                else
                {
                    Assert.IsTrue(false);
                }
                reader.Close();

                reader = db.ExecuteQuery("SELECT count(*) FROM CHANNEL");
                if (reader.Read())
                {
                    Assert.IsTrue(true);
                }
                else
                {
                    Assert.IsTrue(false);
                }
                reader.Close();

                reader = db.ExecuteQuery("SELECT count(*) FROM READING_DETAIL");
                if (reader.Read())
                {
                    Assert.IsTrue(true);
                }
                else
                {
                    Assert.IsTrue(false);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                db.CloseDatabase();
                Assert.IsTrue(false, ex.ToString());
            }
            db.CloseDatabase();

        }

        [Test]
        public void TestInsertion()
        {
            Database db = new Database();
            Reading r = db.CreateReading("TEST","DESC");
            Assert.IsTrue(r.ID > 0);
            Assert.IsTrue(r.Name == "TEST");
            Assert.IsTrue(r.Description == "DESC");

            Channel ch = db.CreateChannelForReading(r, "Channel 1", 1);
            Assert.IsTrue(ch.ID > 0);
            Assert.IsTrue(ch.ParentReading == r);
            Assert.IsTrue(ch.ChannelNumber == 1);
            Assert.IsTrue(ch.Details == "Channel 1");

            ReadingDetail rd = db.CreateDetailForChannelandReading(ch, 1, 100);
            Assert.IsTrue(rd.ParentChannel == ch);
            Assert.IsTrue(rd.ParentReading == r);
            Assert.IsTrue(rd.Time == 1);
            Assert.IsTrue(rd.Reading == 100);


        }
    }
}
