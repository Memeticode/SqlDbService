﻿namespace SqlDbService;


public interface ISqlDbActionDoer
{
    //// Checking objects exist in DB

    // Table
    public bool CheckTableExists(IDbTable table);
    public bool CheckTableFieldExists(IDbTable table, IDbField field);
    public bool CheckTablePkIndexExists(IDbTable table);
    public bool CheckTableIndexExists(IDbTable table, IDbIndex index);
    public bool CheckTableTriggerExists(IDbTable table, IDbTrigger trigger);

    // View
    public bool CheckViewExists(IDbView view);
    public bool CheckViewFieldExists(IDbView view, IDbField field);



    //// Retrieve Db object metadata

    // Table
    //public string GetTables();
    //public string GetTable(IDbTable table);
    //public string GetTableFields(IDbTable table);
    //public string GetTableField(IDbTable table, IDbField field);
    //public string GetTablePkIndex(IDbTable table);
    //public string GetTableIndexes(IDbTable table);
    //public string GetTableIndex(IDbTable table, IDbIndex index);
    //public string GetTableTriggers(IDbTable table);
    //public string GetTableTrigger(IDbTable table, IDbTrigger trigger);
    //public string GetTableTriggerDependencies(IDbTable table, IDbTrigger trigger);
    //public string GetTableDependants(IDbTable table);


    //// View
    //public string GetViews();
    //public string GetView(IDbView view);
    //public string GetViewDependencies(IDbView view);
    //public string GetViewDependants(IDbView view);


    ////// Create/Update/Delete DB objects

    //// Table
    //public string CreateTable(IDbTable table);
    //public string DeleteTable(IDbTable table);

    //public string CreateTableField(IDbTable table, IDbField field);
    //public string AlterTableField(IDbTable table, IDbField field);
    //public string DeleteTableField(IDbTable table, IDbField field);


    //public string CreateTablePkIndex(IDbTable table, IDbIndex pkIndex);
    //public string AlterTablePkIndex(IDbTable table, IDbIndex pkIndex);
    //public string DeleteTablePkIndex(IDbTable table, IDbIndex pkIndex);


    //public string CreateTableIndex(IDbTable table, IDbIndex pkIndex);
    //public string AlterTableIndex(IDbTable table, IDbIndex pkIndex);
    //public string DeleteTableIndex(IDbTable table, IDbIndex pkIndex);


    //public string CreateTableTrigger(IDbTable table, IDbTrigger pkTrigger);
    //public string AlterTableTrigger(IDbTable table, IDbTrigger pkTrigger);
    //public string DeleteTableTrigger(IDbTable table, IDbTrigger pkTrigger);


    //// View
    //public string CreateView(IDbView view);
    //public string AlterView(IDbView view);
    //public string DeleteView(IDbView view);

}



public interface ISqlDbActionDoerAsync
{
    //// Checking objects exist in DB

    public Task<bool> CheckSchemaNameExistsAsync(string schema);

    // Table
    public Task<bool> CheckTableExistsAsync(IDbTable table);
    public Task<bool> CheckTableFieldExistsAsync(IDbTable table, IDbField field);
    public Task<bool> CheckTablePkIndexExistsAsync(IDbTable table);
    public Task<bool> CheckTableIndexExistsAsync(IDbTable table, IDbIndex index);
    public Task<bool> CheckTableTriggerExistsAsync(IDbTable table, IDbTrigger trigger);

    // View
    public Task<bool> CheckViewExistsAsync(IDbView view);
    public Task<bool> CheckViewFieldExistsAsync(IDbView view, IDbField field);


    public Task<bool> CheckIndexExistsAsync(IDbIndex index);

    public Task<bool> CheckTriggerExistsAsync(IDbTrigger trigger);
}