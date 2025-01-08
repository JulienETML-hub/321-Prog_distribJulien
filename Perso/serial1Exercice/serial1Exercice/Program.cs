using serial1Exercice;
using System;
using System.Text.Json;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class serial1Exercice
    {
        static void Main(string[] args)
        {
            DateTime dateTime = DateTime.Now;
            Actor actor = new Actor("Julien", "Mares", dateTime, "Swiss", true);
            Actor actor2 = new Actor("Mathis", "Botteau", dateTime, "Swiss", true);

            Character character = new Character("Gerard8", "Depardieu", "description du vieux gerard DDD", actor2);
            Character character2 = new Character();
            Episode episde2 = new Episode();
            Episode episode1 = new Episode(
                title: "L'Ascension de l'Héros2",
                durationMinutes: 45,
                sequenceNumber: 3,
                director: "Jean Dupont",
                synopsis: "Dans cet épisode, le héros doit faire face à une trahison et trouver un moyen de sauver son monde.",
                characters: new List<Character>
                {
                   character,
                   character2
                }
);
                
            //Console.WriteLine( character.toJson());
            //var test = File.Create($"{character.FirstName}.json");
            File.WriteAllText($"./{episode1.Title}.json", character.toJson());
            // TODO Désérialiser un seul fichier
            //Console.WriteLine("");
            //Console.WriteLine($"Le personnage de {character.FirstName} {character.LastName} est joué par {character.PlayedBy.FirstName} {character.PlayedBy.LastName}");
            string aCuisiner = File.ReadAllText($"./L'Ascension de l'Héros2.json");
            episde2 = JsonSerializer.Deserialize<Episode>(aCuisiner);
            // TODO Désérialiser un seul fichier

            Console.WriteLine($"Le personnage de {episde2.Title} {episde2.Characters[0].FirstName}, {episde2.Characters[1].LastName} est joué par {episde2.Characters[0].PlayedBy.LastName}");
            Console.ReadLine();
        }

    }
    /* public static Character ToCharacter(this string data)
     {
         Character character = new Character();
         character = JsonSerializer.Deserialize<Character>(data);
         return character;
     }*/
}