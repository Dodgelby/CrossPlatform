using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibraryLab3
{
    public class TaskProcessor
    {
        // Define global variables
        static List<int>[] graph;
        static int[] ret;
        static bool[] used;
        static int last, n;

        public static string ProcessTask(string[] lines)
        {
            // Initialize graph and arrays
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

            // Extract the start and end departments
            int first_ = int.Parse(lines[1].Split()[0]);
            DFS(first_);

            // Start solving from the first department
            return Solve(first_).ToString();
        }

        static void DFS(int node)
        {
            used[node] = true;
            foreach (var neighbor in graph[node])
            {
                if (!used[neighbor])
                {
                    DFS(neighbor);
                }
            }
        }

        static int Solve(int startNode)
        {
            DFS(startNode);
            if (used[last])
            {
                return startNode; // Return the department where equipment should be placed
            }
            return Solve(ret[startNode]);
        }
    }
}
