using System.Collections.Generic;

namespace EmployeeDataParser
{
    public interface IParser
    {
        List<Employee> Parse(string[] lines, out int[] fieldWidth);
    }
}