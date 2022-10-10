using EYChallenge2._0.Data.Configuration;
using EYChallenge2._0.Data.Repositories.Interfaces;
using EYChallenge2._0.Models;
using MongoDB.Driver;

namespace EYChallenge2._0.Data.Repositories
{
    public class UserVacanccyRepository : IUserVacancyRepository
    {

        private readonly IMongoCollection<UserVacancy> _collection;

        public UserVacanccyRepository(IDatabaseConfig dbConfig)
        {
            var client = new MongoClient(dbConfig.ConnectionString);
            var database = client.GetDatabase(dbConfig.DatabaseName);
            _collection = database.GetCollection<UserVacancy>("UserVacancy");
        }


        public void Add(UserVacancy apply)
        {
            _collection.InsertOne(apply);
        }

        public void Delete(string userId, string vacancyId)
        {
            _collection.DeleteOne(uv => uv.userId == userId && uv.vacancyId == vacancyId);
        }

        public List<UserVacancy> GetByUserId(string userId)
        {
            return _collection.Find<UserVacancy>(u => u.userId == userId).ToList();
        }

        public List<UserVacancy> GetByVacancyId(string vacancyId)
        {
            return _collection.Find<UserVacancy>(u => u.vacancyId == vacancyId).ToList();
        }
    }
}
