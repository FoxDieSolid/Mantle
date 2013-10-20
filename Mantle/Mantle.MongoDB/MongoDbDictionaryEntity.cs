using MongoDB.Bson;

namespace Mantle.MongoDB
{
    public class MongoDbDictionaryEntity<T>
    {
        public ObjectId Id { get; set; }
        public string DictionaryId { get; set; }
        public T Value { get; set; }
    }
}