using EmployeeDataParser;
using Moq;
using System;
using Xunit;

namespace EmployeeDataParserTests
{
    public class ParserTests
    {
        private MockRepository mockRepository;

        public ParserTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
        }

        private Parser CreateParser()
        {
            return new Parser();
        }

        [Fact]
        public void ParseFile_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var parser = this.CreateParser();
            string[] file = null;

            // Act
            var result = parser.Parse(file, out int[] width);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
