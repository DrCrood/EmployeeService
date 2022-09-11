using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeDataParser;
using EmployeeServiceAPI.Interface;

namespace EmployeeServiceAPI.Services
{
    public class EmployeeDataService : IEmployeeDataService
    {
        private List<Employee> Employees { get; set; }
        public Parser RecordParser { get; private set; }

        public EmployeeDataService()
        {
            Employees = new List<Employee>();
            RecordParser = new Parser();
        }

        private void LoadData()
        {

        }

        public Employee Parse(string record)
        {
            return RecordParser.ParseLine(record, true);
        }

        public bool AddEmployee(Employee employee)
        {
            Employees.Add(employee);
            return true;
        }


        public List<Employee> GetEmployeeSortByFavriteColor()
        {
            return Employees.OrderBy(e => e.FavoriteColor).ToList();
        }

        public List<Employee> GetEmployeeSortByLastName()
        {
            return Employees.OrderBy(e => e.LastName).ToList();
        }

        public List<Employee> GetEmployeeSortByBirthDate()
        {
            return Employees.OrderBy(e => e.DateOfBirth).ToList();
        }
    }
}
