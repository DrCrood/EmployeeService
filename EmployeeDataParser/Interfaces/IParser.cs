using System.Collections.Generic;

namespace EmployeeDataParser.Interfaces
{
    public interface IParser
    {
        List<Employee> Parse(string[] lines, out int[] fieldMaxWidth);
        Employee ParseLine(string record, bool resetDelimiter = false);
        void SetDelimiter(char delimiter);
    }
}