using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EmployeeService
{
    public class Parser
    {
        public char Delimiter { get; set; }
        private static int[] MaxFieldWidth { get; set; } = new int[4];

        public bool SetDelimiter(string line)
        {
            try
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
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        private void UpdateMaxFieldWidth(string[] record)
        {
            MaxFieldWidth[0] = record[0].Length > MaxFieldWidth[0] ? record[0].Length : MaxFieldWidth[0];
            MaxFieldWidth[1] = record[1].Length > MaxFieldWidth[1] ? record[1].Length : MaxFieldWidth[1];
            MaxFieldWidth[2] = record[2].Length > MaxFieldWidth[2] ? record[2].Length : MaxFieldWidth[2];
            MaxFieldWidth[3] = record[3].Length > MaxFieldWidth[3] ? record[3].Length : MaxFieldWidth[3];
        }

        private Employee Parse(String record)
        {
            string[] r = record.Split(Delimiter).Where(f => !String.IsNullOrWhiteSpace(f)).ToArray();

            if (r.Length != 5 || !DateTime.TryParse(r[4], out DateTime birthDay))
            {
                Console.WriteLine("Error: Invalid data {0}", record);
                return null;
            }
            UpdateMaxFieldWidth(r);
            return new(r[0].Trim(), r[1].Trim(), r[2].Trim(), r[3].Trim(), birthDay);
        }

        public string[] GetFileContent(string file)
        {
            return File.ReadAllLines(file); ;
        }

        public List<Employee> ParseFile(string file)
        {
            string[] lines = GetFileContent(file);
            SetDelimiter(lines[0]);
            List<Employee> employees = new List<Employee>();
            foreach (string line in lines)
            {
                Employee e = Parse(line);
                if (e is not null)
                {
                    employees.Add(e);
                }
            }

            Employee.UpdatePrintFormat(MaxFieldWidth);
            return employees;
        }
    }
}
