using System.Collections.Generic;

namespace EmployeeDataParser
{
    public interface IEmployeeService
    {
        int AddEmployeesFromFile(string file);
        int GetEmployeeCount();
        List<Employee> GetEmployeesSortedByFavColorAndLastName();
        List<Employee> GetEmployeesSortedByDateOfBirth();
        List<Employee> GetEmployeesSortedByLastNameDesc();
        string[] GetFileContent(string file);
        void PrintEmployeesByFavcolorAndLastName();
        void PrintEmployeesByDateOfBirth();
        void PrintEmployeesByLastNameDesc();
    }
}