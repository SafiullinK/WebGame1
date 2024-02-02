
using MongoDB.Driver;
using System.Windows;

namespace MongoDB
{
    public class CRUD
    {

        public static void CreateUser(User user)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("Users2024");
            var collection = database.GetCollection<User>("UserCollection");
            collection.InsertOne(user);
        }

        public static void GetUser(int id)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("Users2024");
            var collection = database.GetCollection<User>("UserCollection");
            var user = collection.Find(x => x._id == id ).FirstOrDefault();
            if (user == null)
                MessageBox.Show("NotFound");
            else
                MessageBox.Show($"{user.Name} {user.Age}");
        }

        public static void CreateTestTeam(Team team)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("Users2024");
            var collection = database.GetCollection<Team>("UserCollection");
            collection.InsertOne(team);
        }
    }
}
