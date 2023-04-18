WriteLine("Before parsing");
Write("what is your age?");
string? input = ReadLine();
try
{
    int age = int.Parse(input!);
    WriteLine($"You are {age} years old.");
}
catch(OverflowException) {
    WriteLine("your age is a valid number format but it is either too big or small.");
}
catch (FormatException)
{
    WriteLine("The age you entered is not a valid number format.");
}
catch (Exception ex)
{
    WriteLine($"{ex.GetType()} says {ex.Message}");
}
WriteLine("after parsing.");