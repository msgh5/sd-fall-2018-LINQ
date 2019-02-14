using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqToObjectsExercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            var bands = new List<string>
            {
                "ACDC", "Queen", "Aerosmith", "Iron Maiden", "Megadeth", "Metallica", "Cream", "Oasis", "Abba", "Blur", "Chic", "Eurythmics", "Genesis", "INXS", "Midnight Oil", "Kent", "Madness", "Manic Street Preachers"
                , "Noir Desir", "The Offspring", "Pink Floyd", "Rammstein", "Red Hot Chili Peppers", "Tears for Fears"
                , "Deep Purple", "KISS"
            };

            var random = new Random();
            var randomPosition = random.Next(0, bands.Count());

            var firstBand = bands.FirstOrDefault();
            var lastBand = bands.LastOrDefault();
            var tenthBand = bands.ElementAtOrDefault(9);

            var randomBandQuery = (from band in bands
                                   orderby Guid.NewGuid()
                                   select band).First();

            var randomBand = bands.ElementAtOrDefault(randomPosition);
            
            Console.WriteLine(firstBand);
            Console.WriteLine(lastBand);
            Console.WriteLine(tenthBand);
            Console.WriteLine(randomBand);
            Console.WriteLine(randomBandQuery);

            Console.ReadLine();
        }
    }
}