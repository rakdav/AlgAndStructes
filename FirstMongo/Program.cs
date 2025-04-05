using FirstMongo;
using MongoDB.Bson;
using MongoDB.Driver;
MongoClient client = new MongoClient("mongodb://localhost:27017/");
//using(var cursor=await client.ListDatabasesAsync())
//{
//    var db = cursor.ToList();
//	foreach (var item in db)
//	{
//        Console.WriteLine(item);
//	}
//}
//IMongoDatabase dataFirst = client.GetDatabase("first");
//var collection = await dataFirst.ListCollectionNamesAsync();
//foreach (var item in collection.ToList())
//{
//    Console.WriteLine(item);
//}
var dataDB = client.GetDatabase("first");
var firstCollection = dataDB.GetCollection<User>("first_collection");
List<User> users = await firstCollection.Find(new BsonDocument()).ToListAsync();
foreach(var user in users)
{
    Console.WriteLine(user.Name+" "+user.Birthday+" "+user.Money);
}
class User
{
    public ObjectId Id { get; set; }
    public string? Name { get; set; }="";
    public Double Money { get; set; }
    public DateTime? Birthday { get; set; }
}