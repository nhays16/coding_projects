using System;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace MusicLINQ
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Collections to work with
            List<Artist> Artists = JsonToFile<Artist>.ReadJson();
            List<Group> Groups = JsonToFile<Group>.ReadJson();

            //========================================================
            //Solve all of the prompts below using various LINQ queries
            //========================================================

            //There is only one artist in this collection from Mount Vernon, what is their name and age?
            Artist MountVernon = Artists.Where(artist => artist.Hometown == "Mount Vernon").SingleOrDefault();
            System.Console.WriteLine($"{MountVernon.ArtistName} is {MountVernon.Age}");

            //Who is the youngest artist in our collection of artists?
            Artist Youngest = Artists.Where(artist => artist.Age == Artists.Min( a => a.Age)).SingleOrDefault();
            Console.WriteLine($"{Youngest.ArtistName} is the youngest");

            //Display all artists with 'William' somewhere in their real name
            List<Artist> Williams = Artists.Where(artist => artist.RealName.Contains("William")).ToList();
            foreach(Artist wills in Williams)
            {
                Console.WriteLine(wills.ArtistName);
            }

            //Display the 3 oldest artist from Atlanta
            List<Artist> Oldest = Artists.Where(artist => artist.Hometown == "Atlanta").OrderByDescending(keySelector: a => a.Age).Take(3).ToList();
            foreach(Artist old in Oldest)
            {
                Console.WriteLine($"{old.ArtistName} is {old.Age}");
            }

            //Display all groups with names less than 8 Characters in length
            List<Group> nameLength = Groups.Where(group => group.GroupName.Length < 8).ToList();
            Console.WriteLine("These groups have names less than 8 characters in length:");
            foreach(Group name in nameLength)
            {
                Console.WriteLine(name.GroupName);
            }
            //(Optional) Display the Group Name of all groups that have members that are not from New York City

            //(Optional) Display the artist names of all members of the group 'Wu-Tang Clan'
        }
    }
}
