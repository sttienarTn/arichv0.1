using UnityEngine;
using MongoDB.Driver;
using MongoDB.Bson;

public class NewBehaviourScript : MonoBehaviour
{   
    private MongoClient client;
    private IMongoDatabase database;
    private IMongoCollection<BsonDocument> collection;

    private void Start()
    {
          string connectionString = "mongodb+srv://Admin:user@cluster0.wukfony.mongodb.net/";
        string databaseName = "test";
        string collectionName = "questions";

        client = new MongoClient(connectionString);
        database = client.GetDatabase(databaseName);
        collection = database.GetCollection<BsonDocument>(collectionName);

               // Fetch data from MongoDB
        var documents = collection.Find(new BsonDocument()).ToList();

        // Display data in the Unity console
        foreach (var document in documents)
        {
            Debug.Log(document.ToJson());
        }

    }
}
