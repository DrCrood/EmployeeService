using System;
using System.IO;

namespace EmployeeService
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("Usuage: TextParser list-of-files");
                return;
            }

            EmployeeService employeeService = new EmployeeService();

            foreach (string file in args)
            {
                if (File.Exists(file))
                {
                    int n = employeeService.AddEmployeesFromFile(file);
                    Console.WriteLine($"{n} employees loaded from " + file);
                }
                else
                {
                    Console.WriteLine("Warning: " + file + " doesn't exists!");
                }
            }

            employeeService.PrintByColorAndLastName();
            employeeService.PrintByDateOfBirth();
            employeeService.PrintByLastName();
        }
    }
}