using System;
using System.IO;
using Xunit;

namespace Lab2.Tests
{
    public class ProgramTests
    {
        [Fact]
        public void Test_ValidInput()
        {
            string[] input = { "3", "1 0.1 0.9" };

            var ex = Record.Exception(() => Program.Validate(input));
            Assert.Null(ex);  // Validation should pass without exceptions
        }

        [Fact]
        public void Test_InputExceedsLimit_N()
        {
            string[] input = { "0", "1 0.1 0.9" };  // n < 1

            var ex = Record.Exception(() => Program.Validate(input));
            Assert.NotNull(ex);
            Assert.IsType<InvalidOperationException>(ex);
            Assert.Equal("The number of participants (n) must be between 1 and 100.", ex.Message);
        }

        [Fact]
        public void Test_ProbabilitiesCountMismatch()
        {
            string[] input = { "3", "1 0.1" };  // Probabilities do not match n

            var ex = Record.Exception(() => Program.Validate(input));
            Assert.NotNull(ex);
            Assert.IsType<InvalidOperationException>(ex);
            Assert.Equal("The number of probabilities must match the value of n.", ex.Message);
        }

        [Fact]
        public void Test_InvalidProbabilityValues()
        {
            string[] input = { "2", "1,2 -0,1" };  // Probabilities out of range

            var ex = Record.Exception(() => Program.Validate(input));
            Assert.NotNull(ex);
            Assert.IsType<InvalidOperationException>(ex);
            Assert.Equal("Probabilities must be valid real numbers between 0 and 1.", ex.Message);
        }

        [Fact]
        public void Test_ProcessingWithValidInput()
        {
            string[] input = { "3", "1 0,1 0,9" };

            double expected = 0.18; // Expected truth probability

            double result = Program.Process(input);

            Assert.Equal(expected, result, precision: 6); // Verify result with 6 decimal precision
        }

        [Fact]
        public void Test_InvalidNumberOfLines()
        {
            string[] input = { "5" };  // Only one line provided

            var ex = Record.Exception(() => Program.Validate(input));
            Assert.NotNull(ex);
            Assert.IsType<InvalidOperationException>(ex);
            Assert.Equal("Input must contain exactly two lines.", ex.Message);
        }
    }
}
