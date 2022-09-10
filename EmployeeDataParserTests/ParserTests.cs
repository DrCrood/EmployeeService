using Moq;
using System;
using Xunit;
using EmployeeService;

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
        public void SetDelimiter_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var parser = this.CreateParser();
            string line = null;

            // Act
            var result = parser.SetDelimiter(
                line);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void GetFileContent_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var parser = this.CreateParser();
            string file = null;

            // Act
            var result = parser.GetFileContent(
                file);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void ParseFile_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var parser = this.CreateParser();
            string file = null;

            // Act
            var result = parser.ParseFile(
                file);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
