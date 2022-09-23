using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using EmployeeDataParser.Interfaces;
using System.Threading.Tasks;

namespace EmployeeDataParser
{
    public class EmployeeService : IEmployeeService
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
            if (FileParser is null)
            {
                FileParser = GetFileParser();
            }

            List<Employee> employees = FileParser.Parse(GetFileContent(file), out int[] fieldWidth);
            Employees.AddRange(employees);
            Employee.UpdatePrintFormat(fieldWidth);
            return employees.Count;
        }

        public virtual string[] GetFileContent(string file)
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

        private void SetPrintFormat()
        {
            PrintFormat = $"{{0,-{Employees.Count.ToString().Length}}} {{1}}";
        }

        public void PrintEmployeesByFavcolorAndLastName()
        {
            var orderedEmployees = GetEmployeesSortedByFavColorAndLastName();
            Print(orderedEmployees);
        }

        public void PrintEmployeesByDateOfBirth()
        {
            var orderedEmployees = GetEmployeesSortedByDateOfBirth();
            Print(orderedEmployees);
        }

        public void PrintEmployeesByLastNameDesc()
        {
            var orderedEmployees = GetEmployeesSortedByLastNameDesc();
            Print(orderedEmployees);
        }

        public async Task PrintAllEmployeesAsync()
        {
            var employees = GetEmployeesAllAsync();
            Console.WriteLine();
            await foreach(Employee employee in employees)
            {
                Console.WriteLine(employee.ToString());
            }
        }

        public async IAsyncEnumerable<Employee> GetEmployeesAllAsync()
        {
            foreach (var employee in Employees)
            {
                await Task.Delay(300);
                yield return employee;
            }
        }

        public List<Employee> GetEmployeesSortedByFavColorAndLastName()
        {
            return Employees.OrderBy(e => e.FavoriteColor).ThenBy(e => e.LastName).ToList();
        }

        public List<Employee> GetEmployeesSortedByDateOfBirth()
        {
            return Employees.OrderBy(e => e.DateOfBirth).ToList();
        }

        public List<Employee> GetEmployeesSortedByLastNameDesc()
        {
            return Employees.OrderByDescending(e => e.LastName).ToList();
        }
        private void Print(List<Employee> employees)
        {
            if(employees.Count < 1)
            {
                return;
            }
            Console.WriteLine();
            int i = 1;
            if (PrintFormat is null)
            {
                SetPrintFormat();
            }
            foreach (Employee e in employees)
            {
                Console.WriteLine(PrintFormat, i++, e.ToString());
            }
        }
    }
}
