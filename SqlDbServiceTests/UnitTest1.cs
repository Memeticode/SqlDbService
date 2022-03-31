
using Dapper;

namespace SqlDbServiceTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string cnstr = "Server=tcp:shittyfreeappsdb.database.windows.net,1433;Initial Catalog=MyApp;Persist Security Info=False;User ID=Thatcher;Password=Sql.Account1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            var b = new SqlDbContextManager();
            b.Server = "tcp:shittyfreeappsdb.database.windows.net,1433";
            b.Db = "MyApp";
            b.Username = "Thatcher";
            b.Password = "Sql.Account1";
            b.ConnectionTimeout = 30;
            //var f = b.GetConnectionString();

            //b.ConnectionString = cnstr;
            b.SqlSoftware = SqlDbSoftware.SqlServer;

            //SqlServerActionDoer dbService = new SqlServerActionDoer(b);
            //var x = dbService.GetTables();
            //var t = 1;

        }
    }
}