using System;
using System.IO;
using System.Threading.Tasks;

namespace EmployeeDataParser
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("Usage: EmployeeDataParser list-of-files");
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

            employeeService.PrintEmployeesByFavcolorAndLastName();
            employeeService.PrintEmployeesByDateOfBirth();
            employeeService.PrintEmployeesByLastNameDesc();
            await employeeService.PrintAllEmployeesAsync();

        }
    }
}