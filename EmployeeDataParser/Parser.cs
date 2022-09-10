using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EmployeeDataParser
{
    public class Parser : IParser
    {
        private char Delimiter { get; set; }
        private int[] MaxFieldWidth { get; set; } = new int[4];

        private void SetDelimiter(string line)
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

        private Employee ParseLine(String record, int[] width)
        {
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

            width[0] = lastName.Length > width[0] ? lastName.Length : width[0];
            width[1] = firstName.Length > width[1] ? firstName.Length : width[1];
            width[2] = email.Length > width[2] ? email.Length : width[2];
            width[3] = favColor.Length > width[3] ? favColor.Length : width[3];

            return new(lastName, firstName, email, favColor, birthDay);
        }



        public List<Employee> Parse(string[] lines, out int[] fieldWidth)
        {
            SetDelimiter(lines[0]);
            fieldWidth = new int[4];

            List<Employee> employees = new List<Employee>();
            foreach (string line in lines)
            {
                Employee e = ParseLine(line, fieldWidth);
                if (e is not null)
                {
                    employees.Add(e);
                }
            }

            return employees;
        }
    }
}
