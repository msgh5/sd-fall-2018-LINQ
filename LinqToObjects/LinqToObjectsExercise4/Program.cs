using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToObjectsExercise4
{
    class Program
    {
        static void Main(string[] args)
        {
            //Step 1: Reading files from folder
            var completeFilePaths = Directory
                .EnumerateFiles(@"C:\Users\guilherme.guizado\Desktop\revise",
                "*").ToList();

            //Find the file extensions syntahx
            var fileExtensionsMethod = completeFilePaths
                .Select(p => Path.GetExtension(p)).ToList();

            //Find the file extensions query synthax
            var fileExtensionsQuery = (from file in completeFilePaths
                                       select Path.GetExtension(file)
                                       ).ToList();

            //Group file extension by method synthax
            var groupedFilesMethod = fileExtensionsMethod
                .GroupBy(files => files)
                .Select(extensionGroup => new
                {
                    Text = $"{extensionGroup.Count()} Files(s) with " +
                    $"{extensionGroup.Key} extension"
                }).ToList();

            //Group file extension by query synthax
            var groupFilesQuery = (from extension in fileExtensionsQuery
                                   group extension by extension into groupedExtensions
                                   select new
                                   {
                                       Text = $"{groupedExtensions.Count()} Files(s) with " +
                                       $"{groupedExtensions.Key} extension"
                                   });
            Console.WriteLine("--- Method Synthax ---");

            foreach(var group in groupedFilesMethod)
            {
                Console.WriteLine(group.Text);
            }

            Console.WriteLine("--- Query Synthax ---");

            foreach (var group in groupFilesQuery)
            {
                Console.WriteLine(group.Text);
            }

            //var groupedFiles = (from file in fileExtensions
            //                    group file
            //                    select )

            Console.ReadLine();
        }
    }
}
