using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlDbService;


public class SqlTable { }
public interface ISqlRecord { }
public class SqlRecord: ISqlRecord
{

	public JObject data { get; set; }
	public bool IsUpdated { get; set; }
	public bool IsDeleted { get; set; }
	private SqlTable _table { get; set; }
	public SqlRecord(SqlTable table, string jsonStr)
	{
		_table = table;
		data = JObject.Parse(jsonStr);
		IsUpdated = false;
		IsDeleted = false;

	}


	// add db type casting validation here 
	public void Set(string fieldName, string value)
	{
		data[fieldName] = value;
	}
	public string? Get(string fieldName)
	{
		if (data.TryGetValue(fieldName, out var res))
			return res.ToString();
		else
			return null;
	}

}