﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactList
{
    public class Contact
    {
        private string _name;
        
        public string Surenme { get; set; }
        public string Adress { get; set; }
        public List<string> PhoneNumbers { get; set; }

        public Contact() { }

        public Contact(string name, string surenme, string adress, List<string> phoneNumbers)
        {
            _name = name.Length > 4 && name.Length < 10 ? name : throw new Exception("Invalid name");
            Surenme = surenme;
            Adress = adress;
            if (phoneNumbers.Count <= 5)
            {
                bool flag = true;

                for (int i = 0; i < phoneNumbers.Count; i++)
                {
                    if (!(phoneNumbers[i].Count() == 9 && (phoneNumbers[i].StartsWith("071")
                        || phoneNumbers[i].StartsWith("070") || phoneNumbers[i].StartsWith("072")
                        || phoneNumbers[i].StartsWith("075") || phoneNumbers[i].StartsWith("076")
                        || phoneNumbers[i].StartsWith("077") || phoneNumbers[i].StartsWith("078"))))
                        {
                            flag = false;
                        }
                }
                if (flag)
                {
                    //inicalizacija pri konstruktor so parametri
                    PhoneNumbers= phoneNumbers;
                }
            }
            else
            {
                throw new Exception("List has more than 5 elements");
            }
        }
            
        public string getName()
        {
            return _name;
        }
        public List<string> getNumbers()
        {
            string savePosition;
            for (int i = 0; i < PhoneNumbers.Count-1; i++)
            {
                for (int j = 1; j < PhoneNumbers.Count; j++)
                {
                    if (PhoneNumbers[i].CompareTo(PhoneNumbers[j]) > 0)
                    {
                        savePosition = PhoneNumbers[i];
                        PhoneNumbers[i] = PhoneNumbers[j];
                        PhoneNumbers[j] = savePosition;
                    }
                }
            }
            return PhoneNumbers;
        }

        public string addNumber(string number)
        {
            if (PhoneNumbers.Count < 5)
            {
                PhoneNumbers.Add(number);
                return "added number";
            }
            else
            {
                return "not added number";
            }
        }

        public string Pecati()
        {
            string numbers = "";
            foreach(var number in PhoneNumbers)
            {
                numbers += $"Number {PhoneNumbers.IndexOf(number)}: {number}";
            } 
            string message = $"Name: {_name}, Surname:{Surenme}, Address:{Adress}, Numbers: {numbers}";

            return message;
        }

        
    }
}
