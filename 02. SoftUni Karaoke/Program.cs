using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUni_Karaoke
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var partisipants = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.None);
            var listOFSongs = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.None);
            var currentPreformance = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.None);

            var singersAndAwars = new Dictionary<string, List<string>>();

            while (!currentPreformance[0].Equals("dawn"))
            {
                var partisapant = currentPreformance[0];
                var song = currentPreformance[1];
                var award = currentPreformance[2];

                if (partisipants.Contains(partisapant) && listOFSongs.Contains(song))
                {
                    if (!singersAndAwars.ContainsKey(partisapant))
                    {
                        singersAndAwars.Add(partisapant, new List<string>());
                        singersAndAwars[partisapant].Add(award);
                    }
                    else
                    {
                        if (!singersAndAwars[partisapant].Contains(award))
                        {
                            singersAndAwars[partisapant].Add(award);
                        }
                    }
                }
                currentPreformance = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.None);

            }


            if (singersAndAwars.Count == 0)
            {
                Console.WriteLine("No awards");
                return;
            }
            foreach (var singer in singersAndAwars.OrderByDescending(s => s.Value.Count).ThenBy(s => s.Key))
            {
                Console.WriteLine($"{singer.Key}: {singer.Value.Count} awards");

                var awardsForSinger = singersAndAwars[singer.Key].OrderBy(s => s).ToArray();

                if (awardsForSinger.Length > 0)
                {
                    foreach (var award in awardsForSinger)
                    {
                        Console.WriteLine($"--{award}");
                    }
                }
                else
                {
                    Console.WriteLine("No awards");
                }
            }
        }
    }
}
