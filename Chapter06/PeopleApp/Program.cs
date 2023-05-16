using Packt.Shared;

Person harry = new Person()
{
    Name = "Harry",
    DateOfBirth = new DateTime(year: 2001, month: 3, day: 25)
};

harry.WriteToConsole();

System.Collections.Hashtable lookupObject = new System.Collections.Hashtable();
lookupObject.Add(key: 1, value: "Alpha");
lookupObject.Add(key: 2, value: "Beta");
lookupObject.Add(key: 3, value: "Gamma");
lookupObject.Add(key: harry, value: "Delta");

int key = 2;

WriteLine(format: "key {0} has value: {1}",
    arg0: key,
    arg1: lookupObject[key]);

WriteLine(format: "key {0} has value: {1}",
    arg0: harry,
    arg1: lookupObject[harry]); 

//Dictionary<int,string> lookupIntString = new Dictionary<int,string>();
//lookupIntString.Add(key: 1, value: "Alpha");
//lookupIntString.Add(key: 1, value: "Beta");
//lookupIntString.Add(key: 1, value: "Gamma");
//lookupIntString.Add(key: 4, value: "Delta");

static void Harry_Shout(object? sender, EventArgs e)
{
    if (sender is null) return;
    Person? p = sender as Person;
    if (p is null) return;

    WriteLine($"{p.Name} is this angry: {p.AngerLevel}.");
}

harry.Shout = Harry_Shout;
harry.Poke();
harry.Poke();
harry.Poke();
harry.Poke();