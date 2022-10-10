using EYChallenge2._0.Models;

namespace EYChallenge2._0.Data.Repositories.Interfaces
{
    public interface IVacancyRepository
    {
        Vacancy Add(Vacancy vacancy);
        void Update(string id, Vacancy updatedVacancy);
        IEnumerable<Vacancy> GetAll();
        Vacancy GetById(string id);
        void Delete(string id);
        void disable(string id);
    }
}
