namespace SqlDbService;
public interface IDbTrigger
{
    public string Schema { get; set; }
    public string Name { get; set; }
}

public class DbTrigger : IDbTrigger
{
    public string Schema { get; set; }
    public string Name { get; set; }
}