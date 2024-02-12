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
    public class Wizard
    {
        public Wizard(string name, int minstrenght, int strenght, int maxstrenght, int dexterity, int mindexterity, int maxdexterity, int inteligence, int mininteligence, int maxinteligence, int vitality, int minvitality, int maxvitality, int starpoints)
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
                _pdamade = (int)(a * 0.5);
                _health = (int)(1.4 * _vitality + 0.2 *a);
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
                _mana = (int)(c * 1.5);
                _mdamage = (int)( c);
                _mdefence = (int)( c);
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
                _health = (int)(1.4 * d + 0.2 * _strenght);
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

        public static void CreateWizard(Wizard wiz)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("Heroes");
            var collection = database.GetCollection<Wizard>("Wizard");
            collection.InsertOne(wiz);
        }
        public static List<Wizard> GetWizards()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("Heroes");
            var collection = database.GetCollection<Wizard>("Wizard");
            List<Wizard> result = new List<Wizard>();
            result = collection.Find(x => true).ToList();
            return result;

        }

        internal static List<Wizard> GetWizard(Wizard wiz)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("Heroes");
            var collection = database.GetCollection<Wizard>("Wizard");
            List<Wizard> result = new List<Wizard>();
            result = collection.Find(x => x._name == wiz._name).ToList();
            return result;
        }
        public static void UpdateWizard(Wizard wiz)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("Heroes");
            var collection = database.GetCollection<Wizard>("Wizard");
            var filter = Builders<Wizard>.Filter.Eq(i => i._id, wiz._id);
            collection.ReplaceOne(filter, wiz);
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
