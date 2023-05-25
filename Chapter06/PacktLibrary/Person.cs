namespace Packt.Shared
{
    public class Person : Object, IComparable<Person>
    {
        public string? Name { get; set; }
        public DateTime DateOfBirth { get; set; }

        public void WriteToConsole()
        {
            WriteLine($"{Name} was born on a {DateOfBirth:dddd}.");
        }

        public event EventHandler? Shout;
        public int AngerLevel;

        public void Poke()
        {
            AngerLevel++;
            if (AngerLevel >= 3)
            {
                if (Shout != null)
                {
                    Shout(this, EventArgs.Empty);
                }
            }
        }

        public int CompareTo(Person? other)
        {
            throw new NotImplementedException();
        }
    }
}