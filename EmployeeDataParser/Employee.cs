using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDataParser
{
    public class Employee
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string FavoriteColor { get; set; }
        public DateTime DateOfBirth { get; set; }
        private static string PrintFormatString { get; set; }
        private static int[] FieldWidth { get; set; } = new int[4];

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
                FieldWidth[0] = width[0] > FieldWidth[0] ? width[0] : FieldWidth[0];
                FieldWidth[1] = width[1] > FieldWidth[1] ? width[1] : FieldWidth[1];
                FieldWidth[2] = width[2] > FieldWidth[2] ? width[2] : FieldWidth[2];
                FieldWidth[3] = width[3] > FieldWidth[3] ? width[3] : FieldWidth[3];
                PrintFormatString = $"{{0,-{FieldWidth[0]}}} {{1,-{FieldWidth[1]}}} {{2,-{FieldWidth[2]}}} {{3,-{FieldWidth[3]}}} {{4:d}}";
                return true;
            }
            else
            {
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
