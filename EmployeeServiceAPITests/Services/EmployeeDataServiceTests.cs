using System;
using Xunit;
using Moq;
using FluentAssertions;
using EmployeeServiceAPI.Services;
using System.Linq;
using EmployeeDataParser;
using EmployeeDataParser.Interfaces;

namespace EmployeeServiceAPITests.Services
{
    public class EmployeeDataServiceTests
    {
        Mock<IParser> mockFileParser;

        public EmployeeDataServiceTests()
        {
            mockFileParser = new Mock<IParser>();
            mockFileParser.Setup(f => f.ParseLine(It.IsAny<string>(), It.IsAny<bool>())).Returns((string line, bool reset) =>
            {
                return line switch
                {
                    "Invalid" => null,
                    "Valid" => GetTestEmployee(false),
                    _ => null
                };
            });
        }
        public EmployeeDataService GetService()
        {
            return new EmployeeDataService(mockFileParser.Object);
        }

        [Fact]
        public void ParseLine_InvalidRecordData_AddShouldFail()
        {
            // Arrange
            var service = GetService();

            // Act
            var result = service.ParseLine("Invalid");

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public void ParseLine_ValidRecordData_AddShouldSucceed()
        {
            // Arrange
            var service = GetService();

            // Act
            var result = service.ParseLine("Valid");

            // Assert
            result.Should().BeEquivalentTo(GetTestEmployee(false));
        }

        [Fact]
        public void EmployeeExists_DuplicateData_ShouldReturnTrue()
        {
            // Arrange
            var service = GetService();
            var exist = GetTestEmployee(true);

            // Act
            var result = service.EmployeeExists(exist);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void EmployeeExists_NewData_ShouldReturnFalse()
        {
            // Arrange
            var service = GetService();
            var newEmployee = GetTestEmployee(false);

            // Act
            var result = service.EmployeeExists(newEmployee);

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void GetEmployeeSortByFavriteColor_Sort_ShouldSortByFavColor()
        {
            // Arrange
            var service = GetService();

            // Act
            var result = service.GetEmployeeSortByFavriteColor();
            var favColors = String.Join(" ", result.Select(e => e.FavoriteColor).ToArray());

            // Assert
            favColors.Should().BeEquivalentTo("Blue Green Pink Pink purple");
        }

        [Fact]
        public void GetEmployeeSortByLastName_Sort_ShouldSortByLastName()
        {
            // Arrange
            var service = GetService();

            // Act
            var result = service.GetEmployeeSortByLastName();
            var lastNames = String.Join(" ", result.Select(e => e.LastName).ToArray());

            // Assert
            lastNames.Should().BeEquivalentTo("Arm Cookie Fox Handy Tree");
        }

        [Fact]
        public void GetEmployeeSortByBirthDate_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = GetService();

            // Act
            var result = service.GetEmployeeSortByBirthDate();
            var dobs = String.Join(" ", result.Select(e => e.DateOfBirth.ToShortDateString()).ToArray());

            // Assert
            dobs.Should().BeEquivalentTo("2/2/2000 11/11/2001 6/1/2002 4/11/2004 11/14/2009");
        }

        private Employee GetTestEmployee(bool exist)
        {
            if(exist)
            {
                return GetService().GetEmployeeSortByLastName().FirstOrDefault();
            }
            else
            {
                return new Employee("Lname","Fname","Email","FavColor",DateTime.Parse("2001-01-01"));
            }
        }
    }
}
