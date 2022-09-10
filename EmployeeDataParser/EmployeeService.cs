using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeService
{
    public class EmployeeService
    {
        private List<Employee> Employees { get; set; }
        private Parser FileParser { get; set; }
        private string PrintFormat { get; set; }
        public EmployeeService()
        {
            Employees = new List<Employee>();
            FileParser = new Parser();
        }

        public int AddEmployeesFromFile(string file)
        {   
            List<Employee> employees = FileParser.ParseFile(file);
            Employees.AddRange(employees);
            return employees.Count;
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
