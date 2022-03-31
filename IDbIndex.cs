

namespace SqlDbService;
public interface IDbIndex
{
    public string Name { get; set; }

}


public class DbIndex: IDbIndex
{
    public string Name { get; set; }

}
