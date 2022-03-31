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
public interface ISqlDb
{
	public IEnumerable<TResult> Query<TResult>(string sql, object? param = null, CommandType? commandType = null);
	public Task<IEnumerable<TResult>> QueryAsync<TResult>(string sql, object? param = null, CommandType? commandType = null);

	public TResult QuerySingle<TResult>(string sql, object? param = null, CommandType? commandType = null);
	public Task<TResult> QuerySingleAsync<TResult>(string sql, object? param = null, CommandType? commandType = null);

	public int Execute(string sql, object? param = null, CommandType? commandType = null);
	public Task<int> ExecuteAsync(string sql, object? param = null, CommandType? commandType = null);

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

