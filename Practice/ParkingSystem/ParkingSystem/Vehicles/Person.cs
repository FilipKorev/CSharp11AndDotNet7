using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem.Vehicles
{
    public class Person
    {
        public string Embg { get; set; }
        public string Name { get; set; }
        public string Surename { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }

        public Person() { }

        public Person(string embg, string name, string surename, int age, string address)
        {
            Embg = embg;
            Name = name;
            Surename = surename;
            Age = age;
            Address = address;
        }
    }
}
