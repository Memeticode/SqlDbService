using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlDbServiceTests.SqlServerTests
{

    internal static class TestInfo
    {
        internal static SqlDbContextManager getSqlDbContextManager()
        {
            var db = new SqlDbContextManager();
            //string cnstr = "Server=tcp:shittyfreeappsdb.database.windows.net,1433;Initial Catalog=MyApp;Persist Security Info=False;User ID=Thatcher;Password=Sql.Account1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            db.SqlSoftware = SqlDbSoftware.SqlServer;
            db.Server = "tcp:shittyfreeappsdb.database.windows.net,1433";
            db.Db = "MyApp";
            db.Username = "Thatcher";
            db.Password = "Sql.Account1";
            db.ConnectionTimeout = 30;
            return db;
        }
    }


    [TestClass]
    public class SqlServerActionDoer_CheckExists_Tests
    {

        // CheckSchemaNameExistsAsync

        [TestMethod]
        public void CheckSchemaNameExistsAsync_Exists()
        {
            string schema = "dbo";
            SqlServerActionDoer dbService = new SqlServerActionDoer(TestInfo.getSqlDbContextManager());
            Task<bool> t = dbService.CheckSchemaNameExistsAsync(schema);
            t.Wait();
            Assert.IsTrue(t.IsCompleted);
            Assert.IsTrue(t.Result);
        }

        [TestMethod]
        public void CheckSchemaNameExistsAsync_NotExists()
        {
            string schema = "fakeSchema";
            SqlServerActionDoer dbService = new SqlServerActionDoer(TestInfo.getSqlDbContextManager());
            Task<bool> t = dbService.CheckSchemaNameExistsAsync(schema);
            t.Wait();
            Assert.IsTrue(t.IsCompleted);
            Assert.IsFalse(t.Result);
        }



        // CheckTableExistsAsync

        [TestMethod]
        public void CheckTableExistsAsync_Exists()
        {
            IDbTable tbl = new DbTable() { Schema = "dbo", Name = "TestTable" };
            SqlServerActionDoer dbService = new SqlServerActionDoer(TestInfo.getSqlDbContextManager());
            Task<bool> t = dbService.CheckTableExistsAsync(tbl);
            t.Wait();
            Assert.IsTrue(t.IsCompleted);
            Assert.IsTrue(t.Result);
        }

        [TestMethod]
        public void CheckTableExistsAsync_NotExists()
        {
            IDbTable tbl = new DbTable() { Schema = "dbo", Name = "FakeTable" };
            SqlServerActionDoer dbService = new SqlServerActionDoer(TestInfo.getSqlDbContextManager());
            Task<bool> t = dbService.CheckTableExistsAsync(tbl);
            t.Wait();
            Assert.IsTrue(t.IsCompleted);
            Assert.IsFalse(t.Result);
        }



        // CheckTableFieldExistsAsync

        [TestMethod]
        public void CheckTableFieldExistsAsync_Exists()
        {
            IDbTable tbl = new DbTable() { Schema = "dbo", Name = "TestTable" };
            IDbField fld = new DbField() { Name = "id" };
            SqlServerActionDoer dbService = new SqlServerActionDoer(TestInfo.getSqlDbContextManager());
            Task<bool> t = dbService.CheckTableFieldExistsAsync(tbl, fld);
            t.Wait();
            Assert.IsTrue(t.IsCompleted);
            Assert.IsTrue(t.Result);
        }

        [TestMethod]
        public void CheckTableFieldExistsAsync_NotExists()
        {
            IDbTable tbl = new DbTable() { Schema = "dbo", Name = "TestTable" };
            IDbField fld = new DbField() { Name = "FakeId" };
            SqlServerActionDoer dbService = new SqlServerActionDoer(TestInfo.getSqlDbContextManager());
            Task<bool> t = dbService.CheckTableFieldExistsAsync(tbl, fld);
            t.Wait();
            Assert.IsTrue(t.IsCompleted);
            Assert.IsFalse(t.Result);
        }


        // CheckTablePkIndexExistsAsync

        [TestMethod]
        public void CheckTablePkIndexExistsAsync_Exists()
        {
            IDbTable tbl = new DbTable() { Schema = "dbo", Name = "TestTable" };
            SqlServerActionDoer dbService = new SqlServerActionDoer(TestInfo.getSqlDbContextManager());
            Task<bool> t = dbService.CheckTablePkIndexExistsAsync(tbl);
            t.Wait();
            Assert.IsTrue(t.IsCompleted);
            Assert.IsTrue(t.Result);
        }

        [TestMethod]
        public void CheckTablePkIndexExistsAsync_NotExists()
        {
            IDbTable tbl = new DbTable() { Schema = "dbo", Name = "TestTableNoPk" };
            SqlServerActionDoer dbService = new SqlServerActionDoer(TestInfo.getSqlDbContextManager());
            Task<bool> t = dbService.CheckTablePkIndexExistsAsync(tbl);
            t.Wait();
            Assert.IsTrue(t.IsCompleted);
            Assert.IsFalse(t.Result);
        }


        // CheckTableIndexExistsAsync

        [TestMethod]
        public void CheckTableIndexExistsAsync_Exists()
        {
            IDbTable tbl = new DbTable() { Schema = "dbo", Name = "TestTable" };
            IDbIndex idx = new DbIndex() { Name = "dboTestTableSearchIdx" };
            SqlServerActionDoer dbService = new SqlServerActionDoer(TestInfo.getSqlDbContextManager());
            Task<bool> t = dbService.CheckTableIndexExistsAsync(tbl, idx);
            t.Wait();
            Assert.IsTrue(t.IsCompleted);
            Assert.IsTrue(t.Result);
        }

        [TestMethod]
        public void CheckTableIndexExistsAsync_NotExists()
        {
            IDbTable tbl = new DbTable() { Schema = "dbo", Name = "TestTable" };
            IDbIndex idx = new DbIndex() { Name = "FakedboTestTableSearchIdx" };
            SqlServerActionDoer dbService = new SqlServerActionDoer(TestInfo.getSqlDbContextManager());
            Task<bool> t = dbService.CheckTableIndexExistsAsync(tbl, idx);
            t.Wait();
            Assert.IsTrue(t.IsCompleted);
            Assert.IsFalse(t.Result);
        }


        // CheckTableTriggerExistsAsync

        [TestMethod]
        public void CheckTableTriggerExistsAsync_Exists()
        {
            IDbTable tbl = new DbTable() { Schema = "dbo", Name = "TestTable" };
            IDbTrigger trg = new DbTrigger() { Name = "TestTableTrg" };
            SqlServerActionDoer dbService = new SqlServerActionDoer(TestInfo.getSqlDbContextManager());
            Task<bool> t = dbService.CheckTableTriggerExistsAsync(tbl, trg);
            t.Wait();
            Assert.IsTrue(t.IsCompleted);
            Assert.IsTrue(t.Result);
        }

        [TestMethod]
        public void CheckTableTriggerExistsAsync_NotExists()
        {
            IDbTable tbl = new DbTable() { Schema = "dbo", Name = "TestTable" };
            IDbTrigger trg = new DbTrigger() { Name = "FakeTestTableTrg" };
            SqlServerActionDoer dbService = new SqlServerActionDoer(TestInfo.getSqlDbContextManager());
            Task<bool> t = dbService.CheckTableTriggerExistsAsync(tbl, trg);
            t.Wait();
            Assert.IsTrue(t.IsCompleted);
            Assert.IsFalse(t.Result);
        }

        
        
        // CheckViewExists

        [TestMethod]
        public void CheckViewExistsAsync_Exists()
        {
            IDbView vw = new DbView() { Schema = "dbo", Name = "vTestTable" };
            SqlServerActionDoer dbService = new SqlServerActionDoer(TestInfo.getSqlDbContextManager());
            Task<bool> t = dbService.CheckViewExistsAsync(vw);
            t.Wait();
            Assert.IsTrue(t.IsCompleted);
            Assert.IsTrue(t.Result);
        }

        [TestMethod]
        public void CheckViewExistsAsync_NotExists()
        {
            IDbView vw = new DbView() { Schema = "dbo", Name = "FakevTestTable" };
            SqlServerActionDoer dbService = new SqlServerActionDoer(TestInfo.getSqlDbContextManager());
            Task<bool> t = dbService.CheckViewExistsAsync(vw);
            t.Wait();
            Assert.IsTrue(t.IsCompleted);
            Assert.IsFalse(t.Result);
        }



        // CheckViewFieldExists

        [TestMethod]
        public void CheckViewFieldExistsAsync_Exists()
        {
            IDbView vw = new DbView() { Schema = "dbo", Name = "vTestTable" };
            IDbField fld = new DbField() { Name = "id" };
            SqlServerActionDoer dbService = new SqlServerActionDoer(TestInfo.getSqlDbContextManager());
            Task<bool> t = dbService.CheckViewFieldExistsAsync(vw, fld);
            t.Wait();
            Assert.IsTrue(t.IsCompleted);
            Assert.IsTrue(t.Result);
        }

        [TestMethod]
        public void CheckViewFieldExistsAsync_NotExists()
        {
            IDbView vw = new DbView() { Schema = "dbo", Name = "vTestTable" };
            IDbField fld = new DbField() { Name = "FakeId" };
            SqlServerActionDoer dbService = new SqlServerActionDoer(TestInfo.getSqlDbContextManager());
            Task<bool> t = dbService.CheckViewFieldExistsAsync(vw, fld);
            t.Wait();
            Assert.IsTrue(t.IsCompleted);
            Assert.IsFalse(t.Result);
        }




        // CheckIndexExists

        [TestMethod]
        public void CheckIndexExistsAsync_Exists()
        {
            IDbIndex idx = new DbIndex() { Name = "dboTestTableSearchIdx" };
            SqlServerActionDoer dbService = new SqlServerActionDoer(TestInfo.getSqlDbContextManager());
            Task<bool> t = dbService.CheckIndexExistsAsync(idx);
            t.Wait();
            Assert.IsTrue(t.IsCompleted);
            Assert.IsTrue(t.Result);
        }

        [TestMethod]
        public void CheckIndexExistsAsync_NotExists()
        {
            IDbIndex idx = new DbIndex() { Name = "FakedboTestTableSearchIdx" };
            SqlServerActionDoer dbService = new SqlServerActionDoer(TestInfo.getSqlDbContextManager());
            Task<bool> t = dbService.CheckIndexExistsAsync(idx);
            t.Wait();
            Assert.IsTrue(t.IsCompleted);
            Assert.IsFalse(t.Result);
        }



        // CheckTriggerExists

        [TestMethod]
        public void CheckTriggerExistsAsync_Exists()
        {
            IDbTrigger trg = new DbTrigger() { Name = "TestTableTrg" };
            SqlServerActionDoer dbService = new SqlServerActionDoer(TestInfo.getSqlDbContextManager());
            Task<bool> t = dbService.CheckTriggerExistsAsync(trg);
            t.Wait();
            Assert.IsTrue(t.IsCompleted);
            Assert.IsTrue(t.Result);
        }

        [TestMethod]
        public void CheckTriggerExistsAsync_NotExists()
        {
            IDbTrigger trg = new DbTrigger() { Name = "FakeTestTableTrg" };
            SqlServerActionDoer dbService = new SqlServerActionDoer(TestInfo.getSqlDbContextManager());
            Task<bool> t = dbService.CheckTriggerExistsAsync(trg);
            t.Wait();
            Assert.IsTrue(t.IsCompleted);
            Assert.IsFalse(t.Result);
        }




    }



}
