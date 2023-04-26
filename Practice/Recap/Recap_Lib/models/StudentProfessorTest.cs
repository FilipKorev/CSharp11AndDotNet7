using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recap_Lib.models;

namespace Recap_Lib.models
{
    public class StudentProfessorTest
    {
        public  void Mainn()
        {
            Person X = new Person();
            X.Greet();
            Student Y = new Student("filip",25);
            Y.SetAge(30);
            Y.Greet();
            Y.ShowAge();
            Professor Z = new Professor("boban", 30);
            Z.SetAge(30);
            Z.Greet();
            Z.Explain();    
        }
        
    }
}
