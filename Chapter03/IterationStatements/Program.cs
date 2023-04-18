int x = 0;
while (x < 10)
{
    WriteLine(x);
    x++;
}

string? password;
do
{
    Write("Enter your password: ");
    password = ReadLine();
}
while (password.Length < 8 );
WriteLine("Correct!");


for (int y = 1; y <= 10; y++)
{
    WriteLine(y);
}


string[] names = { "Adam", "Berry", "Charlie" };

foreach (string name in names)
{
    WriteLine($"{name} has {name.Length} characters.");
}


