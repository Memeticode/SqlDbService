
namespace SqlDbService;

public interface IDbField
{
    string Name { get; set;  }
}


public class DbField : IDbField
{
    public string Name { get; set; }
}