using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;



class Result
{
    /*
    * SHORT SOLUTION
    */
    
    /*
     * Complete the 'getMinCost' function below.
     *
     * The function is expected to return a LONG_INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER_ARRAY crew_id
     *  2. INTEGER_ARRAY job_id
     */

    public static long getMinCost(List<int> crew_id, List<int> job_id)
    {
        int n = crew_id.Count;
        int[] crewPositions = crew_id.ToArray(); // copy to array to sort
        int[] jobPositions = job_id.ToArray(); // copy to array to sort
        Array.Sort(crewPositions);
        Array.Sort(jobPositions);

        bool[] assigned = new bool[n];
        long totalDistance = 0;

        for (int i = 0; i < n; i++) {
            int minDist = int.MaxValue;
            int minCrew = -1;
            for (int j = 0; j < n; j++) {
                if (!assigned[j]) {
                    int dist = Math.Abs(crewPositions[i] - jobPositions[j]);
                    if (dist < minDist) {
                        minDist = dist;
                        minCrew = j;
                    }
                }
            }
            assigned[minCrew] = true;
            totalDistance += minDist;
        }

        return totalDistance;
    }

    /*
    * LONG SOLUTION
    */
    /*
     * Complete the 'getMinCost' function below.
     *
     * The function is expected to return a LONG_INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER_ARRAY crew_id
     *  2. INTEGER_ARRAY job_id
     */

    // public static long getMinCost(List<int> crew_id, List<int> job_id)
    // {
    //     int n = crew_id.Count;
    //     int[] perm = new int[n];
    //     for (int i = 0; i < n; i++) {
    //         perm[i] = i;
    //     }

    //     long minDistance = long.MaxValue;
    //     do {
    //         long distance = 0;
    //         for (int i = 0; i < n; i++) {
    //             int j = perm[i];
    //             distance += Math.Abs(crew_id[i] - job_id[j]);
    //         }
    //         minDistance = Math.Min(minDistance, distance);
    //     } while (NextPermutation(perm));

    //     return minDistance;
    // }

    // // Helper function to generate all possible permutations
    // public static bool NextPermutation(int[] perm) {
    //     int n = perm.Length;
    //     int i = n - 2;
    //     while (i >= 0 && perm[i] >= perm[i + 1]) {
    //         i--;
    //     }
    //     if (i < 0) {
    //         return false;
    //     }
    //     int j = n - 1;
    //     while (perm[j] <= perm[i]) {
    //         j--;
    //     }
    //     Swap(perm, i, j);
    //     Array.Reverse(perm, i + 1, n - i - 1);
    //     return true;
    // }

    // // Helper function to swap two elements in an array
    // public static void Swap(int[] arr, int i, int j) {
    //     int temp = arr[i];
    //     arr[i] = arr[j];
    //     arr[j] = temp;
    // }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int crew_idCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> crew_id = new List<int>();

        for (int i = 0; i < crew_idCount; i++)
        {
            int crew_idItem = Convert.ToInt32(Console.ReadLine().Trim());
            crew_id.Add(crew_idItem);
        }

        int job_idCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> job_id = new List<int>();

        for (int i = 0; i < job_idCount; i++)
        {
            int job_idItem = Convert.ToInt32(Console.ReadLine().Trim());
            job_id.Add(job_idItem);
        }

        long result = Result.getMinCost(crew_id, job_id);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
