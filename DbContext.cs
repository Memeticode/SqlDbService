namespace SqlDbService;


public class SqlDb
{
    public const string ConnectionString = "defc";
    //public SqlDb() : base(Cnxn) { }

}

public interface ISqlDbContextManager
{
    public string GetConnectionString();
    public ISqlDbScripter GetDbScripter();
}

public enum SqlDbSoftware
{
    SqlServer
}
public class SqlDbContextManager : ISqlDbContextManager
{
    public string? Server { get; set; }
    public string? Db { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
    public int? ConnectionTimeout { get; set; }

    public SqlDbSoftware SqlSoftware { get; set;}

    public string? ConnectionString { get; set; }

    public string GetConnectionString()
    {
        if (ConnectionString is null)
        {
            var cb = new DbConnectionStringBuilder();
            cb.Add("Server", Server ?? "");
            cb.Add("Initial Catalog", Db ?? "");
            cb.Add("Persist Security Info", false);
            cb.Add("User ID", Username ?? "");
            cb.Add("Password", Password ?? "");
            cb.Add("MultipleActiveResultSets", false);
            cb.Add("Encrypt", true);
            cb.Add("TrustServerCertificate", false);
            cb.Add("Connection Timeout", ConnectionTimeout ?? 30);
            return $"{cb.ConnectionString};";
        }
        else
        {
            return ConnectionString;
        }
    }

    public ISqlDbScripter GetDbScripter()
    {
        switch (SqlSoftware)
        {
            case SqlDbSoftware.SqlServer:
                return new SqlServerDbScripter();
            default:
                throw new InvalidDataException("No scripter exists for specified Sql software type!");
        }
    }


}
