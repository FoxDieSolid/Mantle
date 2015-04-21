namespace Mantle.Document.Interfaces
{
    public interface IDocumentDatabaseClient
    {
        void DeleteDatabase(string databaseName);
        bool DatabaseExists(string entityId, string partitionId);
    }
}