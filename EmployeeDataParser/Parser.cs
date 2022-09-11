using System;
using System.Linq;
using System.Collections.Generic;
using EmployeeDataParser.Interfaces;

namespace EmployeeDataParser
{
    public class Parser : IParser
    {
        private char Delimiter { get; set; }

        private void SetDelimiterFormContent(string line)
        {
            if (line.Contains('|'))
            {
                this.Delimiter = '|';
            }
            else if (line.Contains(','))
            {
                this.Delimiter = ',';
            }
            else
            {
                this.Delimiter = ' ';
            }
        }

        public void SetDelimiter(char delimiter)
        {
            this.Delimiter = delimiter;
        }

        private Employee ParseLine(String record, int[] width)
        {
            Employee employee = ParseLine(record);

            if (employee is not null)
            {
                width[0] = employee.LastName.Length > width[0] ? employee.LastName.Length : width[0];
                width[1] = employee.FirstName.Length > width[1] ? employee.FirstName.Length : width[1];
                width[2] = employee.Email.Length > width[2] ? employee.Email.Length : width[2];
                width[3] = employee.FavoriteColor.Length > width[3] ? employee.FavoriteColor.Length : width[3];
            }

            return employee;
        }

        public Employee ParseLine(String record, bool resetDelimiter = false)
        {
            if (resetDelimiter)
            {
                SetDelimiterFormContent(record);
            }
            string[] r = record.Split(Delimiter).Where(f => !String.IsNullOrWhiteSpace(f)).ToArray();

            if (r.Length != 5 || !DateTime.TryParse(r[4], out DateTime birthDay))
            {
                Console.WriteLine("Error: Invalid data {0}", record);
                return null;
            }

            string lastName = r[0].Trim();
            string firstName = r[1].Trim();
            string email = r[2].Trim();
            string favColor = r[3].Trim();

            return new(lastName, firstName, email, favColor, birthDay);
        }

        /// <summary>
        /// Parser a array of strings into a list of Employee objects.
        /// </summary>
        /// <param name="lines"></param>
        /// <param name="fieldMaxWidth"></param>
        /// <returns>List of Employees and fieldMaxWidth as array</returns>
        public List<Employee> Parse(string[] lines, out int[] fieldMaxWidth)
        {
            List<Employee> employees = new List<Employee>();
            fieldMaxWidth = new int[4];
            if (lines is null || lines.Length < 1)
            {
                return employees;
            }

            SetDelimiterFormContent(lines[0]);
            foreach (string line in lines)
            {
                Employee e = ParseLine(line, fieldMaxWidth);
                if (e is not null)
                {
                    employees.Add(e);
                }
            }

            return employees;
        }
    }
}
