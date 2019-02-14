using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToObjectsExercise2
{
    class Program
    {
        static void Main(string[] args)
        {
            var lstNumbers = new List<int> { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var oddNumbers = (from number in lstNumbers
                              where number % 2 != 0
                              orderby number ascending
                              select number).ToList();

            var evenNumbers = (from number in lstNumbers
                               where number % 2 == 0
                               orderby number descending
                               select number).ToList();

            Console.WriteLine("Odd numbers:");

            oddNumbers.ForEach(p => Console.WriteLine(p));
            
            Console.WriteLine("Even numbers:");

            evenNumbers.ForEach(p => Console.WriteLine(p));
        }
    }
}
