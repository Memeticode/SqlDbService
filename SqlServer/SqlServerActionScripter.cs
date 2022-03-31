
namespace SqlDbService.SqlServer;

public class SqlServerActionScripter : ISqlDbActionScripter
{

    //// Checking objects exist in DB
    private string getCheckExistsWrapper(string script) => $@"
        if exists({script})
		begin 
			select 1; 
		end
		else begin
			select 0;
		end";

	public string CheckSchemaExists() =>
		getCheckExistsWrapper(@"
			select 1
			from sys.schemas s
			where s.name = @schemaName");

	// Table
	public string CheckTableExists() => 
        getCheckExistsWrapper(@"
			select 1
			from sys.schemas s
			join sys.tables t on s.schema_id = t.schema_id
			where s.name = @schemaName
			and t.name = @tableName");

    public string CheckTableFieldExists() =>
        getCheckExistsWrapper(@"
			select 1
			from sys.schemas s
			join sys.tables t on s.schema_id = t.schema_id
			join sys.columns c on t.object_id = c.object_id
			where s.name = @schemaName
			and t.name = @tableName
			and c.name = @fieldName");
    public string CheckTablePkIndexExists() =>
        getCheckExistsWrapper(@"
			select 1
			from sys.schemas s
			join sys.tables t on s.schema_id = t.schema_id
			join sys.indexes i on t.object_id = i.object_id
			where i.is_primary_key = 1
			and s.name = @schemaName
			and t.name = @tableName");
    public string CheckTableIndexExists() =>
        getCheckExistsWrapper(@"
			select 1
			from sys.schemas s
			join sys.tables t on s.schema_id = t.schema_id
			join sys.indexes i on t.object_id = i.object_id
			where s.name = @schemaName
			and t.name = @tableName
			and i.name = @indexName");
    public string CheckTableTriggerExists() =>	// trigger and table must be in same schema
		getCheckExistsWrapper(@"
			select 1
			from sys.schemas s
			join sys.tables t on s.schema_id = t.schema_id
			join sys.triggers g on t.object_id = g.parent_id
			where s.name = @schemaName
			and t.name = @tableName
			and g.name = @triggerName");

	// View
	public string CheckViewExists() =>
        getCheckExistsWrapper(@"
			select 1
			from sys.schemas s
			join sys.views v on s.schema_id = v.schema_id
			where s.name = @schemaName
			and v.name = @viewName");
    public string CheckViewFieldExists() =>
        getCheckExistsWrapper(@"
			select 1
			from sys.schemas s
			join sys.views v on s.schema_id = v.schema_id
			join sys.columns c on c.object_id = c.object_id
			where s.name = @schemaName
			and v.name = @viewName
			and c.name = @fieldName");



	// Index
	public string CheckIndexExists() =>
		getCheckExistsWrapper(@"
			select 1
			from sys.indexes i
			where i.name = @indexName");

	// Trigger
	public string CheckTriggerExists() =>
		getCheckExistsWrapper(@"
			select 1
			from sys.triggers g
			where g.name = @triggerName");




	//// Retrieve Db object metadata

	// Table
	public string GetTables() => @"
	    select s.name as [Schema]
		    , t.name as [Name]
	    from sys.schemas s
	    join sys.tables t on s.schema_id = t.schema_id
	    ";

    public string GetTable(IDbTable table) => @"
	    select s.name as [Schema]
		    , t.name as [Name]
	    from sys.schemas s
	    join sys.tables t on s.schema_id = t.schema_id
		where s.name = @schemaName
		and t.name = @tableName
	    ";

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
