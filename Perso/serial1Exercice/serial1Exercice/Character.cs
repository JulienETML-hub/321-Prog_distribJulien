using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Text.Json;
namespace serial1Exercice
{
    public class Character
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public Actor? PlayedBy { get; set; }
        public Character(string firstName, string lastName, string description, Actor playedBy)
        {
            FirstName = firstName;
            LastName = lastName;
            Description = description;
            PlayedBy = playedBy;
        }
        public Character(string firstName, string lastName, string description)
        {
            FirstName = firstName;
            LastName = lastName;
            Description = description;
            PlayedBy = null;
        }
        public Character() { }
        public string toJson()
        {
            string jsonString =  JsonSerializer.Serialize(this);
            return jsonString;
        }

    }

}
