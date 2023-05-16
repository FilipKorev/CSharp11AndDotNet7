using System.Xml.Serialization;
using Packt.Shared;
using static System.Environment;
using static System.IO.Path;
using static System.Console;
using Newtonsoft.Json;

List<Person> people = new List<Person>()
{
    new Person(30000M)
    {
        FirstName = "Alice",
        LastName = "Smith",
        DateOfBirth = new DateTime(1974, 3, 14)
    },
    new Person(40000M)
    {
        FirstName = "Bob",
        LastName = "Jones",
        DateOfBirth = new DateTime(1969, 11, 23)
    },
    new Person(20000M)
    {
        FirstName = "Charlie",
        LastName = "Cox",
        DateOfBirth = new DateTime(1984, 5, 4),
        Children = new HashSet<Person>()
        {
            new Person(0M)
                {
                    FirstName = "Sally",
                    LastName = "Cox",
                    DateOfBirth = new DateTime(2012, 7, 12)
                }
        }
    }
};

XmlSerializer xs = new XmlSerializer(typeof(List<Person>));

string path = Combine(CurrentDirectory, "people.xml" );

using (FileStream stream = File.Create(path))
{
    xs.Serialize(stream, people);
}

WriteLine("Written {0:N0} in {1} ", new FileInfo(path).Length, path);
WriteLine("-------------------");
string[] lines = File.ReadAllLines(path);

foreach (var line in lines)
{
    WriteLine(line);
}

WriteLine();
WriteLine("Deserializing XML files");

using (FileStream xmlLoad = File.Open(path, FileMode.Open))
{
    List<Person>? loadedPeople = xs.Deserialize(xmlLoad) as List<Person>;

    if (loadedPeople != null)
    {
        foreach (Person person in loadedPeople)
        {
            WriteLine($"{person.LastName} has {person.Children.Count} children.");
        }
    }
}


WriteLine();
WriteLine("Serialization JSON");

string pathJson = Combine(CurrentDirectory, "people.json");

using (StreamWriter streamJson = File.CreateText(pathJson))
{
    JsonSerializer jss = new JsonSerializer();

    string json = JsonConvert.SerializeObject(people, Formatting.Indented);
    streamJson.Write(json);

    //jss.Serialize(streamJson, people);
}

WriteLine("Written {0:N0} in {1} ", new FileInfo(pathJson).Length, pathJson);
WriteLine("-------------------");
WriteLine(File.ReadAllText(pathJson));


WriteLine();
WriteLine("Deserialization JSON");

string jsonText = File.ReadAllText(pathJson);
List<Person>? jsonPeople = JsonConvert.DeserializeObject<List<Person>>(jsonText);

if (jsonPeople != null)
{
    foreach (Person person  in jsonPeople)
    {
        int childrenCount = person.Children != null ? person.Children.Count : 0;
        Console.WriteLine($"{person.FirstName} has {childrenCount} children.");
    }

}