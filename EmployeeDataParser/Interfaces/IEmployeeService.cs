using System.Collections.Generic;

namespace EmployeeDataParser
{
    public interface IEmployeeService
    {
        int AddEmployeesFromFile(string file);
        int GetEmployeeCount();
        List<Employee> GetEmployeeListSortByColorAndLastName();
        List<Employee> GetEmployeeListSortByDateOfBirth();
        List<Employee> GetEmployeeListSortByLastNameDesc();
        string[] GetFileContent(string file);
        void PrintByColorAndLastName();
        void PrintByDateOfBirth();
        void PrintByLastNameDesc();
        void SetPrintFormat();
    }
}