using MoreLinq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zola.DesignPatterns
{//NUGGET : Added MoreLinq
 //       : NUnit
  public  class Singleton
    {
        interface IDatabase
        {
            int GetPopulation(string name);
        }
        private Dictionary<string, int> capitals;
        public class SinletonDatabase : IDatabase
        {
            private Dictionary<string, int> capitals;
            private static int instanceCount;
            public static int count => instanceCount;

            //constructor is always private.
            private SinletonDatabase()
            {
                instanceCount++;
                capitals = File.ReadAllLines(Path.Combine(new FileInfo(typeof(IDatabase).Assembly.Location).DirectoryName,"Capital.txt"))
                    .Batch(2).ToDictionary(
                    list => list.ElementAt(0).Trim(),
                    list => int.Parse(list.ElementAt(1)));
            }
            public int GetPopulation(string name) {
                return capitals[name];

            }
            //1. For normal creation
            private static SinletonDatabase instance = new SinletonDatabase();
            //2. For Lazy creation of object
            private static Lazy<SinletonDatabase> lazyInstance = new Lazy<SinletonDatabase>(() => new SinletonDatabase());
            //1. Related to 1.
            public static SinletonDatabase Instance => instance;
            //2. related to 2.
            public static SinletonDatabase Instance2 => lazyInstance.Value;
        }
       public static void SingletonMain()
        {//only thing we can do to improve this kind of object creation of singleton is we can make creation of singleton lazy.
            //Calling of both 1 and 2 are same.
            var db = SinletonDatabase.Instance;
            var city = "Tokyo";
            Console.WriteLine($"{city} has population {db.GetPopulation(city)}");
        }

        public class SingletonRecordFinder
        {
            public int GetTotalPolulation(IEnumerable<string> names)
            {
                int result = 0;
                 foreach(var name in names)
                {
                    result += SinletonDatabase.Instance2.GetPopulation(name);
                   
                }
                return result;
            }
        }

        //To prove that singleton is a bad idea we create a test class with NUnit
        [TestFixture]
        public class SingletonTests {
            [Test]
            public void IsSingletonTest()
            {//this test will pass if we dont have class SingletonRecordFinder.
                var db = SinletonDatabase.Instance;
                var db2 = SinletonDatabase.Instance;
                Assert.That(db, Is.SameAs(db2));
                Assert.That(SinletonDatabase.count, Is.EqualTo(1));
            }
            [Test]
            public void SingletonTotalPopulationTest()
            {
                var rf = new SingletonRecordFinder();
                var names = new[] { "Seoul" ,"Mexico City"};
                int tp = rf.GetTotalPolulation(names);
                //f someone deletes mexico then test will continously fail as instance is already generated.
                Assert.That(tp, Is.EqualTo(17500000 + 17400000));
            }

        }
        //Dependency injection of Singleton CLass
        public class ConfigurableRecordFinder
        {
            public ConfigurableRecordFinder(IDatabase database)
            {
                this.database = database ?? throw new ArgumentNullException(paramName: nameof(database));

            }
        }


    }
}
