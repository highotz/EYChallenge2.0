using EYChallenge2._0.Models;

namespace EYChallenge2._0.Data.Repositories.Interfaces
{
    public interface IUserVacancyRepository
    {
        void Add(UserVacancy apply);
        public void Delete(string userId, string vacancyId);
        public UserVacancy GetByUserId(string userId);
        public List<UserVacancy> GetByVacancyId(string vacancyId);
    }
}
