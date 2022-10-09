using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EYChallenge2._0.Models
{
    public class User
    {
        [BsonId]
        public string id { get;  set; }
        public string name { get;  set; }
        public string email { get;  set; }
        public string password { get;  set; }
        public DateTime? createDate { get;  set; }
        public bool enable { get;  set; }
        public bool deleted { get;  set; }
    }
}
