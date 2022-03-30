namespace SqlDbService;


public interface IDb
{
    DbContext dbContext { get; }
    bool Exists();
}

public interface IDbRecord
{
}
public interface IDbRecordSet { }


public interface IProvideData
{
}
//public interface IDbTable : IDb, IProvideData
//{

//}

public interface IDbColumn : IDb
{
    IDbTable table { get; }
}
public interface IDbColumnSet : IDbColumn
{

}
