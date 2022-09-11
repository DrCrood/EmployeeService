using Xunit;
using System;
using EmployeeDataParser;

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
        [InlineData(new int[] { 1, 1, 4, 3}, 21)]
        [InlineData(new int[] { 5, 5, 5, 5 }, 32)]
        public void ToString_VariousFieldWidth_PrintLineLengthShouldBeCorrect(int[] width, int expected)
        {
            // Arrange
            Employee employee = new Employee("L", "F", "mail", "red", DateTime.Parse("2001-01-01"));
            Employee.UpdatePrintFormat(width, true);
            // Act
            var result = employee.ToString();

            // Assert
            Assert.Equal(expected, result.Length);
        }
    }
}
