// a string array is a sequence that implements IEnumerable<string>
string[] names = new[] { "Michael", "Pam", "Jim", "Dwight", "Angela", "Kevin", "Toby", "Creed" };

SectionTitle("Deferred execution");

// Question: Which names end with an M?
// (written using a LINQ extension method)
var query1 = names.Where(name => name.EndsWith("m"));
WriteLine("LINQ Method");

foreach (string name in query1)
{
    WriteLine(name);
}
// written using a LINQ querry
IEnumerable<string> query2 = from name in names where name.EndsWith("m") select name;
WriteLine("-----------");
WriteLine("LINQ Query");
foreach (string name in query2)
{
    WriteLine(name);
}


//dali imeto sodrzi "a"
WriteLine("Contains 'a'");
var query3 = names.Where((name) => name.Contains("a"));
foreach (string name in query3)
{
    WriteLine(name);
}