using EmployeeService;
using Xunit;
using System;
using System.Collections.Generic;

namespace EmployeeDataParserTests
{
    public class EmployeeTests
    {
    
        [Fact]
        public void UpdatePrintFormat_ValidWidthArray_ShouldSetCorrectFormatString()
        {
            // Arrange
            int[] width = new int[] {1,2,3,4 };

            // Act
            var result = Employee.UpdatePrintFormat(width);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void UpdatePrintFormat_InvalidWidthArray_ShouldNotSetFormatString()
        {
            // Arrange
            int[] width = new int[] { 1, 2, 3};

            // Act
            var result = Employee.UpdatePrintFormat(width);

            // Assert
            Assert.False(result);
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void ToString_VariousFieldWidth_PrintLineLengthShouldBeCorrect(List<Employee> employees, int expected)
        {
            // Arrange

            // Act
            var result = employees[0].ToString();

            // Assert
            Assert.Equal(expected, result.Length);
        }

        public static IEnumerable<object[]> Data()
        {
            DateTime dob = DateTime.Parse("2001-01-01");

            return new List<object[]>
            {
                new object[] { new List<Employee> { new Employee("L", "F", "mail", "Col", dob) }, 21 },
                new object[] { new List<Employee> { new Employee("L", "F", "mail", "Col", dob ),
                                                    new Employee("Lname", "Fname", "Email", "Color", dob )}, 32 },
            };
        }
    }
}
