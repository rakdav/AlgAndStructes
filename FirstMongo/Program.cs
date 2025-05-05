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
var users = db.GetCollection<BsonDocument>("users");
var collection= db.GetCollection<Person>("users");
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

//из BsonDocument в person
//BsonDocument doc = new BsonDocument
//{
//    {"name","Tom"},
//    {"age", 38},
//    { "company", new BsonDocument{{"name" , "microsoft"}}},
//    {"languages", new BsonArray{"english", "german", "spanish" } }
//};
//Person person = BsonSerializer.Deserialize<Person>(doc);
//Console.WriteLine(person.ToJson());


//Сохранение документов в базу данных
//Person->BsonDocument
//Person person = new Person
//{
//    Name = "Tom",
//    Age = 38,
//    Company = new Company { Name = "Microsoft" },
//    Languages = { "english", "german", "spannish" }
//};
//BsonDocument doc = person.ToBsonDocument();
//Console.WriteLine(doc);
//var users = db.GetCollection<BsonDocument>("users");
//await users.InsertOneAsync(doc);
//Person person2 = new Person
//{
//    Name = "Bob",
//    Age = 25,
//    Company = new Company { Name = "Samsung" },
//    Languages = { "english","spannish" }
//};
//Person person3 = new Person
//{
//    Name = "Sam",
//    Age = 29,
//    Company = new Company { Name = "Yandex" },
//    Languages = { "english", "german" }
//};

//BsonDocument doc2 = person2.ToBsonDocument();
//BsonDocument doc3 = person3.ToBsonDocument();
//var users = db.GetCollection<BsonDocument>("users");
//await users.InsertManyAsync(new List<BsonDocument> { doc2,doc3});

//Получение документов из базы данных
List<BsonDocument> userList = await users.Find(new BsonDocument()).ToListAsync();
foreach (var user in userList)
{
    Console.WriteLine(user);
}
List<Person> listUsers = await collection.Find(new BsonDocument()).ToListAsync();
foreach (var user in listUsers)
{
    Console.WriteLine($"{user.Name} - {user.Age}");
}
long size = await collection.Find(new BsonDocument()).CountDocumentsAsync();
Console.WriteLine(size);

//Фильтрация
//var filter = new BsonDocument { { "Name", "Tom" }, { "Years", 38 } };
//List<BsonDocument> toms = await users.Find(filter).ToListAsync();
//foreach(var user in toms)
//{
//    Console.WriteLine(user);
//}

//Логические операторы
//Логические операторы выполняются над условиями выборки:

//$or: соединяет два условия, и документ должен соответствовать одному из этих условий

//$and: соединяет два условия, и документ должен соответствовать обоим условиям

//$not: документ должен НЕ соответствовать условию

//$nor: соединяет два условия, и документ должен НЕ соответстовать обоим условиям

//$eq(равно)

//$ne(не равно)

//$gt(больше чем)

//$lt(меньше чем)

//$gte(больше или равно)

//$lte(меньше или равно)

//$in определяет массив значений, одно из которых должно иметь поле документа

//$nin определяет массив значений, которые не должно иметь поле документа
//var filter = new BsonDocument("$or", new BsonArray{

//    new BsonDocument("Age",new BsonDocument("$gte", 33)),
//    new BsonDocument("Name", "Tom")
//});
var filter = new BsonDocument(new BsonDocument("Years", new BsonDocument("$gte", 10)));

var userFilter = await users.Find(filter).ToListAsync();
foreach (var user in userFilter)
{
    Console.WriteLine(user);
}