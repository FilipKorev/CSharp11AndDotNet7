using Packt.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Packt.Shared
{
    public class person : object
    {
        public string? name;
        public DateTime DateOfBirth;
        public WondersOfTheAncientWorld FavoriteAncientWonders;

        public List<person> Children = new List<person>();

        public const string Species = "Homo Sapiens";
        public readonly string HomePlanet = "Earth";

        public readonly DateTime Instantiated;

        public person()
        {
            name = "Unknown";
            Instantiated = DateTime.Now;
        }

        public person(string initialName, string homePlanet)
        {
            name = initialName;
            HomePlanet = homePlanet;
            Instantiated = DateTime.Now;
        }

        //methods

        public void WriteToConsole()
        {
            WriteLine($"{name} was born on a {DateOfBirth:dddd}.");
        }

        public string GetOrigin()
        {
            return $"{name} was born on {HomePlanet}";
        }

        public (string, int) GetFruit()
        {
            return ("Apples", 5);
        }

        public string SayHello()
        {
            return $"{name} says 'Hello!'";
        }

        public string SayHelloTo(string Name)
        {
            return $"{name} says 'Hello {Name}!'";
        }
    }
}

