using System;
using Xunit;
using FluentAssertions;
using EmployeeServiceAPI.Services;
using System.Linq;

namespace EmployeeServiceAPITests.Services
{
    public class EmployeeDataServiceTests
    {
        public EmployeeDataService GetService()
        {
            return new EmployeeDataService();
        }

        [Fact]
        public void AddEmployee_ValidRecordData_ShouldAddEmployeeToList()
        {
            // Arrange
            var service = GetService();
            string record = " Smile   Small   ssmile@email.com   Pink   2003-09-10T00:00:00";

            // Act
            var result = service.AddEmployee(record);

            // Assert
            result.Should().NotBeNull();
        }

        [Fact]
        public void AddEmployee_InvalidRecordData_AddShouldFail()
        {
            // Arrange
            var service = GetService();
            string record = " Smile   Small |  ssmile@email.com   Pink   2003-09-10T00:00:00";

            // Act
            var result = service.AddEmployee(record);

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public void GetEmployeeSortByFavriteColor_Sort_ShouldSortByFavColor()
        {
            // Arrange
            var service = new EmployeeDataService();

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
            var service = new EmployeeDataService();

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
            var service = new EmployeeDataService();

            // Act
            var result = service.GetEmployeeSortByBirthDate();
            var dobs = String.Join(" ", result.Select(e => e.DateOfBirth.ToShortDateString()).ToArray());

            // Assert
            dobs.Should().BeEquivalentTo("2/2/2000 11/11/2001 6/1/2002 4/11/2004 11/14/2009");
        }
    }
}
