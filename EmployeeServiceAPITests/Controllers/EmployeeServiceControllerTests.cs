using System;
using Moq;
using Xunit;
using FluentAssertions;
using EmployeeDataParser;
using System.Collections.Generic;
using EmployeeServiceAPI.Controllers;
using EmployeeServiceAPI.Interface;
using Microsoft.Extensions.Logging;

namespace EmployeeServiceAPITests.Controllers
{
    public class EmployeeServiceControllerTests
    {
        private Mock<IEmployeeDataService> mockEmployeeService;
        private Mock<ILogger<EmployeeServiceController>> mockLogger;
        public EmployeeServiceControllerTests()
        {
            mockEmployeeService = new Mock<IEmployeeDataService>();
            mockLogger = new Mock<ILogger<EmployeeServiceController>>();

            mockEmployeeService.Setup(s => s.AddEmployee(It.IsAny<string>())).Returns( (string line) => ParseLine(line));
            mockEmployeeService.Setup(S => S.GetEmployeeSortByLastName()).Returns(GetEmployeeByProperty("LastName"));
            mockEmployeeService.Setup(s => s.GetEmployeeSortByBirthDate()).Returns(GetEmployeeByProperty("BirthDate"));
            mockEmployeeService.Setup(s => s.GetEmployeeSortByFavriteColor()).Returns(GetEmployeeByProperty("FavColor"));
        }

        [Theory]
        [InlineData("valid", true)]
        [InlineData(" ", false)]
        [InlineData(null, false)]
        public void AddEmployee_ValidRecord_ShouldReturnValidEmployee(string line, bool success)
        {
            // Arrange
            var employeeServiceController = new EmployeeServiceController(mockLogger.Object, mockEmployeeService.Object);

            // Act
            var employee = employeeServiceController.AddEmployee(line);
            bool result = employee is not null;

            // Assert
            result.Equals(success);
        }

        [Fact]
        public void GetRecordsSortByName_ValidRequest_ShouldReturnValidList()
        {
            // Arrange
            var employeeServiceController = new EmployeeServiceController(mockLogger.Object, mockEmployeeService.Object);

            // Act
            var result = employeeServiceController.GetRecordsSortByLastName();

            // Assert
            result.Should().BeEquivalentTo(GetEmployeeByProperty("LastName"));
        }

        [Fact]
        public void GetRecordsSortByDob_ValidRequest_ShouldReturnValidList()
        {
            // Arrange
            var employeeServiceController = new EmployeeServiceController(mockLogger.Object, mockEmployeeService.Object);

            // Act
            var result = employeeServiceController.GetRecordsSortByDob();

            // Assert
            result.Should().BeEquivalentTo(GetEmployeeByProperty("BirthDate"));
        }

        [Fact]
        public void GetRecordSortByFavColor_ValidRequest_ShouldReturnValidList()
        {
            // Arrange
            var employeeServiceController = new EmployeeServiceController(mockLogger.Object, mockEmployeeService.Object);

            // Act
            var result = employeeServiceController.GetRecordSortByFavColor();

            // Assert
            result.Should().BeEquivalentTo(GetEmployeeByProperty("FavColor"));
        }

        private Employee ParseLine(string line)
        {
            if(String.IsNullOrEmpty(line))
            {
                return null;
            }

            return default(Employee);
        }

        private List<Employee> GetEmployeeByProperty(string property)
        {
            return property switch
            {
                "FavColor" => new List<Employee>() { new Employee("", "", "", "FavColor", DateTime.Parse("2001-01-01")) },
                "LastName" => new List<Employee>() { new Employee("LastName", "", "", "", DateTime.Parse("2001-01-01")) },
                "BirthDate" => new List<Employee>() {new Employee("", "", "", "", DateTime.Parse("2001-01-01")) },
                _ => null
            };
        }
    }
}
