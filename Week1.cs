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

namespace Week1
{
    class Week1
    {
        static void Main(string[] args)
        {
            CamelCase();
        }
        // Day 1
        public static void plusMinus(List<int> arr)
        {
            Console.WriteLine("{0:N6}", (arr.Where(numb => numb > 0).Count() / (double)arr.Count));
            Console.WriteLine("{0:N6}", (arr.Where(numb => numb < 0).Count() / (double)arr.Count));
            Console.WriteLine("{0:N6}", (arr.Where(numb => numb == 0).Count() / (double)arr.Count));
        }

        // Day 2
        public static void miniMaxSum(List<int> arr)
        {
            List<double> arrRes = new List<double>();
            foreach (int item in arr)
            {
                arrRes.Add((double)item);
            }
            arrRes.Sort();
            Console.WriteLine((arrRes.Sum() - arrRes.Max()) + " " + (arrRes.Sum() - arrRes.Min()));
        }

        // Day 3
        public static string timeConversion(string s)
        {
            string[] res = s.Split(':');
            if (res[res.Length - 1][2] == 'A')
            {
                if (res[0] == "12")
                {
                    return "00:" + res[1] + ":" + res[2][0] + res[2][1];
                }
                else
                {
                    return res[0] + ":" + res[1] + ":" + res[2][0] + res[2][1];
                }
            }
            else
            {
                if (res[0] == "12")
                {
                    return "12:" + res[1] + ":" + res[2][0] + res[2][1];
                }
                else
                {
                    return (int.Parse(res[0]) + 12).ToString() + ":" + res[1] + ":" + res[2][0] + res[2][1];
                }
            }
        }

        // Day 4
        public static List<int> breakingRecords(List<int> scores)
        {
            List<int> result = new List<int>();
            result.Add(-1);
            result.Add(-1);
            int min = int.MaxValue, max = int.MinValue;
            foreach (int item in scores)
            {
                if (item < min)
                {
                    min = item;
                    result[1]++;
                }
                if (item > max)
                {
                    max = item;
                    result[0]++;
                }
            }
            return result;
        }

        // Day 5
        static void CamelCase()
        {
            List<string> resultStrings = new List<string>();
            string line;
            while ((line = Console.ReadLine()) != null && line != "")
            {
                resultStrings.Add(line);
            }
            for (int k = 0; k < resultStrings.Count; k++)
            {
                string result = resultStrings[k];
                string endResult = result;
                if (result[0] == 'S')
                {
                    if (result[2] == 'M')
                    {
                        result = result.Substring(4, result.Length - 6);
                        endResult = "";
                        foreach (char item in result)
                        {
                            if (Char.IsUpper(item))
                            {
                                endResult += (' ').ToString();
                                endResult += (Char.ToLower(item)).ToString();
                            }
                            else
                                endResult += (item).ToString();
                        }
                        endResult = endResult.TrimStart();
                    }
                    else if (result[2] == 'V')
                    {
                        result = result.Substring(4, result.Length - 4);
                        endResult = "";
                        foreach (char item in result)
                        {
                            if (Char.IsUpper(item))
                            {
                                endResult += (' ').ToString();
                                endResult += (Char.ToLower(item)).ToString();
                            }
                            else
                                endResult += (item).ToString();
                        }
                        endResult = endResult.TrimStart();
                    }
                    else
                    {
                        result = result.Substring(4, result.Length - 4);
                        endResult = "";
                        foreach (char item in result)
                        {
                            if (Char.IsUpper(item))
                            {
                                endResult += (' ').ToString();
                                endResult += (Char.ToLower(item)).ToString();
                            }
                            else
                                endResult += (item).ToString();
                        }
                        endResult = endResult.TrimStart();
                    }
                }
                else
                {
                    if (result[2] == 'M')
                    {
                        result = result.Substring(4, result.Length - 4);
                        string[] subResult = result.Split(' ');
                        endResult = subResult[0];
                        for (int i = 1; i < subResult.Length; i++)
                        {
                            endResult += (Char.ToUpper(subResult[i][0])).ToString();
                            for (int j = 1; j < subResult[i].Length; j++)
                            {
                                endResult += (subResult[i][j]).ToString();
                            }
                        }
                        endResult += ('(').ToString();
                        endResult += (')').ToString();
                    }
                    else if (result[2] == 'V')
                    {
                        result = result.Substring(4, result.Length - 4);
                        string[] subResult = result.Split(' ');
                        endResult = subResult[0];
                        for (int i = 1; i < subResult.Length; i++)
                        {
                            endResult += (Char.ToUpper(subResult[i][0])).ToString();
                            for (int j = 1; j < subResult[i].Length; j++)
                            {
                                endResult += (subResult[i][j]).ToString();
                            }
                        }
                    }
                    else
                    {
                        result = result.Substring(4, result.Length - 4);
                        string[] subResult = result.Split(' ');
                        endResult = "";
                        for (int i = 0; i < subResult.Length; i++)
                        {
                            endResult += (Char.ToUpper(subResult[i][0])).ToString();
                            for (int j = 1; j < subResult[i].Length; j++)
                            {
                                endResult += (subResult[i][j]).ToString();
                            }
                        }
                    }
                }

                Console.WriteLine(endResult);
            }
        }

        //static void CamelCase()
        //{
        //    bool readInput = true;
        //    List<string> resultStrings = new List<string>();
        //    while (readInput)
        //    {
        //        string input = Console.ReadLine();
        //        if (input != "")
        //            resultStrings.Add(input);
        //        else
        //            readInput = false;
        //    }

        //    for (int k = 0; k < resultStrings.Count; k++)
        //    {
        //        string result = resultStrings[k];
        //        string endResult = result;
        //        if (result[0] == 'S')
        //        {
        //            if (result[2] == 'M')
        //            {
        //                result = result.Substring(4, result.Length - 6);
        //                endResult = "";
        //                foreach (char item in result)
        //                {
        //                    if (Char.IsUpper(item))
        //                    {
        //                        endResult += (' ').ToString();
        //                        endResult += (Char.ToLower(item)).ToString();
        //                    }
        //                    else
        //                        endResult += (item).ToString();
        //                }
        //                endResult = endResult.TrimStart();
        //            }
        //            else if (result[2] == 'V')
        //            {
        //                result = result.Substring(4, result.Length - 4);
        //                endResult = "";
        //                foreach (char item in result)
        //                {
        //                    if (Char.IsUpper(item))
        //                    {
        //                        endResult += (' ').ToString();
        //                        endResult += (Char.ToLower(item)).ToString();
        //                    }
        //                    else
        //                        endResult += (item).ToString();
        //                }
        //                endResult = endResult.TrimStart();
        //            }
        //            else
        //            {
        //                result = result.Substring(4, result.Length - 4);
        //                endResult = "";
        //                foreach (char item in result)
        //                {
        //                    if (Char.IsUpper(item))
        //                    {
        //                        endResult += (' ').ToString();
        //                        endResult += (Char.ToLower(item)).ToString();
        //                    }
        //                    else
        //                        endResult += (item).ToString();
        //                }
        //                endResult = endResult.TrimStart();
        //            }
        //        }
        //        else
        //        {
        //            if (result[2] == 'M')
        //            {
        //                result = result.Substring(4, result.Length - 4);
        //                string[] subResult = result.Split(' ');
        //                endResult = subResult[0];
        //                for (int i = 1; i < subResult.Length; i++)
        //                {
        //                    endResult += (Char.ToUpper(subResult[i][0])).ToString();
        //                    for (int j = 1; j < subResult[i].Length; j++)
        //                    {
        //                        endResult += (subResult[i][j]).ToString();
        //                    }
        //                }
        //                endResult += ('(').ToString();
        //                endResult += (')').ToString();
        //            }
        //            else if (result[2] == 'V')
        //            {
        //                result = result.Substring(4, result.Length - 4);
        //                string[] subResult = result.Split(' ');
        //                endResult = subResult[0];
        //                for (int i = 1; i < subResult.Length; i++)
        //                {
        //                    endResult += (Char.ToUpper(subResult[i][0])).ToString();
        //                    for (int j = 1; j < subResult[i].Length; j++)
        //                    {
        //                        endResult += (subResult[i][j]).ToString();
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                result = result.Substring(4, result.Length - 4);
        //                string[] subResult = result.Split(' ');
        //                endResult = "";
        //                for (int i = 0; i < subResult.Length; i++)
        //                {
        //                    endResult += (Char.ToUpper(subResult[i][0])).ToString();
        //                    for (int j = 1; j < subResult[i].Length; j++)
        //                    {
        //                        endResult += (subResult[i][j]).ToString();
        //                    }
        //                }
        //            }
        //        }

        //        Console.WriteLine(endResult);
        //    }
        //}

        // Day 6
        public static int divisibleSumPairs(int n, int k, List<int> ar)
        {
            int result = 0;
            ar.Sort();
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if ((ar[i] + ar[j]) % k == 0)
                        result++;
                }
            }
            return result;
        }

        // Day 7

        public static List<int> matchingStrings(List<string> strings, List<string> queries)
        {
            List<int> result = new List<int>();

            foreach(string item in queries)
            {          
                result.Add(strings.Where(substring => substring.Equals(item)).Count());
            }

            return result;
        }
    }
}
