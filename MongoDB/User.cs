using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDB
{
    public class User
    {
        public User( int id,string name, string email, int age)
        {
        _id = id;
            Name = name;
            Email = email;
            Age = age;
        }

        public User(int id, string name, string email, int age, int diplomNumber) : this(id,name, email, age)
        {
            DiplomNumber = diplomNumber;
        }
        [BsonIgnoreIfDefault]
        public int _id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        [BsonIgnoreIfDefault]
        public int DiplomNumber { get; set; }
    }
}
