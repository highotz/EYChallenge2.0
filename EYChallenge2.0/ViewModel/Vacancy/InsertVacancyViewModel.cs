namespace EYChallenge2._0.ViewModel.Vacancy
{
    public class InsertVacancyViewModel
    {
        public string title { get; set; }
        public string contractPeriod { get; set; }
        public string location { get; set; }
        public string description { get; set; }

        public List<string> mandatorySkills { get; set; }

        public List<string> softSkills { get; set; }

        public List<string> differentialskills { get; set; }
    }
}
