using Moq;
using System;
using Xunit;
using System.Linq;
using FluentAssertions;
using EmployeeDataParser;
using System.Collections.Generic;

namespace EmployeeDataParserTests
{
    public class EmployeeServiceTests
    {
        private Mock<EmployeeService> mockEmployeeService;

        public EmployeeServiceTests()
        {
            this.mockEmployeeService = new Mock<EmployeeService>();
        }

        [Fact]
        public void AddEmployeesFromFile_ValidFileContent_ShouldReturnCorrentEmployeeNumber()
        {
            // Arrange
            string file = "test";
            mockEmployeeService.Setup(s => s.GetFileContent(It.IsAny<string>())).Returns(GetTestFileContent());

            // Act
            var result = mockEmployeeService.Object.AddEmployeesFromFile(file);

            // Assert
            result.Should().Be(5);
        }

        [Fact]
        public void AddEmployeesFromFile_ContainsInvalidRecords_ShouldReturnValidRecordNumber()
        {
            // Arrange
            string file = "test";
            mockEmployeeService.Setup(s => s.GetFileContent(It.IsAny<string>())).Returns(GetTestFileContentWithInvalidRecords());

            // Act
            var result = mockEmployeeService.Object.AddEmployeesFromFile(file);

            // Assert
            result.Should().Be(3);
        }

        [Fact]
        public void AddEmployeesFromFile_EmptyContent_ShouldReturnZeroObject()
        {
            // Arrange
            string file = "test";
            mockEmployeeService.Setup(s => s.GetFileContent(It.IsAny<string>())).Returns(Array.Empty<string>());

            // Act
            var result = mockEmployeeService.Object.AddEmployeesFromFile(file);

            // Assert
            result.Should().Be(0);
        }

        [Fact]
        public void GetEmployeeCount_MultipleFileContents_ShouldReturnCorrentEmployeeNumber()
        {
            // Arrange
            string file = "test";
            mockEmployeeService.Setup(s => s.GetFileContent(It.IsAny<string>())).Returns(GetTestFileContent());
            mockEmployeeService.Object.AddEmployeesFromFile(file);
            mockEmployeeService.Setup(s => s.GetFileContent(It.IsAny<string>())).Returns(GetTestFileContentWithInvalidRecords());
            mockEmployeeService.Object.AddEmployeesFromFile(file);

            // Act
            var count = mockEmployeeService.Object.GetEmployeeCount();

            // Assert
            count.Should().Be(8);
        }

        [Fact]
        public void Print_CallAnyPrintMethod_ShouldPrintWithoutError()
        {
            // Arrange
            string file = "test";
            mockEmployeeService.CallBase = true;
            mockEmployeeService.Setup(s => s.GetFileContent(It.IsAny<string>())).Returns(GetTestFileContent());
            mockEmployeeService.Object.AddEmployeesFromFile(file);

            // Act
            Action act = () => mockEmployeeService.Object.PrintEmployeesByFavcolorAndLastName();

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void GetEmployeeListSortByColorAndLastName_SortEmployees_EmployeesShouldBeInSortedOrder()
        {
            // Arrange
            string file = "test";
            mockEmployeeService.Setup(s => s.GetFileContent(It.IsAny<string>())).Returns(GetTestFileContent());
            mockEmployeeService.Object.AddEmployeesFromFile(file);

            // Act
            var result = mockEmployeeService.Object.GetEmployeesSortedByFavColorAndLastName();
            var colors = string.Join(" ", result.Select(e => e.FavoriteColor).ToList());
            var lastNames = string.Join(" ", result.Select(e => e.LastName).ToList());

            // Assert
            colors.Should().BeEquivalentTo("Blue Blue Blue Pink Purple");
            lastNames.Should().BeEquivalentTo("Car Cook Tea Handy Tree");
        }

        [Fact]
        public void GetEmployeeListSortByDateOfBirth_SortEmployees_EmployeesShouldBeInSortedOrder()
        {
            // Arrange
            string file = "test";
            mockEmployeeService.Setup(s => s.GetFileContent(It.IsAny<string>())).Returns(GetTestFileContent());
            mockEmployeeService.Object.AddEmployeesFromFile(file);

            // Act
            var result = mockEmployeeService.Object.GetEmployeesSortedByDateOfBirth();
            var dobs = string.Join(" ", result.Select(e => e.DateOfBirth.ToShortDateString()).ToList());

            // Assert
            dobs.Should().BeEquivalentTo("2/2/2000 4/12/2001 1/1/2002 3/5/2003 4/11/2004");
        }

        [Fact]
        public void GetEmployeeListSortByLastNameDesc_SortEmployees_EmployeesShouldBeInSortedOrder()
        {
            // Arrange
            string file = "test";
            mockEmployeeService.Setup(s => s.GetFileContent(It.IsAny<string>())).Returns(GetTestFileContent());
            mockEmployeeService.Object.AddEmployeesFromFile(file);

            // Act
            var result = mockEmployeeService.Object.GetEmployeesSortedByLastNameDesc();
            var lastNames = string.Join(" ", result.Select(e => e.LastName).ToList());

            // Assert
            lastNames.Should().BeEquivalentTo("Tree Tea Handy Cook Car");
        }

        private string[] GetTestFileContent()
        {
            List<string> lines = new List<string>();
            lines.Add("Tea | Hot | hottea@outlook.com | Blue | 2001 - 04 - 12T00: 00:00");
            lines.Add("Cook | Apple | apple@example.com | Blue | 2003 - 03 - 05T00: 00:00");
            lines.Add("Tree | Green | green@google.com | purple | 2004 - 04 - 11T00: 00:00");
            lines.Add("Car | Fast | fastcar@google.com | Blue | 2002 - 01 - 01T00: 00:00");
            lines.Add("Handy | Man | man@outlook.com | Pink | 2000 - 02 - 02T00: 00:00");
 
            return lines.ToArray();
        }

        private string[] GetTestFileContentWithInvalidRecords()
        {
            List<string> lines = new List<string>();
            lines.Add("Tea |   | hottea@outlook.com | Blue | 2001 - 04 - 12T00: 00:00");
            lines.Add("Cook | Apple | apple@example.com | Blue | 2003 - 03 - 05T00: 00:00");
            lines.Add("Tree | Green | green@google.com | purple | 2004 - 04 - 11T00: 00:00");
            lines.Add("Car | Fast | fastcar@google.com | Blue | 2002 - 01 - 01T00: 00:00");
            lines.Add("Handy | Man | man@outlook.com | Pink | 2000 | - 02 - 02T00: 00:00");

            return lines.ToArray();
        }
    }
}
