using MongoDB.Bson;
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
        public string? Name { get; set; }
        public int Age { get; set; }
        public Company? Company { get; set; }
        public List<string>? Languages { get; set; } = new List<string>();
    }
}
