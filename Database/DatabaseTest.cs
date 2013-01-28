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
        private const string DB_TEST = ":memory:";
        private const string DB_TEST_DELETE = "TEST_DELETE.db3";
        private const string DB_TEST_CREATION = "test.db3";

        [Test]
        public void TestCreation()
        {

            using (Database db = new Database(DB_TEST_CREATION))
            {
                db.EmptyDatabase();
                Assert.IsTrue(System.IO.File.Exists(DB_TEST_CREATION));
                db.CloseDatabase();
            }
        }

        [Test]
        public void TestDeletion()
        {
            /*
            using (Database db = new Database(DB_TEST_DELETE))
            {
                db.CloseDatabase();
            }
            Database.DeleteDatabase(DB_TEST_DELETE);
            Assert.IsFalse(System.IO.File.Exists(DB_TEST_DELETE));
        
             */
        }

        [Test]
        public void TestCreationOfTables()
        {

            using (Database db = new Database(DB_TEST))
            {
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

        }

        [Test]
        public void TestInsertion()
        {
            using (Database db = new Database(DB_TEST))
            {
                db.EmptyDatabase();
                ChannelConfig cc = db.CreateChannelConfig("Config1", 1000, OutputVoltRange.ZeroToFiveVolts, 0,1);
                Assert.IsTrue(cc.ID > 0);
                Assert.IsTrue(cc.Name == "Config1");
                Assert.IsTrue(cc.PSI == 1000);
                Assert.IsTrue(cc.VoltRange == OutputVoltRange.ZeroToFiveVolts);
                Assert.IsTrue(cc.Offset == 0);
                Assert.IsTrue(cc.DefaultChannel == 1);

                Reading r = db.CreateReading("TEST", "DESC");
                Assert.IsTrue(r.ID > 0);
                Assert.IsTrue(r.Name == "TEST");
                Assert.IsTrue(r.Description == "DESC");

                DAQChannel ch = db.CreateChannelForReading(r,cc, "DAQChannel 1", 1);
                Assert.IsTrue(ch.ID > 0);
                Assert.IsTrue(ch.ParentReading == r);
                Assert.IsTrue(ch.Channel == 1);
                Assert.IsTrue(ch.Details == "DAQChannel 1");

                ReadingDetail rd = db.CreateDetailForChannelandReading(ch, 1, 100);
                Assert.IsTrue(rd.ParentChannel == ch);
                Assert.IsTrue(rd.ParentReading == r);
                Assert.IsTrue(rd.Time == 1);
                Assert.IsTrue(rd.Reading == 100);
                Assert.IsTrue(ch.ReadingDetails.Contains(rd));
                db.CloseDatabase();
            }
        }

        [Test]
        public void TestRetrieval()
        {
            using (Database db = new Database(DB_TEST))
            {
                db.EmptyDatabase();
                Reading r = db.CreateReading("TEST", "DESC");
                ChannelConfig cc = db.CreateChannelConfig("Config1", 1000, OutputVoltRange.ZeroToFiveVolts, 0, 1);
                DAQChannel ch1 = db.CreateChannelForReading(r,cc, "DAQChannel 1", 1);
                ReadingDetail rd1 = db.CreateDetailForChannelandReading(ch1, 1, 100);
                ReadingDetail rd2 = db.CreateDetailForChannelandReading(ch1, 2, 200);
                ReadingDetail rd3 = db.CreateDetailForChannelandReading(ch1, 3, 300);
                DAQChannel ch2 = db.CreateChannelForReading(r,cc, "DAQChannel 2", 2);
                ReadingDetail rd4 = db.CreateDetailForChannelandReading(ch2, 1, 400);
                ReadingDetail rd5 = db.CreateDetailForChannelandReading(ch2, 2, 500);
                ReadingDetail rd6 = db.CreateDetailForChannelandReading(ch2, 3, 600);

                Reading[] readers = db.GetReadings();
                foreach (Reading testReading in readers)
                {
                    Assert.IsTrue(testReading.ID == r.ID);

                    DAQChannel testChannel1 = testReading.GetChannelAtNumber(1);
                    Assert.IsTrue(testChannel1.ID == ch1.ID);
                    Assert.IsTrue(testChannel1.Config.ID == cc.ID);
                    Assert.IsTrue(testChannel1.ReadingDetails.Count == 3);
                    Assert.IsTrue(testChannel1.ReadingDetails[0].ID == rd1.ID);
                    Assert.IsTrue(testChannel1.ReadingDetails[1].ID == rd2.ID);
                    Assert.IsTrue(testChannel1.ReadingDetails[2].ID == rd3.ID);

                    DAQChannel testChannel2 = testReading.GetChannelAtNumber(2);
                    Assert.IsTrue(testChannel2.ReadingDetails.Count == 3);
                    Assert.IsTrue(testChannel2.ID == ch2.ID);
                    Assert.IsTrue(testChannel2.Config.ID == cc.ID);
                    Assert.IsTrue(testChannel2.ReadingDetails[0].ID == rd4.ID);
                    Assert.IsTrue(testChannel2.ReadingDetails[1].ID == rd5.ID);
                    Assert.IsTrue(testChannel2.ReadingDetails[2].ID == rd6.ID);

                    DAQChannel testChannel3 = r.GetChannelAtNumber(3);
                    Assert.IsTrue(testChannel3 == null);
                }

                db.CloseDatabase();
            }
        }

        [Test]
        public void TestMath()
        {
            ChannelConfig cc = new ChannelConfig();
            cc.PSI = 1000;
            cc.VoltRange = OutputVoltRange.ZeroToFiveVolts;
            cc.Offset = 0.05F;
            Assert.IsTrue(190.0 == cc.GetPsi(1));
        }
    }
}
