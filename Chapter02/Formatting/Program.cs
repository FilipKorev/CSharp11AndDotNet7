int numberOdApples = 12;
decimal pricePerApple = 0.35M;
WriteLine(
    format: "{0} apples cost {1:C}",
    arg0: numberOdApples,
    arg1: pricePerApple * numberOdApples
    );
string formatted = string.Format(
    format: "{0} apples cost {1:C}",
    arg0: numberOdApples,
    arg1: pricePerApple * numberOdApples
    );

WriteLine($"{numberOdApples} apples cost {pricePerApple * numberOdApples:C}");

string applesText = "Apples";
int applesCount = 1234;
string bananasText = "Bananas";
int bananasCount = 56789;

WriteLine(
    format: "{0,-10} {1,7}",
    arg0: "Name",
    arg1: "Count");
WriteLine(
    format: "{0,-10}{1,7:N0}",
    arg0: applesText,
    arg1: applesCount);
WriteLine(
    format: "{0,-10}{1,7:N0}",
    arg0: bananasText,
    arg1: bananasCount);

Write("Type your first name and press ENTER:");
string? firstName = ReadLine();
Write("Type your age and press ENTER:");
string age = ReadLine()!;
WriteLine($"Hello {firstName}, you look good for {age}.");

Write("Press any key combination: ");
ConsoleKeyInfo key = ReadKey();
WriteLine();
WriteLine("Key: {0}, Char: {1}, Modifiers: {2}",
    arg0: key.Key,
    arg1: key.KeyChar,
    arg2: key.Modifiers);
