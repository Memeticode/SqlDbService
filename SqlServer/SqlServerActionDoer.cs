
namespace SqlDbService.SqlServer;



public class SqlServerActionDoer : SqlServerDb, ISqlDbActionDoerAsync
{
	private ISqlDbActionScripter scripter { get; set; }

	public SqlServerActionDoer(SqlDbContextManager contextManager) : base(contextManager)
	{
		scripter = contextManager.GetDbScripter();
	}

    public async Task<bool> CheckSchemaNameExistsAsync(string schema)
    {
        bool res = await QuerySingleAsync<bool>(scripter.CheckSchemaExists(), new { schemaName = schema });
        return res;
    }

    public async Task<bool> CheckTableExistsAsync(IDbTable table)
    {
        bool res = await QuerySingleAsync<bool>(scripter.CheckTableExists(), new { tableName = table.Name, schemaName = table.Schema});
        return res;
    }

    public async Task<bool> CheckTableFieldExistsAsync(IDbTable table, IDbField field)
    {
        bool res = await QuerySingleAsync<bool>(scripter.CheckTableFieldExists(), new { tableName = table.Name, schemaName = table.Schema, fieldName = field.Name });
        return res;
    }

    public async Task<bool> CheckTablePkIndexExistsAsync(IDbTable table)
    {
        bool res = await QuerySingleAsync<bool>(scripter.CheckTablePkIndexExists(), new { tableName = table.Name, schemaName = table.Schema });
        return res;
    }

    public async Task<bool> CheckTableIndexExistsAsync(IDbTable table, IDbIndex index)
    {
        bool res = await QuerySingleAsync<bool>(scripter.CheckTableIndexExists(), new { tableName = table.Name, schemaName = table.Schema, indexName = index.Name });
        return res;
    }

    public async Task<bool> CheckTableTriggerExistsAsync(IDbTable table, IDbTrigger trigger)
    {
        bool res = await QuerySingleAsync<bool>(scripter.CheckTableTriggerExists(), new { tableName = table.Name, schemaName = table.Schema, triggerName = trigger.Name });
        return res;
    }

    public async Task<bool> CheckViewExistsAsync(IDbView view)
    {
        bool res = await QuerySingleAsync<bool>(scripter.CheckViewExists(), new { viewName = view.Name, schemaName = view.Schema });
        return res;
    }

    public async Task<bool> CheckViewFieldExistsAsync(IDbView view, IDbField field)
    {
        bool res = await QuerySingleAsync<bool>(scripter.CheckViewFieldExists(), new { viewName = view.Name, schemaName = view.Schema, fieldName = field.Name });
        return res;
    }

    public async Task<bool> CheckIndexExistsAsync(IDbIndex index)
    {
        bool res = await QuerySingleAsync<bool>(scripter.CheckIndexExists(), new { indexName = index.Name });
        return res;
    }

    public async Task<bool> CheckTriggerExistsAsync(IDbTrigger trigger)
    {
        bool res = await QuerySingleAsync<bool>(scripter.CheckTriggerExists(), new { triggerName = trigger.Name });
        return res;
    }
}


