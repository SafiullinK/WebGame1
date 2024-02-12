using Amazon.Runtime.SharedInterfaces;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;
using WebGame1.Units;

namespace WebGame1.MongoDB
{
    public class Rogue

    {
        public Rogue(string name, int minstrenght, int strenght, int maxstrenght, int dexterity, int mindexterity, int maxdexterity, int inteligence, int mininteligence, int maxinteligence, int vitality, int minvitality, int maxvitality, int starpoints)
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



        [BsonIgnoreIfDefault]
        public string _name { get; set; }
        [BsonIgnoreIfDefault]
        public Object _id { get; set; }
        public int _minstrenght { get; set; }

        private int a;
        public int _strenght { get { return a; }
            set 
            {
                a = value;
                _pdamade = (int)(0.5 * a + 0.5 * _dexterity);
                _health = (int)(1.5 * _vitality + 0.5 * a);
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
                _armor = (int)(1.5 * b);
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
                _mana = (int)(1.2 * c);
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
                _health = (int)(1.5 * d + 0.5 * _strenght);
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
        public int _crtchance { get 
            { 
                return (int)(0.2 * _dexterity); 
            }
            set { } }
        public int _crtdamage { get { return _dexterity; } set { } }



        public static void CreateRogue(Rogue rogue)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("Heroes");
            var collection = database.GetCollection<Rogue>("Rogue");
            collection.InsertOne(rogue);
        }
        public static List<Rogue> GetAllRogue()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("Heroes");
            var collection = database.GetCollection<Rogue>("Rogue");
            List<Rogue> result = new List<Rogue>();
            result = collection.Find(x => true).ToList();
            return result;

        }

        internal static List<Rogue> GetRogue(Rogue currentRogue)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("Heroes");
            var collection = database.GetCollection<Rogue>("Rogue");
            List<Rogue> result = new List<Rogue>();
            result = collection.Find(x => x._name == currentRogue._name).ToList();
            return result;
        }
        public static void UpdateRogue(Rogue rogue)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("Heroes");
            var collection = database.GetCollection<Rogue>("Rogue");
            var filter = Builders<Rogue>.Filter.Eq(i => i._id, rogue._id);
            collection.ReplaceOne(filter, rogue);
        }
        private int u;
        public int _level
        {
            get { return u; }
            set
            {

                u = value;
                if (_starpoints > 1000)
                {
                    u = (_starpoints - (_starpoints % 1000))/ 1000;
                    return;
                }
                if (value >= 99)
                {
                    u = 99;
                }
                
                _starpoints += 5;
            }
        }
        private int g;
        public int _starpoints
        {
            get { return g; }
            set
            {
                if (value >= 0)
                {
                    g = value;
                }
            }
        }
    }
}
