﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace serial1Exercice
{
    public class Actor
    {
        public Actor(string firstName, string lastName, DateTime birthDate, string country, bool isAlive)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            Country = country;
            IsAlive = isAlive;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Country { get; set; }
        public bool IsAlive { get; set; }


    }
}
