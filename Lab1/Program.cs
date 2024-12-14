using System;
using System.Globalization;
using System.IO;
using System.Text;

namespace Lab1
{
    public class Program
    {
        public static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            // File paths
            string inputFilePath = Path.Combine("Lab1", "INPUT.TXT");
            string outputFilePath = Path.Combine("Lab1", "OUTPUT.TXT");

            // Variables for input
            int W, H;

            // Read input data
            string[] inputLines = File.ReadAllLines(inputFilePath);
            ReadInput(out W, out H, inputFilePath);

            // Validate input
            Validate(W, H);

            // Process the task
            long result = CountNonDegenerateRectangles(W, H);

            // Write output data
            WriteOutput(result, outputFilePath);

            // Console output for reference
            Console.WriteLine("Lab1");
            Console.WriteLine("Input data:");
            Console.WriteLine(string.Join(Environment.NewLine, inputLines).Trim());
            Console.WriteLine("Output data:");
            Console.WriteLine(result.ToString());

        }

        // Method to validate the input data
        public static void Validate(int W, int H)
        {
            if (W < 1 || W > 1000 || H < 1 || H > 1000)
            {
                throw new InvalidOperationException("W and H must be natural numbers not exceeding 1000.");
            }
        }

        // Method to read input data from the file
        public static void ReadInput(out int W, out int H, string inputFilePath)
        {
            using (StreamReader sr = new StreamReader(inputFilePath))
            {
                string[] inputs = sr.ReadLine().Split();
                W = int.Parse(inputs[0], CultureInfo.InvariantCulture);
                H = int.Parse(inputs[1], CultureInfo.InvariantCulture);
            }
        }

        // Method to count non-degenerate rectangles
        public static long CountNonDegenerateRectangles(int W, int H)
        {
            long total = 0;

            for (int i = 1; i <= W; i++)
            {
                for (int j = 1; j <= H; j++)
                {
                    total += (long)(W - i + 1) * (H - j + 1);
                }
            }

            return total;
        }

        // Method to write the result to the output file
        public static void WriteOutput(long result, string outputFilePath)
        {
            using (StreamWriter sw = new StreamWriter(outputFilePath))
            {
                sw.WriteLine(result.ToString());
            }
        }
    }
}
