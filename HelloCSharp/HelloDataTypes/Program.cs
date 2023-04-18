using HelloCSharpSayHello.myClass;

namespace HelloDataTypes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Data Types!");
            int myInt = 256;
            byte myByte = Convert.ToByte("255");
            bool myBool = false;
            string myString = "yoo";
            Console.WriteLine("my int is: " + myInt);
            Console.WriteLine("my byte is: " + myByte);
            char myChar = 'B';
            DateTime myDate = DateTime.Now;
            Console.WriteLine(myDate);
            Console.WriteLine(myBool);
            Console.WriteLine(myString);
            Console.WriteLine(myChar);

            Class1 myClass = new Class1();
            myClass.MyProperty = 1;
            int mySecondInt = myClass.MyProperty;
            myClass.ShowMyInt();
        }
    }
}