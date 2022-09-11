using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

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

        public virtual void SetPrintFormat()
        {
            PrintFormat = $"{{0,-{Employees.Count.ToString().Length}}} {{1}}";
        }

        public void PrintByColorAndLastName()
        {
            var orderedEmployees = GetEmployeeListSortByColorAndLastName();
            Print(orderedEmployees);
        }

        public void PrintByDateOfBirth()
        {
            var orderedEmployees = GetEmployeeListSortByDateOfBirth();
            Print(orderedEmployees);
        }

        public void PrintByLastNameDesc()
        {
            var orderedEmployees = GetEmployeeListSortByLastNameDesc();
            Print(orderedEmployees);
        }

        public List<Employee> GetEmployeeListSortByColorAndLastName()
        {
            return Employees.OrderBy(e => e.FavoriteColor).ThenBy(e => e.LastName).ToList();
        }

        public List<Employee> GetEmployeeListSortByDateOfBirth()
        {
            return Employees.OrderBy(e => e.DateOfBirth).ToList();
        }

        public List<Employee> GetEmployeeListSortByLastNameDesc()
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
