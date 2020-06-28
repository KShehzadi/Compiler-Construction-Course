using System;
using System.Collections.Generic;
using System.IO;

namespace LexicalAnalyzerByTransitionTable
{
    class Program
    {

        static bool issep(char c)
        {

            if (c.ToString() == "\0" || c.ToString() == "\n" || c.ToString() == "\r")
            {
                return true;
            }
            return false;
        }

        static bool issepid(char c)
        {
            if (c.ToString() == " " || c.ToString() == "\n" || c == '<' || c == '>' || c == '=' || c == ':' || c == ';' || c.ToString() == "\r" || c.ToString() == ")" || c.ToString() == "(" || c.ToString() == "}" || c.ToString() == "{" || c.ToString() == "[" || c.ToString() == "]")
            {
                return true;
            }
            return false;
        }
        static bool isseprelop(char c)
        {

            if (c.ToString() == "\0" || c.ToString() == "\n" || isdigitoralphabet(c) || c.ToString() == "\r")
            {
                return true;
            }
            return false;
        }
        static bool isalphabet(char c)
        {
            return char.IsLetter(c);
        }
        static bool isdigitoralphabet(char c)
        {

            return char.IsLetterOrDigit(c);
        }
        static int GetColumnNumber(string[,] transitiontable, char c)
        {
            string token = c.ToString();
            token.Trim();
            if (isalphabet(token.ToCharArray()[0]))
            {
                token = "alphabet";
            }
            else if (isdigitoralphabet(token.ToCharArray()[0]))
            {
                token = "digit";
            }

            int column = -1;
            int k = transitiontable.GetUpperBound(1);
            for (int i = 0; i < k; i++)
            {

                if (token == transitiontable[0, i].Trim())
                {
                    column = i;
                }
            }
            if (column == -1)
            {
                if (isseprelop(token.ToCharArray()[0]) || issepid((token.ToCharArray()[0])) || issep(token.ToCharArray()[0]))
                {
                    token = "separator";
                }
                for (int i = 0; i <= k; i++)
                {

                    if (token == transitiontable[0, i].Trim())
                    {
                        column = i;
                    }
                }
            }
            return column;
        }



        static void TransitionTableLex(string filepath, string transitiontablepath)
        {
            int row = 1;
            string[,] k = LoadTransitionTable(transitiontablepath);
            using (StreamReader sr = new StreamReader(filepath))
            {
                Console.Write("< ");
                char token;

                while (sr.Peek() >= 0)
                {
                    token = (char)sr.Read();
                    Console.Write(token);
                    int column = GetColumnNumber(k, token);
                    if (column == -1)
                    {
                        Console.WriteLine(" Lexical Error: Invalid Token");
                        break;
                    }
                    else if (k[row, 0] != "")
                    {
                        Console.WriteLine(" " + k[row, 0] + "  >");
                        Console.Write("< ");
                        row = 1;
                    }
                    else
                    {
                        if (k[row, column] == "")
                        {
                            Console.WriteLine(" Lexical Error: Invalid Token");
                            break;
                        }
                        else
                        {
                            row = Convert.ToInt32(k[row, column]) + 1;

                        }
                    }
                }
            }
        }



        static string FilterString(string str, List<char> charsToRemove)
        {
            foreach (char c in charsToRemove)
            {
                str = str.Replace(c.ToString(), String.Empty);
            }

            return str;
        }



        static string[,] LoadTransitionTable(string transitiontablepath)
        {
            List<char> c = new List<char>();
            c.Add('"');
            var lines = File.ReadAllLines(transitiontablepath);
            int m = lines.Length;
            int n = lines[0].Split(',').Length;
            string[,] tt = new string[m, n];
            for (int i = 0; i < m; i++)
            {
                var currentline = lines[i].Split(',');
                for (int j = 0; j < n; j++)
                {
                    tt[i, j] = FilterString(currentline[j], c);
                }
            }
            Console.WriteLine("Transition Table Loaded");
            return tt;

        }


        static void Main(string[] args)
        {
            string transitiontablepath = @"D:\1A Semesters\8th semester\CC\Assignment 3\TransitionTable.csv";

            string textFile = @"D:\1A Semesters\8th semester\CC\Assignment2\data.txt";
            TransitionTableLex(textFile, transitiontablepath);

        }

    }
}
