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
        private static string PrintFormatString { get; set; }

        public Employee(string lastName, string firstName, string email, string favoriteColor, DateTime dateOfBirth)
        {
            LastName = lastName;
            FirstName = firstName;
            Email = email;
            FavoriteColor = favoriteColor;
            DateOfBirth = dateOfBirth;
        }
        public static bool UpdatePrintFormat(int[] width)
        {
            if(width.Length == 4)
            {
                PrintFormatString = $"{{0,-{width[0]}}} {{1,-{width[1]}}} {{2,-{width[2]}}} {{3,-{width[3]}}} {{4:d}}";
                return true;
            }
            else
            {
                PrintFormatString = "";
                return false;
            }
        }

        public override string ToString()
        {
            if (String.IsNullOrEmpty(PrintFormatString))
            {
                return String.Join(" ", LastName, FirstName, Email, FavoriteColor, DateOfBirth.ToString("d"));
            }
            return String.Format(PrintFormatString, LastName, FirstName, Email, FavoriteColor, DateOfBirth);
        }
    }
}
