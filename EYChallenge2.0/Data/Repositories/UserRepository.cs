using EYChallenge2._0.Data.Configuration;
using EYChallenge2._0.Data.Repositories.Interfaces;
using EYChallenge2._0.Models;
using EYChallenge2._0.ViewModel;
using MongoDB.Driver;

namespace EYChallenge2._0.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<User> _collection;

        public UserRepository(IDatabaseConfig dbConfig)
        {
            var client = new MongoClient(dbConfig.ConnectionString);
            var database = client.GetDatabase(dbConfig.DatabaseName);
            _collection = database.GetCollection<User>("Users");
        }

        public User Add(User user)
        {
            user.id = Guid.NewGuid().ToString();
            user.createDate = DateTime.Now;
            user.enable = true;
            user.deleted = false;
            _collection.InsertOne(user);
            return user;
        }

        public void Delete(string id)
        {
            User user = GetById(id);
            user.deleted = true;
            user.enable = false;
            _collection.ReplaceOne(u => u.id == id, user);
        }

        public void disable(string id)
        {
            User user = GetById(id);
            user.enable = false;
            _collection.ReplaceOne(u => u.id == id, user);
        }

        public IEnumerable<User> GetAll()
        {
            return _collection.Find<User>(u => true).ToList();
        }

        public User GetById(string id)
        {
            return _collection.Find<User>(u => u.id == id).FirstOrDefault();
        }

        public User LoginUser(LoginViewModel user)
        {
            return _collection.Find<User>(u => u.email == user.email && u.password == user.password && u.deleted == false && u.enable == true).FirstOrDefault();
        }

        public void Update(string id, User updatedUser)
        {
            _collection.ReplaceOne(u => u.id == id, updatedUser);
        }
    }
}
