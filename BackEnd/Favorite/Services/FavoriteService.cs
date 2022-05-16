using Favorite.Configurations;
using Favorite.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Favorite.Services
{
    public class FavoriteService
    {
        private readonly IMongoCollection<Favorites> _favorite;
        private readonly DeveloperDatabaseConfiguration _settings;

        public FavoriteService(IOptions<DeveloperDatabaseConfiguration> settings)
        {
            _settings = settings.Value;
            var client = new MongoClient(_settings.ConnectionString);
            var database = client.GetDatabase(_settings.DatabaseName);
            _favorite = database.GetCollection<Favorites>(_settings.FavoriteCollectionName);
        }

        public async Task<List<Favorites>> GetAllAsync()
        {
            return await _favorite.Find(c => true).ToListAsync();
        }

        public async Task<Favorites> GetByIdAsync(string id)
        {
            return await _favorite.Find<Favorites>(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Favorites> CreateAsync(Favorites favorite)
        {
            await _favorite.InsertOneAsync(favorite);
            return favorite;
        }

        public async Task UpdateAsync(string id, Favorites favorite)
        {
            await _favorite.ReplaceOneAsync(c => c.Id == id, favorite);
        }

        public async Task DeleteAsync(string id)
        {
            await _favorite.DeleteOneAsync(c => c.Id == id);
        }
    }
}
