using EmployeeDataParser;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeServiceAPI.Interface
{
    public interface IEmployeeDataService
    {
        Parser RecordParser { get; }

        bool AddEmployee(Employee employee);
        List<Employee> GetEmployeeSortByBirthDate();
        List<Employee> GetEmployeeSortByFavriteColor();
        List<Employee> GetEmployeeSortByLastName();
        Employee Parse(string record);
    }
}