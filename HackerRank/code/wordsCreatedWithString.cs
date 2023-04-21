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

    public static string findSubstring(string s, int k)
    {
        string answer = "Not found!";
        
        if(string.IsNullOrEmpty(s) && k == 0) return answer;
        
        if(s.Length >= 1 && s.Length <= 200000) {
            if(k >= 1 && k <= s.Length) {
                string[] words = new string[s.Length - k + 1];
                
                for(int i = 0; i < words.Length; i++) {
                    string? word = s.Substring(i, k);
                    words[i] = word!;
                }
                
                int maxVowels = 0;
                string wordWithMostVowels = answer;
                
                foreach(string word in words) {
                    int numVowels = 0;
                    foreach(char cha in word) {
                        if("aeiou".Contains(cha)) numVowels++;
                    }
                    
                    if(numVowels > maxVowels) {
                        maxVowels = numVowels;
                        wordWithMostVowels = word;
                    }
                }
                
                answer = wordWithMostVowels;
                return answer;
            }
        }
        
        return answer;
    }

}
class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s = Console.ReadLine();

        int k = Convert.ToInt32(Console.ReadLine().Trim());

        string result = Result.findSubstring(s, k);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
