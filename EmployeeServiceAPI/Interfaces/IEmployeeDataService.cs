using EmployeeDataParser;
using EmployeeDataParser.Interfaces;
using System.Collections.Generic;

namespace EmployeeServiceAPI.Interface
{
    public interface IEmployeeDataService
    {
        IParser RecordParser { get; }

        public Employee AddEmployee(string record);
        public List<Employee> GetEmployeeSortByBirthDate();
        public List<Employee> GetEmployeeSortByFavriteColor();
        public List<Employee> GetEmployeeSortByLastName();
    }
}