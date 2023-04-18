using Recap_Lib.models;

Person myPerson = new Person("filip", 25);

myPerson.Greet();

Student studentA = new Student("filip", 5);
studentA.SetAge(21);
string intro = studentA.Introduce();
Console.WriteLine(intro);