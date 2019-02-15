using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace LinqToXMLExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            var documentPath = @"C:\Users\guilherme.guizado\Desktop\companydirectory.xml";

            var employeeManager = new EmployeeManager(documentPath);

            var keyboardInput = string.Empty;

            while(keyboardInput != "0")
            {
                Console.WriteLine("1 - Search");
                Console.WriteLine("2 - Add Employee");
                Console.WriteLine("3 - Remove Employee");
                Console.WriteLine("0 - Exit");

                keyboardInput = Console.ReadLine();

                if (keyboardInput == "1")
                {
                    Console.WriteLine("Type something to search:");

                    var userSearch = Console.ReadLine();

                    var results = employeeManager.Search(userSearch);

                    if (!results.Any())
                    {
                        Console.WriteLine("No results have been found");
                    }
                    else
                    {
                        foreach (var employee in results)
                        {
                            Console.WriteLine("=================");
                            Console.WriteLine(employee.Element("Name").Value);
                            Console.WriteLine(employee.Element("Email").Value);
                            Console.WriteLine(employee.Element("Phone").Value);
                            Console.WriteLine(employee.Element("PersonalNumber").Value);
                            Console.WriteLine(employee.Element("Hired").Value);
                            Console.WriteLine("=================");
                        }
                    }
                }
                else if (keyboardInput == "2")
                {
                    Console.WriteLine("Type the name:");
                    var name = Console.ReadLine();

                    Console.WriteLine("Type the e-mail:");
                    var email = Console.ReadLine();

                    Console.WriteLine("Type the phone:");
                    var phone = Console.ReadLine();

                    Console.WriteLine("Type the personal number:");
                    var personalNumber = Console.ReadLine();

                    Console.WriteLine("Type the hired date (mm/dd/yyyy):");

                    var dateString = Console.ReadLine();
                    var date = Convert.ToDateTime(dateString);

                    try
                    {
                        employeeManager.Add(name, email, phone,
                        personalNumber, date);
                    }
                    catch(BusinessRuleException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    catch(Exception ex)
                    {
                        //Log to a file.
                        Console.WriteLine("Something went wrong. Please try again");
                    }
                }
                else if (keyboardInput == "3")
                {
                    Console.WriteLine("Please type the employee's personal number");
                    var personalNumber = Console.ReadLine();

                    employeeManager.Remove(personalNumber);
                }
            }
        }
    }
}
