using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Mantle.MongoDB;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Mantle.Storage.Dictionary.MongoDB
{
    public class MongoDbDictionaryStorageClient : IDictionaryStorageClient
    {
        private readonly MongoClient mongoDBClient;
        private readonly MongoServer mongoServer;
        private readonly MongoUrl mongoUrl;
        private readonly MongoDatabase mongoDb;
 
        public MongoDbDictionaryStorageClient(IMongoDbConfiguration storageConfiguration)
        {
            if (storageConfiguration == null)
                throw new ArgumentNullException("storageConfiguration");

            storageConfiguration.Validate();

            mongoUrl = new MongoUrl(storageConfiguration.ConnectionString);
            mongoDBClient = new MongoClient(mongoUrl);
            mongoServer = mongoDBClient.GetServer();
            mongoDb = mongoServer.GetDatabase(mongoUrl.DatabaseName);
        }
        public IEnumerable<T> LoadEntities<T>(string dictionaryId)
        {
            throw new NotImplementedException();
        }

        public T LoadEntity<T>(string entityId, string dictionaryId)
        {


            throw new NotImplementedException();
        }

        public T LoadEntity<T>(string entityId)
        {
            throw new NotImplementedException();
        }

        public void Insert<T>(T entity) where T : DictionaryEntity
        {
            var objecId = ObjectId.GenerateNewId();
            Insert(entity, objecId.ToString());
        }

        public void Insert<T>(T entity, string entityId)
        {
            Validate.EntityIdIsProvided(entityId);

            Insert(entity, entityId, typeof(T).Name);
        }

        public void Insert<T>(T entity, string entityId, string dictionaryId)
        {
            Validate.EntityIdIsProvided(entityId);

            Validate.DictionaryIdIsProvided(dictionaryId);

            var collection = mongoDb.GetCollection(entityId);

            var document = new MongoDbDictionaryEntity<T>()
            {
                EntityId = dictionaryId,
                Id = ObjectId.GenerateNewId(),
                Value = entity,

            };

            collection.Insert(document);
        }

        public void Update<T>(T entity) where T : DictionaryEntity
        {
            throw new NotImplementedException();
        }

        public void Update<T>(T entity, string entityId)
        {
            throw new NotImplementedException();
        }

        public void Update<T>(T entity, string entityId, string dictionaryId)
        {
            throw new NotImplementedException();
        }

        public void Delete<T>(T entity) where T : DictionaryEntity
        {
            throw new NotImplementedException();
        }

        public void Delete<T>(string entityId)
        {
            throw new NotImplementedException();
        }

        public void Delete<T>(string entityId, string dictionaryId)
        {
            throw new NotImplementedException();
        }

    }
}
