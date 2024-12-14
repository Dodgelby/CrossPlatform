using System;
using System.IO;
using System.Collections.Generic;
using ClassLibraryLab3;

namespace Lab3
{
    public class Program
    {
        // Define global variables
        static List<int>[] graph;
        static int[] ret;
        static bool[] used;
        static int last, n;

        public static void Main(string[] args)
        {
            try
            {
                string inputFilePath = Path.Combine("Lab3", "INPUT.TXT");
                string outputFilePath = Path.Combine("Lab3", "OUTPUT.TXT");

                // Read the input file
                string[] lines = File.ReadAllLines(inputFilePath);
                Validate(lines);

                // Process the task and get the result
                string result = TaskProcessor.ProcessTask(lines);

                // Write the result to output file
                File.WriteAllText(outputFilePath, result);

                // Optional: Display results
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

        public static void Validate(string[] lines)
        {
            // Validate input data according to the problem statement
            if (lines.Length < 3)
                throw new InvalidOperationException("Input must contain at least three lines.");

            if (!int.TryParse(lines[0], out n) || n < 1 || n > 30000)
                throw new InvalidOperationException("N must be between 1 and 30000.");

            string[] departments = lines[1].Split();
            if (departments.Length != 2 || !int.TryParse(departments[0], out int first) || !int.TryParse(departments[1], out last))
                throw new InvalidOperationException("Second line must contain two integers representing the departments.");

            if (last < first)
            {
                int temp = last;
                last = first;
                first = temp;
            }

            // Initialize graph and arrays
            graph = new List<int>[n + 1];
            ret = new int[n + 1];
            used = new bool[n + 1];

            for (int i = 0; i <= n; i++)
            {
                graph[i] = new List<int>();
            }

            // Process the department connections
            string[] parentDepartments = lines[2].Split();
            if (parentDepartments.Length != n - 1)
                throw new InvalidOperationException($"Expected {n - 1} parent department entries.");

            for (int i = 0; i < parentDepartments.Length; i++)
            {
                int parent = int.Parse(parentDepartments[i]);
                graph[parent].Add(i + 2);
                ret[i + 2] = parent;
            }
        }

    }
}
