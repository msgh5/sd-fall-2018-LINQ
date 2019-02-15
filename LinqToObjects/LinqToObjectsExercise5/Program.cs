using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToObjectsExercise5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Type a word:");

            string input = Console.ReadLine();
            
            var results = (from text in input
                          group text by text into texts
                          select new
                          {
                              Text = $"{texts.Key} - {texts.Count()} time(s)"
                          }).ToList();

            foreach (var result in results)
            {
                Console.WriteLine(result);
            }

            Console.ReadLine();
        }
    }
}
