using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Excercises
{
    public static class AreaOfTriangle
    {
        public static int area1(int a,int b)
        {
            return (a * b) / 2;
        }
    }

    public static class SecondsInMinutes
    {
        public static int SecInMin(int a)
        {
            return a * 60;
        }
    }

    public static class LessThan0
    {
        public static Boolean LessOrEqual(int a)
        {
            if (a <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public static class SomethingToMe
    {
        public static string AddSomething(string a)
        {
            string add = "something " + a;
            return add;
        }
    }

    public static class FlipABool
    {
        public static bool Flip(bool a)
        {
            if (a == true)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }

    public static class Ex
    {
        public static bool Equal(int a, int b)
        {
            if (a == b)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static int BasketballPoints(int twoPointers, int ThreePointers)
        {
            return (twoPointers * 2) + (ThreePointers * 3);
        }

        public static object FirstElement (Array a)
        {
           return a.GetValue(0);
        }

        public static bool DivisibleByFive(int a)
        {
            if (a%5 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //public static bool TimeForMilk(DateTime a)
        //{
        //    DateTime Christmas =
        //    if ( )
        //    {
                
        //    }
        //}

        public static bool CountOfCharacters(string a, string b)
        {
            if (a.Length == b.Length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
