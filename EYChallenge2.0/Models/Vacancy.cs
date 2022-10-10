using MongoDB.Bson.Serialization.Attributes;

namespace EYChallenge2._0.Models
{
    public class Vacancy
    {
        [BsonId]
        public string id { get; set; }
        public string title { get; set; }
        public string contractPeriod { get; set; }
        public string location { get; set; }
        public string description { get; set; }
        
        public List<string> mandatorySkills { get; set; }
        
        public List<string> softSkills { get; set; }

        public List<string> differentialskills { get; set; }
        public DateTime createDate { get; set; }
        public bool enable { get; set; }
        public bool deleted { get; set; }

    }
}
