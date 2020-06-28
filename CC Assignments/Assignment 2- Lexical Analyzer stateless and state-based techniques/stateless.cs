using System;
using System.IO;

namespace StatelessLex
{
    class Program
    {
        static bool issep(char c)
        {

            if (c.ToString() == "\0" || c.ToString() == "\n" || isdigitoralphabet(c) || c.ToString() == "\r")
            {
                return true;
            }
            return false;
        }

        static void StateLessLex(string filepath)
        {
            using (StreamReader streamReader = new StreamReader(filepath))
            {
                char character;
                while (streamReader.Peek() >= 0)
                {
                    character = (char)streamReader.Read();
                    if (character == '<'&& streamReader.Peek() >= 0)
                    {
                        character = (char)streamReader.Read();
                        if (character == '>' && streamReader.Peek() >= 0)
                        {
                            character = (char)streamReader.Read();
                            if (issep(character))
                            {
                                Console.WriteLine("<> Token");
                            }
                            else
                            {
                                Console.WriteLine("Invalid Input");
                                break;
                            }
                        }
                        else if (character == '=' && streamReader.Peek() >= 0)
                        {
                            character = (char)streamReader.Read();
                            if (issep(character))
                            {
                                Console.WriteLine("<= Token");
                            }
                            else
                            {
                                Console.WriteLine("Invalid Input");
                                break;
                            }

                        }
                        else if (isseprelop(character))
                        {
                            Console.WriteLine("< Token");
                        }
                        else
                        {
                            Console.WriteLine("Invalid Input");
                            break;
                        }
                    }
                    else if (character == '>')
                    {
                        character = (char)streamReader.Read();
                        if (character == '=' && streamReader.Peek() >= 0)
                        {
                            character = (char)streamReader.Read();
                            if (issep(character))
                            {
                                Console.WriteLine(">= Token");
                            }
                            else
                            {
                                Console.WriteLine("Invalid Input");
                                break;
                            }

                        }
                        else if (isseprelop(character))
                        {
                            Console.WriteLine("> Token");
                        }
                        else
                        {
                            Console.WriteLine("Invalid Input");
                            break;
                        }
                    }
                    else if (character == '=')
                    {
                        character = (char)streamReader.Read();
                        if (character == '=' && streamReader.Peek() >= 0)
                        {
                            character = (char)streamReader.Read();
                            if (issep(character))
                            {
                                Console.WriteLine("== Token");
                            }
                            else
                            {
                                Console.WriteLine("Invalid Input");
                                break;
                            }

                        }
                        else if (isseprelop(character))
                        {
                            Console.WriteLine("= Token");
                        }
                        else
                        {
                            Console.WriteLine("Invalid Input");
                            break;
                        }
                    }
                    else if (character == ':' && streamReader.Peek() >= 0)
                    {
                        character = (char)streamReader.Read();
                        if (character == '=' && streamReader.Peek() >= 0)
                        {
                            character = (char)streamReader.Read();
                            if (issep(character))
                            {
                                Console.WriteLine("<= Token");
                            }
                            else
                            {
                                Console.WriteLine("Invalid Input");
                                break;
                            }

                        }
                        else
                        {
                            Console.WriteLine("Invalid Input");
                            break;
                        }

                    }
                    else if(issep(character))
                    {

                    }
                    else
                    {
                        Console.WriteLine("Invalid Input");
                        break;
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            string textFile = @"D:\input.txt";
            StateLessLex(textFile);
           
        }

    }
}
