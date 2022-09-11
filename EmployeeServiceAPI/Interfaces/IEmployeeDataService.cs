using EmployeeDataParser;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeServiceAPI.Interface
{
    public interface IEmployeeDataService
    {
        Parser RecordParser { get; }

        Employee AddEmployee(string record);
        List<Employee> GetEmployeeSortByBirthDate();
        List<Employee> GetEmployeeSortByFavriteColor();
        List<Employee> GetEmployeeSortByLastName();
    }
}