using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeService
{
    public class Parser
    {
        public char Delimiter { get; set; }
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

        private Employee Parse(String record)
        {
            string[] r = record.Split(Delimiter).Where(f => !String.IsNullOrWhiteSpace(f)).ToArray();

            if (r.Length != 5 || !DateTime.TryParse(r[4], out DateTime birthDay))
            {
                Console.WriteLine("Error: Invalid data {0}", record);
                return null;
            }

            return new(r[0].Trim(), r[1].Trim(), r[2].Trim(), r[3].Trim(), birthDay);
        }

        public List<Employee> ParseFile(string file)
        {
            string[] lines = File.ReadAllLines(file);
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
            return employees;
        }
    }
}
