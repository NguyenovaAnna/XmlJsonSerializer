using System;
using System.IO;
using System.Xml.Serialization;
using System.Web.Script.Serialization;


namespace XmlJsonSerializer
{
    public class Program
    {

        public static void SerializeToXml(string path, Person[] content)
        {
            var xmlSerializer = new XmlSerializer(typeof(Person[]));

            using (var stream = new FileStream(path, FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(stream, content);
            }

        }

        public static void SerializeToJson(string path, Person[] content)
        {
            var jsonSerializer = new JavaScriptSerializer();

            var json = jsonSerializer.Serialize(content);

            File.WriteAllText(path, json);
        }

        static void Main(string[] args)
        {
            Person[] persons = new Person[]
            {
                new Person() { FirstName = "Danka", LastName = "Bodkova", Age = 33 },
                new Person() { FirstName = "Janka", LastName = "Horvathova", Age = 25 },
                new Person() { FirstName = "Majka", LastName = "Liskova", Age = 17 },
            };

            var path = @"C:\Users\nguye\Desktop\persons.xml";
            var jsonPath = @"C:\Users\nguye\Desktop\persons.json";

            SerializeToXml(path, persons);
            SerializeToJson(jsonPath, persons);

            Console.WriteLine("Done!");

            Console.ReadKey();
        }
    }

    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
}

