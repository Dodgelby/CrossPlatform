using System;
using System.IO;
using System.Linq;
using System.Text;

namespace Lab2
{
    public class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            try
            {
                Console.OutputEncoding = Encoding.UTF8;
                string inputFilePath = Path.Combine("Lab2", "INPUT.TXT");
                string outputFilePath = Path.Combine("Lab2", "OUTPUT.TXT");

                // Read input
                string[] input = File.ReadAllLines(inputFilePath);

                // Validate input
                Validate(input);

                // Process the problem
                double result = Process(input);

                // Write the result to output file
                File.WriteAllText(outputFilePath, result.ToString("F6"));

                // Optional: Console output for debugging
                Console.WriteLine("Lab2");
                Console.WriteLine("Input data:");
                Console.WriteLine(string.Join(Environment.NewLine, input));
                Console.WriteLine("Output data:");
                Console.WriteLine(result.ToString("F6"));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public static void Validate(string[] input)
        {
            if (input.Length != 2)
            {
                throw new InvalidOperationException("Input must contain exactly two lines.");
            }

            if (!int.TryParse(input[0], out int n) || n < 1 || n > 100)
            {
                throw new InvalidOperationException("The number of participants (n) must be between 1 and 100.");
            }

            string[] probabilities = input[1].Split(' ');

            // Ensure the number of probabilities matches n
            if (probabilities.Length != n)
            {
                throw new InvalidOperationException("The number of probabilities must match the value of n.");
            }

            // Parse and validate each probability value
            foreach (string p in probabilities)
            {
                double.TryParse(p, out double value);
                if ( value < 0 || value > 1)
                {
                    throw new InvalidOperationException("Probabilities must be valid real numbers between 0 and 1.");
                }
            }

        }

        public static double Process(string[] input)
        {
            int n = int.Parse(input[0]);
            double[] probabilities = input[1].Split(' ').Select(double.Parse).ToArray();

            double truthProbability = 1.0;

            for (int i = 0; i < n; i++)
            {
                double pi = probabilities[i];
                truthProbability = truthProbability * pi + (1 - truthProbability) * (1 - pi);
            }

            return truthProbability;
        }
    }
}
