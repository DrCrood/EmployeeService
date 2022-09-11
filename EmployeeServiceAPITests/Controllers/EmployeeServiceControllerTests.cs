using EmployeeServiceAPI.Controllers;
using EmployeeServiceAPI.Interface;
using Microsoft.Extensions.Logging;
using System;
using Moq;
using Xunit;
using FluentAssertions;
using EmployeeDataParser;

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
        }

        [Theory]
        [InlineData("White   Snow   snow@yahoo.com   Blue   2009-08-08T", true)]
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
        public void GetRecordsSoerByName_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var employeeServiceController = new EmployeeServiceController(mockLogger.Object, mockEmployeeService.Object);

            // Act
            var result = employeeServiceController.GetRecordsSoerByName();

            // Assert
            Assert.True(false);
        }

        [Fact]
        public void GetRecordsSortByDob_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var employeeServiceController = new EmployeeServiceController(mockLogger.Object, mockEmployeeService.Object);

            // Act
            var result = employeeServiceController.GetRecordsSortByDob();

            // Assert
            Assert.True(false);
        }

        [Fact]
        public void GetRecordSortByColor_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var employeeServiceController = new EmployeeServiceController(mockLogger.Object, mockEmployeeService.Object);

            // Act
            var result = employeeServiceController.GetRecordSortByColor();

            // Assert
            Assert.True(false);
        }

        private Employee ParseLine(string line)
        {
            if(String.IsNullOrEmpty(line))
            {
                return null;
            }

            return default(Employee);
        }
    }
}
