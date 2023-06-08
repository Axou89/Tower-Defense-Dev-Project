using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MongoDB.Driver;

public class MongoDB : MonoBehaviour
{

    private MongoClient client;
    private IMongoDatabase database;
    private IMongoCollection<User> userCollection;
    // Start is called before the first frame update
    void Start()
    {
        // Configurer la connexion MongoDB
        string connectionString = "mongodb://localhost:27017";
        string databaseName = "GameDB";
        string collectionName = "Users";

        // Créer le client MongoDB
        client = new MongoClient(connectionString);

        // Récupérer la base de données et la collection
        database = client.GetDatabase(databaseName);
        userCollection = database.GetCollection<User>(collectionName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void CreateAccount(string username, string password)
    {
        // Créer un nouvel utilisateur
        User newUser = new User
        {
            Username = username,
            Password = password
        };

        // Insérer l'utilisateur dans la collection
        userCollection.InsertOne(newUser);

        Debug.Log("Compte créé avec succès !");
    }
}

// Modèle d'utilisateur
public class User
{
    public ObjectId Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
}

}
