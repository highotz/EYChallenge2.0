using EYChallenge2._0.Data.Configuration;
using EYChallenge2._0.Data.Repositories.Interfaces;
using EYChallenge2._0.Models;
using MongoDB.Driver;

namespace EYChallenge2._0.Data.Repositories
{
    public class VacancyRepository : IVacancyRepository
    {
        private readonly IMongoCollection<Vacancy> _collection;

        public VacancyRepository(IDatabaseConfig dbConfig)
        {
            var client = new MongoClient(dbConfig.ConnectionString);
            var database = client.GetDatabase(dbConfig.DatabaseName);
            _collection = database.GetCollection<Vacancy>("vacancies");
        }
        public Vacancy Add(Vacancy vacancy)
        {
            vacancy.id = Guid.NewGuid().ToString();
            vacancy.createDate = DateTime.Now;
            vacancy.deleted = false;
            vacancy.enable = true;
            _collection.InsertOne(vacancy);
            return vacancy;
        }

        public void Delete(string id)
        {
            Vacancy vacancy = GetById(id);
            vacancy.deleted = true;
            vacancy.enable = false;
            _collection.ReplaceOne(u => u.id == id, vacancy);
        }

        public void disable(string id)
        {
            Vacancy vacancy = GetById(id);
            vacancy.enable = false;
            _collection.ReplaceOne(u => u.id == id, vacancy);
        }

        public IEnumerable<Vacancy> GetAll()
        {
            return _collection.Find<Vacancy>(v => true).ToList();
        }

        public Vacancy GetById(string id)
        {
            return _collection.Find<Vacancy>(v => v.id == id).FirstOrDefault();
        }

        public void Update(string id, Vacancy updatedVacancy)
        {
            _collection.ReplaceOne(v => v.id == id, updatedVacancy);
        }
    }
}
