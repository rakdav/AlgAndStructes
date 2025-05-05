using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstMongo
{
    class Person
    {
        public ObjectId Id { get; set; }
        //[BsonId]
        //public int PersonId { get; set; }
        public string? Name { get; set; }
        [BsonElement("Years")]
        [BsonIgnoreIfDefault]
        public int Age { get; set; }
        [BsonIgnoreIfNull]
        public Company? Company { get; set; }
        public List<string>? Languages { get; set; } = new List<string>();
    }
}
