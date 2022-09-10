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

        public Employee(string lastName, string firstName, string email, string favoriteColor, DateTime dateOfBirth)
        {
            LastName = lastName;
            FirstName = firstName;
            Email = email;
            FavoriteColor = favoriteColor;
            DateOfBirth = dateOfBirth;
        }

        public override string ToString()
        {
            return String.Join(" ", LastName, FirstName, Email, FavoriteColor, DateOfBirth.ToString("d"));
        }
    }
}
