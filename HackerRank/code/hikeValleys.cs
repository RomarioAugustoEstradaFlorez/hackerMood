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
     * Complete the 'findSubstring' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts following parameters:
     *  1. STRING s
     *  2. INTEGER k
     */
    public static int countingValleys(int steps, string path)
    {
        int altitude = 0;
        int previousAltitude = 0;
        int valleys = 0;
        foreach (char step in path)
        {
            if (step == 'U')
            {
                altitude++;
            }
            else
            {
                altitude--;
            }
            if (altitude == 0 && previousAltitude < 0)
            {
                valleys++;
            }
            previousAltitude = altitude;
        }
        return valleys;
    }
}
class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s = Convert.ToInt32(Console.ReadLine().Trim());

        int k = Console.ReadLine();

        string result = Result.countingValleys(s, k);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}