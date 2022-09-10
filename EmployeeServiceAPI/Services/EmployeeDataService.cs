using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeDataParser;

namespace EmployeeServiceAPI.Services
{
    public class EmployeeDataService
    {
        private List<Employee> Employees { get; set; }

        public EmployeeDataService()
        {
            Employees = new List<Employee>();
        }

        public bool AddEmployee(Employee employee)
        {
            Employees.Add(employee);
            return true;
        }

        public Employee GetEmployeeByLastName(string name)
        {
            return Employees.Where(e => e.LastName == name).FirstOrDefault();
        }
        public List<Employee> GetEmployeeByFavriteColor(string color)
        {
            return Employees.Where(e => e.FavoriteColor == color).ToList();
        }
    }
}
