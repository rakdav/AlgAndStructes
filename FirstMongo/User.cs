using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstMongo
{
    public class User
    {
        public ObjectId Id { get; set; }
        public string? Name { get; set; }
        public DateTime Birthday { get; set; }
        public Double Money { get; set; }
    }
}
