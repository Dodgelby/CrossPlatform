using System;
using Xunit;
using ClassLibraryLab3;

namespace Lab3.Tests
{
    public class ProgramTests
    {
        [Fact]
        public void Validate_ValidInput_ShouldPass()
        {
            string[] lines =
            {
                "4",
                "1 4",
                "1 2 3"
            };

            var ex = Record.Exception(() => Program.Validate(lines));

            Assert.Null(ex); // Test passes if no exception is thrown
        }

        [Fact]
        public void Validate_NOutOfRange_ShouldThrowException()
        {
            string[] lines =
            {
                "0",
                "1 2",
                ""
            };

            var ex = Record.Exception(() => Program.Validate(lines));

            Assert.NotNull(ex);
            Assert.Equal("N must be between 1 and 30000.", ex.Message);
        }

        [Fact]
        public void Validate_InvalidDepartments_ShouldThrowException()
        {
            string[] lines =
            {
                "4",
                "1 A",
                "1 2 3"
            };

            var ex = Record.Exception(() => Program.Validate(lines));

            Assert.NotNull(ex);
            Assert.Equal("Second line must contain two integers representing the departments.", ex.Message);
        }

        [Fact]
        public void Validate_InvalidParentDepartments_ShouldThrowException()
        {
            string[] lines =
            {
                "4",
                "1 4",
                "1 2"
            };

            var ex = Record.Exception(() => Program.Validate(lines));

            Assert.NotNull(ex);
            Assert.Equal("Expected 3 parent department entries.", ex.Message);
        }

        [Fact]
        public void Validate_Departments__ShouldPass2()
        {
            string[] lines =
            {
                "8",
                "3 6",
                "1 1 2 4 5 1 1"
            };

            var ex = Record.Exception(() => Program.Validate(lines));

            Assert.Null(ex);
        }

    }
}
