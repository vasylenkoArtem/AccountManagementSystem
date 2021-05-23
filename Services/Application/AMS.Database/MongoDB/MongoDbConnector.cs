using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using AMS.Helpers;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;

namespace AMS.Database.MongoDb
{
    public class MongoDbConnector : IMongoDbConnector
    {
        private readonly IMongoDatabase _database;

        public MongoDbConnector(string connectionString)
        {
            var mongodbUrl = new MongoUrl(connectionString);
            var databaseName = mongodbUrl.DatabaseName;
            _database = new MongoClient(mongodbUrl).GetDatabase(databaseName);
        }

        public IMongoCollection<TDocument> GetCollection<TDocument>() => _database.GetCollection<TDocument>(typeof(TDocument).Name);

        public async Task<IEnumerable<TResult>> Get<TDocument, TResult>(PipelineDefinition<TDocument, TResult> pipeline)
        {
            var collection = GetCollection<TDocument>();

            var aggregate = await collection.AggregateAsync<TResult>(
                BsonSerializer.Deserialize<BsonDocument[]>(pipeline.ToString()),
                new AggregateOptions { AllowDiskUse = true });

            return await aggregate.ToListAsync();
        }

        public async Task<bool> Add<TDocument>(IEnumerable<TDocument> documents)
        {
            var collection = GetCollection<TDocument>();

            try
            {
                await collection.InsertManyAsync(documents);
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        public async Task<long> Delete<TDocument>(FilterDefinition<TDocument> filter)
        {
            var collection = GetCollection<TDocument>();

            var result = await collection.DeleteManyAsync(filter);

            return result.DeletedCount;
        }

        public async Task DropCollection<TDocument>()
        {
            await _database.DropCollectionAsync(typeof(TDocument).Name);
        }
    }
}