using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using EmployeeDataParser;
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

        public Employee AddEmployee(string record)
        {
            Employee employee = RecordParser.ParseLine(record, true);
            if(employee is null)
            {
                return null;
            }

            var ee = Employees.FirstOrDefault(e => e.LastName == employee.LastName && e.FirstName == employee.FirstName && e.DateOfBirth == employee.DateOfBirth);
            if (ee is not null)
            {
                return null;
            }
            Employees.Add(employee);

            return employee;
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
