using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AMS.Database.MongoDb
{
    public interface IMongoDbConnector
    {
        Task<IEnumerable<TResult>> Get<TDocument, TResult>(PipelineDefinition<TDocument, TResult> pipeline);
        Task<bool> Add<TDocument>(IEnumerable<TDocument> documents);
        Task<long> Delete<TDocument>(FilterDefinition<TDocument> filter);
        IMongoCollection<TDocument> GetCollection<TDocument>();
        Task DropCollection<TDocument>();
    }
}