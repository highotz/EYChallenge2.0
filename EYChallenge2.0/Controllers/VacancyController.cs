using EYChallenge2._0.Data.Repositories.Interfaces;
using EYChallenge2._0.Models;
using EYChallenge2._0.ViewModel.Vacancy;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EYChallenge2._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacancyController : ControllerBase
    {

        private IVacancyRepository _vacancyRepository;

        public VacancyController(IVacancyRepository vacancyRepository)
        {
            _vacancyRepository = vacancyRepository;
        }



        // GET: api/<VacancyController>
        [HttpGet]
        public IEnumerable<Vacancy> Get()
        {
            return _vacancyRepository.GetAll();
        }

        // GET api/<VacancyController>/5
        [HttpGet("{id}")]
        public Vacancy Get(string id)
        {
            return _vacancyRepository.GetById(id);
        }

        // POST api/<VacancyController>
        [HttpPost]
        public void Post([FromBody] InsertVacancyViewModel vacancy)
        {
            Vacancy Nvacancy = new Vacancy();
            Nvacancy.title = vacancy.title;
            Nvacancy.contractPeriod = vacancy.contractPeriod;
            Nvacancy.location = vacancy.location;
            Nvacancy.description = vacancy.description;
            Nvacancy.mandatorySkills = vacancy.mandatorySkills;
            Nvacancy.softSkills = vacancy.softSkills;
            Nvacancy.differentialskills = vacancy.differentialskills;

            _vacancyRepository.Add(Nvacancy);
        }

        // PUT api/<VacancyController>/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] Vacancy vacancy)
        {
            _vacancyRepository.Update(id, vacancy);
        }

        // DELETE api/<VacancyController>/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _vacancyRepository.Delete(id);
        }

        // DELETE api/<UserController>/5
        [HttpPut("Disable/{id}")]
        public void Disable(string id)
        {
            _vacancyRepository.disable(id);
        }
    }
}
