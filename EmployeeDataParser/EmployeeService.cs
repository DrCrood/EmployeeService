using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EmployeeDataParser
{
    public class EmployeeService
    {
        private List<Employee> Employees { get; set; }
        private IParser? FileParser { get; set; }
        private string? PrintFormat { get; set; }
        public EmployeeService()
        {
            Employees = new List<Employee>();
        }

        public int AddEmployeesFromFile(string file)
        {   
            if(FileParser is null)
            {
                FileParser = GetFileParser();
            }

            List<Employee> employees = FileParser.Parse(GetFileContent(file), out int[] fieldWidth);
            Employees.AddRange(employees);
            Employee.UpdatePrintFormat(fieldWidth);

            return employees.Count;
        }

        private string[] GetFileContent(string file)
        {
            return File.ReadAllLines(file); ;
        }

        private IParser GetFileParser()
        {
            return new Parser();
        }

        public int GetEmployeeCount()
        {
            return Employees.Count;
        }

        public void SetPrintFormat()
        {
            PrintFormat = $"{{0,-{Employees.Count.ToString().Length}}} {{1}}";
        }

        public void PrintByColorAndLastName()
        {
            var orderedEmployees = Employees.OrderBy(e => e.FavoriteColor).ThenBy(e => e.LastName).ToList();
            Print(orderedEmployees);
        }

        public void PrintByDateOfBirth()
        {
            var orderedEmployees = Employees.OrderBy(e => e.DateOfBirth).ToList();
            Print(orderedEmployees);
        }

        public void PrintByLastName()
        {
            var orderedEmployees = Employees.OrderByDescending(e => e.LastName).ToList();
            Print(orderedEmployees);
        }

        private void Print(List<Employee> employees)
        {
            Console.WriteLine();
            int i = 1;
            foreach (Employee e in employees)
            {
                Console.WriteLine(PrintFormat, i++, e.ToString());
            }
        }
    }
}
