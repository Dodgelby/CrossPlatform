using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1;
using Lab2;
using ClassLibraryLab3;

namespace Lab4
{
    internal class LabRunner
    {
        public void RunLab1(string inputFile, string outputFile)
        {
            try
            {
                // Variables for input
                int W, H;

                // Read input data
                string[] lines = File.ReadAllLines(inputFile);
                Lab1.Program.ReadInput(out W, out H, inputFile);

                // Process the task
                long result = Lab1.Program.CountNonDegenerateRectangles(W, H);

                File.WriteAllText(outputFile, result.ToString().Trim());

                Console.WriteLine("Lab1");
                Console.WriteLine("Input data:");
                Console.WriteLine(string.Join(Environment.NewLine, lines).Trim());
                Console.WriteLine("Output data:");
                Console.WriteLine(result.ToString().Trim());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public void RunLab2(string inputFile, string outputFile)
        {
            try
            {
                Console.OutputEncoding = Encoding.UTF8;
                string[] lines = File.ReadAllLines(inputFile);

                var result = Lab2.Program.Process(lines);

                File.WriteAllText(outputFile, result.ToString().Trim()); 

                Console.WriteLine("Lab2");
                Console.WriteLine("Input data:");
                Console.WriteLine(string.Join(Environment.NewLine, lines).Trim());
                Console.WriteLine("Output data:");
                Console.WriteLine(result.ToString().Trim());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        public void RunLab3(string inputFile, string outputFile)
        {
            try
            {
                Console.OutputEncoding = Encoding.UTF8;
                string[] lines = File.ReadAllLines(inputFile);

                string result = TaskProcessor.ProcessTask(lines); 

                File.WriteAllText(outputFile, result.Trim()); 

                Console.WriteLine("Lab3");
                Console.WriteLine("Input data:");
                Console.WriteLine(string.Join(Environment.NewLine, lines).Trim());
                Console.WriteLine("Output data:");
                Console.WriteLine(result.Trim());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
