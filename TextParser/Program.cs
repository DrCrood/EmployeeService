namespace EmployeeService
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("Usuage: TextParser list-of-files");
                return;
            }

            List<Employee> employees = new List<Employee>();
            Parser parser = new Parser();

            foreach (string file in args)
            {
                if (File.Exists(file))
                {
                    employees.AddRange(parser.ParseFile(file));
                }
                else
                {
                    Console.WriteLine("Warning: " + file + " not found!");
                }
            }

            var orderedEmployee = employees.OrderBy(e => e.FavoriteColor).ThenBy(e => e.LastName).ToList();
            foreach (Employee p in orderedEmployee)
            {
                Console.WriteLine(p.ToString());
            }
            Console.WriteLine();
            orderedEmployee = employees.OrderBy(e => e.DateOfBirth).ToList();
            foreach (Employee p in orderedEmployee)
            {
                Console.WriteLine(p.ToString());
            }
            Console.WriteLine();
            orderedEmployee = employees.OrderByDescending(e => e.LastName).ToList();
            foreach (Employee p in orderedEmployee)
            {
                Console.WriteLine(p.ToString());
            }

        }
    }
}