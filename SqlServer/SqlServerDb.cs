namespace SqlDbService.SqlServer;



public class SqlServerDb : ISqlDb
{
	private SqlDbContextManager contextManager { get; set; }
	private string? connectionString => contextManager.GetConnectionString();

	public SqlServerDb(SqlDbContextManager setContextManager) { contextManager = setContextManager; }


	public IEnumerable<TResult> Query<TResult>(string sql, object? param = null, CommandType? commandType = null)
	{
		try
		{
			using (var connection = new SqlConnection(connectionString))
			{
				return connection.Query<TResult>(sql, param, null, false, null, commandType).ToArray();
			}
		}
		catch (Exception e)
		{
			throw new QueryDataException(e);
		}
	}
	public async Task<IEnumerable<TResult>> QueryAsync<TResult>(string sql, object? param = null, CommandType? commandType = null)
	{
		try
		{
			using (var connection = new SqlConnection(connectionString))
			{
				return await connection.QueryAsync<TResult>(sql, param, null, null, commandType);
			}
		}
		catch (Exception e)
		{
			throw new QueryDataException(e);
		}
	}
	public TResult QuerySingle<TResult>(string sql, object? param = null, CommandType? commandType = null)
	{
		try
		{
			using (var connection = new SqlConnection(connectionString))
			{
				return connection.QuerySingle<TResult>(sql, param, null, null, commandType);
			}
		}
		catch (Exception e)
		{
			throw new QueryDataException(e);
		}
	}
	public async Task<TResult> QuerySingleAsync<TResult>(string sql, object? param = null, CommandType? commandType = null)
	{
		try
		{
			using (var connection = new SqlConnection(connectionString))
			{
				return await connection.QuerySingleAsync<TResult>(sql, param, null, null, commandType);
			}
		}
		catch (Exception e)
		{
			throw new QueryDataException(e);
		}
	}

	public int Execute(string sql, object? param = null, CommandType? commandType = null)
	{
		try
		{
			using (var connection = new SqlConnection(connectionString))
			{
				return connection.Execute(sql, param, null, null, commandType);
			}
		}
		catch (Exception e)
		{
			throw new ExecuteSqlException(e);
		}
	}
	public async Task<int> ExecuteAsync(string sql, object? param = null, CommandType? commandType = null)
	{
		try
		{
			using (var connection = new SqlConnection(connectionString))
			{
				return await connection.ExecuteAsync(sql, param, null, null, commandType);
			}
		}
		catch (Exception e)
		{
			throw new ExecuteSqlException(e);
		}
	}


}