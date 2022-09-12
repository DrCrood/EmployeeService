using System.IO;
using System.Linq;
using System.Text.Json;
using EmployeeDataParser;
using System.Collections.Generic;
using EmployeeDataParser.Interfaces;
using EmployeeServiceAPI.Interface;

namespace EmployeeServiceAPI.Services
{
    public class EmployeeDataService : IEmployeeDataService
    {
        private List<Employee> Employees { get; set; }
        public IParser RecordParser { get; private set; }

        public EmployeeDataService(IParser parser)
        {
            Employees = new List<Employee>();
            RecordParser = parser;
            LoadEmployeeData();
        }

        private void LoadEmployeeData()
        {
            string json = File.ReadAllText("./Data/EmployeeData.json");
            List<Employee> employees = JsonSerializer.Deserialize<List<Employee>>(json);
            Employees.AddRange(employees);
        }

        public Employee ParseLine(string record)
        {
            return RecordParser.ParseLine(record, true);
        }

        public bool EmployeeExists(Employee employee)
        {
            var existEmployee = Employees.FirstOrDefault(e => e.LastName == employee.LastName && e.FirstName == employee.FirstName && e.DateOfBirth == employee.DateOfBirth);
            return existEmployee != null;
        }

        public void AddEmployee(Employee employee)
        {
            Employees.Add(employee);
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
