using Packt.Shared;
using System.Text;

person bob = new();
WriteLine(bob.ToString());
bob.name = "Bob Smith";
bob.DateOfBirth = new DateTime(1965, 12, 22);

WriteLine(format: "{0} was born on {1:dddd, d MMMM yyyy}",
    arg0: bob.name, arg1: bob.DateOfBirth);


person alice = new()
{
    name = "Alice Jones",
    DateOfBirth = new DateTime(1998, 3, 7)
};
WriteLine(format: "{0} was born on {1:dd MMM yy}",
    arg0: alice.name, arg1: alice.DateOfBirth);

bob.FavoriteAncientWonders = WondersOfTheAncientWorld.StatueOfZeusAtOlympia;

WriteLine(
format: "{0}'s favorite wonder is {1}. Its integer is {2}.",
arg0: bob.name,
arg1: bob.FavoriteAncientWonders,
arg2: (int)bob.FavoriteAncientWonders);

bob.Children.Add(new person { name = "Alfred" });
bob.Children.Add(new() { name = "Zoe" });

WriteLine($"{bob.name} has {bob.Children.Count} children:");

for(int childIndex = 0; childIndex < bob.Children.Count; childIndex++)
{
    WriteLine($"> {bob.Children[childIndex].name}");
}


BankAccount.InterestRate = 0.012M;
BankAccount jonesAcount = new BankAccount();
jonesAcount.AccountName = "Mrs. Jones";
jonesAcount.Balance = 2400;
WriteLine(format: "{0} earned {1:C} interest.",
    arg0: jonesAcount.AccountName, arg1: jonesAcount.Balance * BankAccount.InterestRate);

BankAccount gerrierAccount = new BankAccount();
gerrierAccount.AccountName = "Ms. Gerrier";
gerrierAccount.Balance = 98;
WriteLine(format: "{0} earned {1:C} interest.",
    arg0: gerrierAccount.AccountName, arg1: gerrierAccount.Balance * BankAccount.InterestRate);


WriteLine($"{bob.name} is a {person.Species}");
WriteLine($"{bob.name} was born on {bob.HomePlanet}");
person blankPerson = new();

WriteLine(format: "{0} of {1} was created at {2:hh:mm:ss} on a {2:dddd}.",
    arg0:blankPerson.name,
    arg1:blankPerson.HomePlanet,
    arg2:blankPerson.Instantiated);
WriteLine(format: "{0} of {1} was created at {2:hh:mm:ss} on a {2:dddd}.",
    arg0: bob.name,
    arg1: bob.HomePlanet,
    arg2: bob.Instantiated);

person gunny = new(initialName: "Gunny", homePlanet: "Mars"); 

WriteLine(format: "{0} of {1} was created at {2:hh:mm:ss} on a {2:dddd}.",
    arg0: gunny.name,
    arg1: gunny.HomePlanet,
    arg2: gunny.Instantiated);

bob.WriteToConsole();
WriteLine(bob.GetOrigin());

(string, int) fruit = bob.GetFruit();
WriteLine($"{fruit.Item1}, {fruit.Item2} there are.");

WriteLine(bob.SayHello());
WriteLine(bob.SayHelloTo("Emely"));