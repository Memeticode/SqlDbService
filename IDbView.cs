

namespace SqlDbService;
public interface IDbView
{
    public string Schema { get; set; }
    public string Name { get; set; }
}



public class DbView: IDbView
{
    public string Schema { get; set; }
    public string Name { get; set; }
}
