using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToObjectsExercise3
{
    class Program
    {
        static void Main(string[] args)
        {
            var provinces = new List<string> { "Alberta", "British Columbia",
                "Manitoba", "New Brunswick", "Nova Scotia", "Ontario",
                "Quebec", "Yukon", "Nunavut" };

            //Query Synthax
            var orderedProvincesQuery = (from province in provinces
                         orderby province.Length, province
                         select province).ToList();

            //Method Synthax
            var orderedProvincesMethod = provinces
                .OrderBy(p => p.Length)
                .ThenBy(p => p)
                .ToList();

            orderedProvincesQuery.ForEach(p => Console.WriteLine(p));
            orderedProvincesMethod.ForEach(p => Console.WriteLine(p));

            Console.ReadLine();
        }
    }
}
