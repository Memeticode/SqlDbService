namespace SqlDbService;
public interface IDbTable
{
    public string Schema { get; set; }
    public string Name { get; set; }

    //public void AddField(IDbColumn col);
    //public void AlterField(IDbColumn col);
    //public void DeleteField(IDbColumn col);

}

public class DbTable : IDbTable
{
    public string Schema { get; set; }
    public string Name { get; set; }
}
