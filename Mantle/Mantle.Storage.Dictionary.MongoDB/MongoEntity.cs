using Microsoft.SqlServer.Server;

namespace Mantle.Storage.Dictionary.MongoDB
{
    public class MongoDictionaryEntity<T>
    {
        public string EntityId { get; set; }
        public string DictionaryId { get; set; }
        private T Data { get; set; }
    }
}