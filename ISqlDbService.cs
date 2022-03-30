using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlDbService;


// Provides interface for running scripts (queries or statements) in a SQL database
public interface ISqlDbService
{
	public IEnumerable<TResult> Query<TResult>(string sql, object? param = null, CommandType? commandType = null);
	public Task<IEnumerable<TResult>> QueryAsync<TResult>(string sql, object? param = null, CommandType? commandType = null);

	public TResult QuerySingle<TResult>(string sql, object? param = null, CommandType? commandType = null);
	public Task<TResult> QuerySingleAsync<TResult>(string sql, object? param = null, CommandType? commandType = null);

	public int Execute(string sql, object? param = null, CommandType? commandType = null);
	public Task<int> ExecuteAsync(string sql, object? param = null, CommandType? commandType = null);

}

public interface ISqlDbMetadataService : ISqlDbService
{
	public IEnumerable<IDbTable> GetTables();
	public Task<IEnumerable<IDbTable>> GetTablesAsync();
}


public interface ISqlDbDataService : ISqlDbMetadataService
{
}


public abstract class AbstractSqlDbService: ISqlDbService
{
	public ISqlDbContextManager _contextManager { get; set; }
	public string? _Connection => _contextManager.GetConnectionString();

	public AbstractSqlDbService(ISqlDbContextManager contextManager) { _contextManager = contextManager; }


	public IEnumerable<TResult> Query<TResult>(string sql, object? param = null, CommandType? commandType = null)
	{
		try
		{
			using (var connection = new SqlConnection(_Connection))
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
			using (var connection = new SqlConnection(_Connection))
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
			using (var connection = new SqlConnection(_Connection))
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
			using (var connection = new SqlConnection(_Connection))
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
			using (var connection = new SqlConnection(_Connection))
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
			using (var connection = new SqlConnection(_Connection))
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

// Exceptions
public class ExecuteSqlException : Exception
{
	public ExecuteSqlException(Exception e) : base("Unable to execute sql!", e) { }
}
public class QueryDataException : Exception
{
	public QueryDataException(Exception e) : base("Unable to query data!", e) { }
}




public class SqlDbDataService : AbstractSqlDbService, ISqlDbDataService
{
	public ISqlDbScripter _scripter { get; set; }

	public SqlDbDataService(ISqlDbContextManager contextManager) : base(contextManager)
    {
		_scripter = contextManager.GetDbScripter();
    }

    public IEnumerable<IDbTable> GetTables()
	{
		string script = _scripter.GetTables();
		try
		{
			return Query<DbTable>(script).ToArray();
				//.Select(t =>
				//{
				//	t.Fields = GetTableFields(t);
				//	t.PkIndex = GetTablePkIndex(t);
				//	return t;
				//}).ToArray();
		}
		catch (Exception e)
		{
			throw new Exception($"Unable to get tables from database!", e);
		}


	}

	public Task<IEnumerable<IDbTable>> GetTablesAsync()
    {
        throw new NotImplementedException();
    }
}

