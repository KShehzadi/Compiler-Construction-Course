using System;
using System.IO;

namespace StatefullLex
{
    class Program
    {

        
        static bool issepid(char c)
        {
            if (c.ToString() == " " || c.ToString() == "\n" || c == '<' || c == '>' || c == '=' || c == ':' || c == ';' || c.ToString() == "\r")
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
        static void StateFullLex(string filepath)
        {
            int state = 0;
            using (StreamReader sr = new StreamReader(filepath))
            {
                char token;
                while (sr.Peek() >= 0)
                {
                    token = (char)sr.Read();
                    Console.WriteLine(token);
                    switch (state)
                    {
                        case 0:
                            if (token == '<') state = 1;
                            else if (token == '>') state = 7;
                            else if (token == '=') state = 11;
                            else if (token == ':') state = 13;
                            else if (isalphabet(token)) state = 16;
                            else state = 100;
                            break;
                        case 1:
                            if (token == '>') state = 2;
                            else if (token == '=') state = 4;
                            else if (isseprelop(token)) state = 6;
                            else state = 100;
                            break;
                        case 7:
                            if (token == '=') state = 8;
                            else if (isseprelop(token)) state = 10;
                            else state = 100;
                            break;
                        case 11:
                            if (token == '=') state = 18;
                            else if (isseprelop(token)) state = 12;
                            else state = 100;
                            break;
                        case 13:
                            if (token == '=') state = 14;
                            else state = 100;
                            break;
                        case 16:
                            if (isdigitoralphabet(token)) state = 16;
                            else if (issepid(token)) state = 17;
                            else state = 100;
                            break;
                        case 2:
                            if (isseprelop(token)) state = 3;
                            else state = 100;
                            break;
                        case 4:
                            if (isseprelop(token)) state = 5;
                            else state = 100;
                            break;
                        case 6:
                            state = 0;
                            Console.WriteLine("Less than Operator <");
                            break;
                        case 3:
                            state = 0;
                            Console.WriteLine("Not Equal Operator <>");
                            break;
                        case 5:
                            state = 0;
                            Console.WriteLine("Less than or Equal Operator <=");
                            break;
                        case 8:
                            if (isseprelop(token)) state = 9;
                            else state = 100;
                            break;
                        case 10:
                            state = 0;
                            Console.WriteLine("Greater than Operator >");
                            break;
                        case 9:
                            state = 0;
                            Console.WriteLine("Greater than or Equal Operator >=");
                            break;
                        case 18:
                            if (isseprelop(token)) state = 19;
                            else state = 100;
                            break;
                        case 12:
                            state = 0;
                            Console.WriteLine("Assignment Operator =");
                            break;
                        case 19:
                            state = 0;
                            Console.WriteLine("Comparison Operator ==");
                            break;
                        case 14:
                            if (isseprelop(token)) state = 15;
                            else state = 100;
                            break;
                        case 15:
                            state = 0;
                            Console.WriteLine("Assignment Operator :=");
                            break;
                        case 17:
                            state = 0;
                            Console.WriteLine("Identifier Token");
                            break;
                        default:
                            state = 0;
                            Console.WriteLine("Invalid Token Detected");
                            break;
                    }
                    if (state == 100)
                    {
                        Console.WriteLine("Invalid Token Detected");
                        break;
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            string textFile = @"D:\1A Semesters\8th semester\CC\Assignment2\data.txt";
            StateFullLex(textFile);
            

        }

    }
}
