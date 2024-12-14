using System;
using System.IO;
using Xunit;

namespace Lab1.Tests
{
    public class ProgramTests
    {
        [Fact]
        public void Test_ValidInput()
        {
            int W = 3;
            int H = 2;

            var ex = Record.Exception(() => Program.Validate(W, H));
            Assert.Null(ex);
        }

        [Fact]
        public void Test_Invalid_W_ExceedsLimit()
        {
            int W = 1001;
            int H = 10;

            var ex = Record.Exception(() => Program.Validate(W, H));
            Assert.NotNull(ex);
            Assert.IsType<InvalidOperationException>(ex);
            Assert.Equal("W and H must be natural numbers not exceeding 1000.", ex.Message);
        }

        [Fact]
        public void Test_Invalid_H_ExceedsLimit()
        {
            int W = 10;
            int H = 1001;

            var ex = Record.Exception(() => Program.Validate(W, H));
            Assert.NotNull(ex);
            Assert.IsType<InvalidOperationException>(ex);
            Assert.Equal("W and H must be natural numbers not exceeding 1000.", ex.Message);
        }

        [Fact]
        public void Test_CorrectRectangleCount()
        {
            int W = 3;
            int H = 2;

            long expected = 18; 
            long result = Program.CountNonDegenerateRectangles(W, H);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Test_LargeInputBoundary()
        {
            int W = 1000;
            int H = 1000;

            long result = Program.CountNonDegenerateRectangles(W, H);

            Assert.True(result > 0); 
        }

        [Fact]
        public void Test_ReadInput()
        {
            string inputFilePath = "TestInput.TXT";
            File.WriteAllText(inputFilePath, "3 2");

            int W, H;
            Program.ReadInput(out W, out H, inputFilePath);

            Assert.Equal(3, W);
            Assert.Equal(2, H);

            File.Delete(inputFilePath);
        }

        [Fact]
        public void Test_WriteOutput()
        {
            string outputFilePath = "TestOutput.TXT";
            long result = 18;

            Program.WriteOutput(result, outputFilePath);

            string writtenContent = File.ReadAllText(outputFilePath).Trim();
            Assert.Equal("18", writtenContent);

            File.Delete(outputFilePath);
        }
    }
}
