using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloCSharpSayHello.myClass
{
    public class Class1
    {
        int myInt = 13;
        public int MyProperty { get; set; }

        public void ShowMyInt() 
        {
            Console.WriteLine(myInt);
        }
    }
}
