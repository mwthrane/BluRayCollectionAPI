using BluRayCollectionAPI.Models;
using MongoDB.Driver;
using Microsoft.Extensions.Options;

namespace BluRayCollectionAPI.Services

{
    public class BluRayService
    {
        private readonly IMongoCollection<Blurays> _blurays;

        public BluRayService(IOptions<DatabaseSettings> settings)
        {
            var mongoClient = new MongoClient(
                settings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(
                               settings.Value.DatabaseName);
           _blurays = mongoDatabase.GetCollection<Blurays>(
                               settings.Value.BluraysCollectionName);
        }

        public async Task<List<Blurays>> GetBluraysAsync() =>
            await _blurays.Find(Blurays => true).ToListAsync();
        public async Task<Blurays?> GetBlurayAsync(string id) =>
            await _blurays.Find<Blurays>(x => x.Id == id)
                .FirstOrDefaultAsync();
        public async Task CreateAsync(Blurays bluray) =>
            await _blurays.InsertOneAsync(bluray);
        public async Task UpdateAsync(string id, Blurays blurayIn) =>
            await _blurays.ReplaceOneAsync(x => x.Id == id, blurayIn);
        public async Task RemoveAsync(string id) =>
            await _blurays.DeleteOneAsync(x => x.Id == id);
    }
}
