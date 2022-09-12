﻿using EmployeeDataParser;
using EmployeeDataParser.Interfaces;
using System.Collections.Generic;

namespace EmployeeServiceAPI.Interface
{
    public interface IEmployeeDataService
    {
        IParser RecordParser { get; }

        public void AddEmployee(Employee employee);
        public bool EmployeeExists(Employee employee);
        public List<Employee> GetEmployeeSortByBirthDate();
        public List<Employee> GetEmployeeSortByFavriteColor();
        public List<Employee> GetEmployeeSortByLastName();
        public Employee ParseLine(string record);
    }
}