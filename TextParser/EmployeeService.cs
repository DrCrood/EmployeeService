using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeService
{
    public class EmployeeService
    {
        List<Employee> Employees { get; set; }
        Parser FileParser { get; set; }
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

        public void PrintByColorAndLastName()
        {
            PrintFormat = $"{{0,-{Employees.Count.ToString().Length}}} {{1}}";
            var orderedEmployee = Employees.OrderBy(e => e.FavoriteColor).ThenBy(e => e.LastName).ToList();
            int i = 1;
            Console.WriteLine();
            foreach (Employee p in orderedEmployee)
            {
                Console.WriteLine(PrintFormat, i++, p.ToString());
            }
        }

        public void PrintByDateOfBirth()
        {
            Console.WriteLine();
            var orderedEmployee = Employees.OrderBy(e => e.DateOfBirth).ToList();
            int i = 1;
            foreach (Employee p in orderedEmployee)
            {
                Console.WriteLine(PrintFormat, i++, p.ToString());
            }
        }

        public void PrintByLastName()
        {
            int i = 1;
            Console.WriteLine();
            var orderedEmployee = Employees.OrderByDescending(e => e.LastName).ToList();
            foreach (Employee p in orderedEmployee)
            {
                Console.WriteLine(PrintFormat, i++, p.ToString());
            }
        }
    }
}
