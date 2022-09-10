using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeService
{
    public class Employee
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string FavoriteColor { get; set; }
        public DateTime DateOfBirth { get; set; }
        private static string PrintFormat { get; set; }

        public Employee(string lastName, string firstName, string email, string favoriteColor, DateTime dateOfBirth)
        {
            LastName = lastName;
            FirstName = firstName;
            Email = email;
            FavoriteColor = favoriteColor;
            DateOfBirth = dateOfBirth;
        }
        public static void UpdatePrintFormat(int[] width)
        {
            PrintFormat = $"{{0,-{width[0]}}} {{1,-{width[1]}}} {{2,-{width[2]}}} {{3,-{width[3]}}} {{4:d}}";
        }

        public override string ToString()
        {
            if (PrintFormat is null)
            {
                return String.Join(" ", LastName, FirstName, Email, FavoriteColor, DateOfBirth.ToString("d"));
            }
            return String.Format(PrintFormat, LastName, FirstName, Email, FavoriteColor, DateOfBirth);
        }
    }
}
