
namespace SqlDbService;

public class SqlServerDbScripter : ISqlDbScripter
{

    //// Checking objects exist in DB

    // Table
    public string CheckTableExists(IDbTable table) { throw new NotImplementedException(); }
    public string CheckTableFieldExists(IDbTable table, IDbField field) { throw new NotImplementedException(); }
    public string CheckTablePkIndexExists() { throw new NotImplementedException(); }
    public string CheckTableIndexExists() { throw new NotImplementedException(); }
    public string CheckTableTriggerExists() { throw new NotImplementedException(); }

    // View
    public string CheckViewExists() { throw new NotImplementedException(); }
    public string CheckViewFieldExists() { throw new NotImplementedException(); }



    //// Retrieve Db object metadata

    // Table
    public string GetTables() => @"
	    select s.name as [Schema]
		    , t.name as [Name]
	    from sys.schemas s
	    join sys.tables t on s.schema_id = t.schema_id
	    ";

    public string GetTable(IDbTable table) { throw new NotImplementedException(); }
    public string GetTableFields(IDbTable table) { throw new NotImplementedException(); }
    public string GetTableField(IDbTable table, IDbField field) { throw new NotImplementedException(); }
    public string GetTablePkIndex(IDbTable table) { throw new NotImplementedException(); }
    public string GetTableIndexes(IDbTable table) { throw new NotImplementedException(); }
    public string GetTableIndex(IDbTable table, IDbIndex index) { throw new NotImplementedException(); }
    public string GetTableTriggers(IDbTable table) { throw new NotImplementedException(); }
    public string GetTableTrigger(IDbTable table, IDbTrigger trigger) { throw new NotImplementedException(); }
    public string GetTableTriggerDependencies(IDbTable table, IDbTrigger trigger) { throw new NotImplementedException(); }
    public string GetTableDependants(IDbTable table) { throw new NotImplementedException(); }


    // View
    public string GetViews() { throw new NotImplementedException(); }
    public string GetView(IDbView view) { throw new NotImplementedException(); }
    public string GetViewDependencies(IDbView view) { throw new NotImplementedException(); }
    public string GetViewDependants(IDbView view) { throw new NotImplementedException(); }


    //// Create/Update/Delete DB objects

    // Table
    public string CreateTable(IDbTable table) { throw new NotImplementedException(); }
    public string DeleteTable(IDbTable table) { throw new NotImplementedException(); }

    public string CreateTableField(IDbTable table, IDbField field) { throw new NotImplementedException(); }
    public string AlterTableField(IDbTable table, IDbField field) { throw new NotImplementedException(); }
    public string DeleteTableField(IDbTable table, IDbField field) { throw new NotImplementedException(); }


    public string CreateTablePkIndex(IDbTable table, IDbIndex pkIndex) { throw new NotImplementedException(); }
    public string AlterTablePkIndex(IDbTable table, IDbIndex pkIndex) { throw new NotImplementedException(); }
    public string DeleteTablePkIndex(IDbTable table, IDbIndex pkIndex) { throw new NotImplementedException(); }


    public string CreateTableIndex(IDbTable table, IDbIndex pkIndex) { throw new NotImplementedException(); }
    public string AlterTableIndex(IDbTable table, IDbIndex pkIndex) { throw new NotImplementedException(); }
    public string DeleteTableIndex(IDbTable table, IDbIndex pkIndex) { throw new NotImplementedException(); }


    public string CreateTableTrigger(IDbTable table, IDbTrigger pkTrigger) { throw new NotImplementedException(); }
    public string AlterTableTrigger(IDbTable table, IDbTrigger pkTrigger) { throw new NotImplementedException(); }
    public string DeleteTableTrigger(IDbTable table, IDbTrigger pkTrigger) { throw new NotImplementedException(); }


    // View
    public string CreateView(IDbView view) { throw new NotImplementedException(); }
    public string AlterView(IDbView view) { throw new NotImplementedException(); }
    public string DeleteView(IDbView view) { throw new NotImplementedException(); }


}
