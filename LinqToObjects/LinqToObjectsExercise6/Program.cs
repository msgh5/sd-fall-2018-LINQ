using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqToObjectsExercise6
{
    class Program
    {
        static void Main(string[] args)
        {
            var employees = new List<Employee>
            {
                new Employee()
                { Name = "Bob", Position = "Senior Developer", Salary = 40000 },
                new Employee()
                { Name = "Sam", Position = "Developer", Salary = 32000 },
                new Employee()
                { Name = "Mel", Position = "Developer", Salary = 29000 },
                new Employee()
                { Name = "Donna", Position = "Developer", Salary = 25000 },
                new Employee()
                { Name = "Jim", Position = "Programmer", Salary = 20000 }
            };

            var employeesQuery = (from employee in employees
                                  where employee.Position == "Developer" &&
                                  employee.Salary > 25000
                                  select employee).ToList();

            foreach(var employee in employeesQuery)
            {
                Console.WriteLine(employee.Name);
            }

            Console.ReadLine();
        }
    }
}
