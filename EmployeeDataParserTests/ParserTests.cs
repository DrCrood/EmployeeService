using Xunit;
using System;
using FluentAssertions;
using System.Collections.Generic;
using EmployeeDataParser;

namespace EmployeeDataParserTests
{
    public class ParserTests
    {
        private Parser CreateParser()
        {
            return new Parser();
        }

        [Theory]
        [MemberData(nameof(ValidEmployeeData))]
        public void Parse_ValidInput_ShouldReturnValidObjectsAndFieldWidth(string[] lines, int[] fieldWidth)
        {
            // Arrange
            var parser = this.CreateParser();
            Employee employee = new Employee("Lee", "Longname", "lee@google.com", "Red", DateTime.Parse("2005-06-25T00:00:00"));

            // Act
            var result = parser.Parse(lines, out int[] width);

            // Assert
            width.Should().BeEquivalentTo(fieldWidth);
            result[1].Should().BeEquivalentTo(employee);
        }

        [Theory]
        [MemberData(nameof(InvalidEmployeeData))]
        public void Parse_InvalidInput_ShouldReturnEmptyListAndFieldWidth(string[] lines, int[] fieldWidth)
        {
            // Arrange
            var parser = this.CreateParser();

            // Act
            var result = parser.Parse(lines, out int[] width);

            // Assert
            width.Should().BeEquivalentTo(fieldWidth);
            result.Should().BeEmpty();
        }

        [Theory]
        [MemberData(nameof(ContainsInvalidEmployeeData))]
        public void Parse_ContainsInvalidInputs_ShouldReturnValidPartAndFieldWidth(string[] lines, int[] fieldWidth)
        {
            // Arrange
            var parser = this.CreateParser();

            // Act
            var result = parser.Parse(lines, out int[] width);

            // Assert
            width.Should().BeEquivalentTo(fieldWidth);
            result.Should().HaveCount(1);
        }

        public static IEnumerable<object[]> ValidEmployeeData =>
            new List<object[]>
            {
                new object[] { new List<string> { " S. | M | sm@ya.com | Green | 2000-02-15T00:00:00",
                                                  "Lee | Longname | lee@google.com | Red | 2005-06-25T00:00:00" },
                               new int[]{3, 8, 14, 5} },
                new object[] { new List<string> { " Smith , M-longername , sm@ya.com , Green , 2000-02-15T00:00:00",
                                                  "Lee , Longname , lee@google.com, Red , 2005-06-25T00:00:00" },
                               new int[]{5, 12, 14, 5} }
            };

        public static IEnumerable<object[]> InvalidEmployeeData =>
            new List<object[]>
            {
                new object[] { new List<string> { " Smith | M | sm|@ya.com | Green | 2000-02-15T00:00:00" },
                               new int[]{0, 0, 0, 0} },

                new object[] { new List<string> { " Smith | M |     | Green | 2000-02-15T00:00:00" },
                               new int[]{0, 0, 0, 0} },

                new object[] { new List<string> { " Smith | M | sm|@ya.com | Green | 2000-02-15T00:00:00 |  extra" },
                               new int[]{0, 0, 0, 0} },
            };

        public static IEnumerable<object[]> ContainsInvalidEmployeeData =>
            new List<object[]>
            {
                new object[] { new List<string> { " Smith | M | sm@ya.com | Green | 2000-02-15T00:00:00",
                                                  "Lee | Longername | lee@google.com |  | 2005-06-25T00:00:00" },
                               new int[]{5, 1, 9, 5} },

                new object[] { new List<string> { " Smith | M | sm|@ya.com | Green | 2000-02-15T00:00:00",
                                                  "Lee | Longername | lee@google.com | Red | 2005-06-25T00:00:00" },
                               new int[]{3,10,14,3} }
            };

    }
}
