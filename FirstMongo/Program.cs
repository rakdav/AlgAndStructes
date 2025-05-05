using FirstMongo;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
MongoClient client = new MongoClient("mongodb://localhost:27017");
//просмотр и удаление база данных
//using (var cursor = await client.ListDatabasesAsync())
//{
//    var databases = cursor.ToList();
//    foreach (var database in databases)
//    {
//        Console.WriteLine(database);
//    }
//}
//await client.DropDatabaseAsync("users");

//Создание коллекции
var db = client.GetDatabase("test");
//await db.CreateCollectionAsync("people");

//Получение списка коллекций
//var collections = await db.ListCollectionNamesAsync();
//foreach (var collection in collections.ToList())
//{
//    Console.WriteLine(collection);
//}

//Переименование коллекции
//await db.RenameCollectionAsync("people", "users");

//Удаление коллекции
//await db.DropCollectionAsync("users");

//Получение коллекции
//IMongoCollection<BsonDocument> users = db.GetCollection<BsonDocument>("users");
//BsonElement el = new BsonElement("name", new BsonString("Tom"));
//Console.WriteLine(el);
//Console.WriteLine(el.Name);
//Console.WriteLine(el.Value);

//BsonDocument doc = new BsonDocument();
//Console.WriteLine(doc);

//BsonElement name = new BsonElement("name", "Tom");
//BsonDocument doc = new BsonDocument(name);
//Console.WriteLine(doc);

//BsonDocument doc = new BsonDocument
//{
//    {"name","Tom"},
//    {"age", 38},
//    { "company", new BsonDocument{{"name" , "microsoft"}}},
//    {"languages", new BsonArray{"english", "german", "spanish" } }
//};
//Обращение к полям документа
//Console.WriteLine(doc);
//Console.WriteLine(doc["name"]);
//Console.WriteLine(doc["languages"]);
//doc["age"] = 22;
//Console.WriteLine(doc["age"]);
//BsonElement email = new BsonElement("email", "tom@localhost.com");
//doc.Add(email);
//Console.WriteLine(doc);
//doc.Remove("email");
//Console.WriteLine(doc);

//Person person = new Person { Name = "Tom", Age = 38 };
//person.Company = new Company { Name = "Microsoft" };
//Console.WriteLine(person.ToJson());
BsonDocument doc = new BsonDocument
{
    {"name","Tom"},
    {"age", 38},
    { "company", new BsonDocument{{"name" , "microsoft"}}},
    {"languages", new BsonArray{"english", "german", "spanish" } }
};
Person person = BsonSerializer.Deserialize<Person>(doc);
Console.WriteLine(person.ToJson());