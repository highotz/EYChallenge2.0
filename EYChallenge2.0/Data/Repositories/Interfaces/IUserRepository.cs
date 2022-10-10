using EYChallenge2._0.Models;
using EYChallenge2._0.ViewModel;

namespace EYChallenge2._0.Data.Repositories.Interfaces
{
    public interface IUserRepository
    {
        User Add(User user);
        void Update(string id, User updatedUser);
        IEnumerable<User> GetAll();
        User GetById(string id);
        void Delete(string id);
        void disable(string id);
        User LoginUser(LoginViewModel user);
    }
}
