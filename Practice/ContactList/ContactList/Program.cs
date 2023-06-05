using ContactList;

// Prva opcija
//while (true)
//{
//    insertPhoneBook();
//}

insertPhoneBook(); //vtora opcija

void insertPhoneBook()
    {
    Console.WriteLine("Welcome to PhoneBook");

    Console.WriteLine("How many contacts do you want to inserts");

    int beContact = int.Parse(Console.ReadLine());

    PhoneBook phoneBook = new PhoneBook();

    for (int i = 0; i < beContact; i++)
    {
        Console.WriteLine("insert name");
        var name = Console.ReadLine();

        Console.WriteLine("insert surename");
        var surename = Console.ReadLine();

        Console.WriteLine("adress name");
        var adress = Console.ReadLine();

        Console.WriteLine("how many numbers would you like ti insert");
        int brNumbers = int.Parse(Console.ReadLine());
        List<string> phoneNumbers = new List<string>();
        for (int j = 0; j < brNumbers; j++)
        {
            Console.WriteLine($"insert number{j + 1}");

            phoneNumbers.Add(Console.ReadLine());
        }
        Contact contact = new Contact(name, surename, adress, phoneNumbers);
        phoneBook.Contacts.Add(contact);
    }
    phoneBook.ToString();
    insertPhoneBook(); //vtora opcija
}