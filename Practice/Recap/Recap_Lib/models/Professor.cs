using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recap_Lib.models
{
    internal class Professor : Person
    {
        public Professor(string name, int age) : base(name, age)
        {

        }

        public void Explain()
        {
            Console.WriteLine("I'm explaining");
        }
    }
}
