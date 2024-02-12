using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WebGame1.MongoDB
{
    public class Warrior
    {
        public Warrior(string name, int minstrenght, int strenght, int maxstrenght, int dexterity, int mindexterity, int maxdexterity, int inteligence, int mininteligence, int maxinteligence, int vitality, int minvitality, int maxvitality, int starpoints)
        {
            _name = name;

            _minstrenght = minstrenght;
            _strenght = strenght;
            _maxstrenght = maxstrenght;
            _dexterity = dexterity;
            _mindexterity = mindexterity;
            _maxdexterity = maxdexterity;
            _inteligence = inteligence;
            _mininteligence = mininteligence;
            _maxinteligence = maxinteligence;
            _vitality = vitality;
            _minvitality = minvitality;
            _maxvitality = maxvitality; 
        }




        public string _name { get; set; }
        [BsonIgnoreIfDefault]
        public Object _id { get; set; }
        public int _minstrenght { get; set; }
        private int a;
        public int _strenght
        {
            get { return a; }
            set
            {
                a = value;
                _pdamade = (int)(a);
                _health = (int)(2 * _vitality + a);
            }
        }

        public int _maxstrenght { get; set; }
        private int b;
        public int _dexterity
        {
           get { return b; }
            set
           {
               b = value;
               _armor = (int)(b);
           }
        }

        public int _mindexterity { get; set; }

        public int _maxdexterity { get; set; }
        private int c;
        public int _inteligence
        {
            get { return c; }
            set
           {
               c = value;
              _mana = (int)(c);
               _mdamage = (int)(0.2 * c);
               _mdefence = (int)(0.5 * c);
           }
        }
        public int _mininteligence { get; set; }
        public int _maxinteligence { get; set; }
        private int d;
        public int _vitality
        {
           get { return d; }
           set
           {
               d = value;
               _health = (int)(2 * d + _strenght);
           }
        }
       
        public int _minvitality { get; set; }
        public int _maxvitality { get; set; }
        [BsonIgnoreIfDefault]
        public double _health { get; set; }
        [BsonIgnoreIfDefault]
        public double _mana { get; set; }
        [BsonIgnoreIfDefault]
        public double _pdamade { get; set; }
        [BsonIgnoreIfDefault]
        public double _armor { get; set; }
        [BsonIgnoreIfDefault]
        public double _mdamage { get; set; }
        [BsonIgnoreIfDefault]
        public double _mdefence { get; set; }
        [BsonIgnoreIfDefault]
        public int _crtchance
        {
            get
            {
                return (int)(0.2 * _dexterity);
            }
            set { }
        }
        public int _crtdamage { get { return _dexterity; } set { } }
        [BsonIgnoreIfDefault]
        public int _starpoints { get; set; }

        public static void CreateWarrior(Warrior war)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("Heroes");
            var collection = database.GetCollection<Warrior>("Warrior");
            collection.InsertOne(war);
        }
        public static List<Warrior> GetWarriors()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("Heroes");
            var collection = database.GetCollection<Warrior>("Warrior");
            List<Warrior> result = new List<Warrior>();
            result = collection.Find(x => true).ToList();
            return result;

        }

        internal static List<Warrior> GetWarrior(Warrior warrior)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("Heroes");
            var collection = database.GetCollection<Warrior>("Warrior");
            List<Warrior> result = new List<Warrior>();
            result = collection.Find(x => x._name == warrior._name).ToList();
            return result;
        }
        public static void UpdateWarrior(Warrior warrior)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("Heroes");
            var collection = database.GetCollection<Warrior>("Warrior");
            var filter = Builders<Warrior>.Filter.Eq(i => i._id, warrior._id);
            collection.ReplaceOne(filter, warrior);
        }
        private int g;
        public int _level
        {
            get { return g; }
            set
            {

                g = value;
                if (_starpoints > 1000)
                {
                    g = (_starpoints - (_starpoints % 1000)) / 1000;
                    return;
                }
                if (value >= 99)
                {
                    g = 99;
                }

                _starpoints += 5;
            }
        }
        
        
    }
}
