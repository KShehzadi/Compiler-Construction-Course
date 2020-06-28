using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanicModeErrorRecovery
{
    class Program
    {

        static void Main(string[] args)
        {
            start();
        }
        static void start()
        {
            string continueornot = "y";
            while (continueornot == "y" || continueornot == "Y")
            {
                string input;
                Console.WriteLine("\n" + "\n" + "" +
                    "***********************" +
                    " Start Panic Mode Error Recovery " +
                    "***********************" + "\n");
                Console.Write("Input: ");
                input = Console.ReadLine();
                Console.WriteLine("Output:");
                startchecking(input);
                Console.WriteLine("Enter 'y' or 'Y' to continue and any other key to exit.");
                continueornot = Console.ReadLine();
            }
            

        }

        static void startchecking(string input)
        {
            // character array of input to process every character
            char[] inputstringarray = input.ToArray();

            // spare string to store the current processing string
            string flagstring = null;

            int current = 0;
            // loop to check all the characters in array
            while (current < inputstringarray.Length)
            {
                // checking relational operators such as >,>=,<,<=,<>
                if (checkRelationalOperator(ref inputstringarray, ref flagstring, ref current))
                {

                }

                // checking identifier
                else if (checkIdentifier(ref inputstringarray, ref flagstring, ref current))
                {

                }

                // checking number/digit
                else if (checkNumber(ref inputstringarray, ref flagstring, ref current))
                {

                }


                // checking assignment operator
                else if (checkAssignmentOperator(ref inputstringarray, ref flagstring, ref current))
                {

                }

                // checking DMAS Operator such as +,-,/,*
                else if(checkDMASOperators(ref inputstringarray, ref flagstring, ref current))
                {

                }
                else
                {
                    flagstring += inputstringarray[current];
                    printErrrorMessage(ref flagstring);

                }
                // incrementing the loop veriable
                current++;
            }
        }
        static bool checkRelationalOperator(ref char[] inputstringarray, ref string flagstring, ref int i)
        {
            if (inputstringarray[i] == '<')
            {
                flagstring = flagstring + inputstringarray[i];
                if (i + 1 != inputstringarray.Length)
                {
                    if (inputstringarray[i] == '=')
                    {
                        flagstring = flagstring + inputstringarray[i];
                        Console.Write("<" + flagstring + " Less than Equal" + ">" + "\n");
                        flagstring = null;
                        i++;
                        return true;
                    }
                    else if (inputstringarray[i] == '>')
                    {
                        flagstring = flagstring + inputstringarray[i];
                        Console.Write("<" + flagstring + "Not Equal" + ">" + "\n");
                        flagstring = null;
                        i++;
                        return true;
                    }
                    else
                    {
                        Console.Write("<" + flagstring + " Less than" + ">" + "\n");
                        flagstring = null;
                        return true;
                    }
                }
                else
                {
                    Console.Write("<" + flagstring + " Less than" + ">" + "\n");
                    flagstring = null;
                    return true;
                }
            }
            else if (inputstringarray[i] == '=')
            {
                flagstring = flagstring + inputstringarray[i];
                Console.Write("<" + flagstring + " Equal" + ">" + "\n");
                flagstring = null;
                return true;
            }
            else if (inputstringarray[i] == '>')
            {
                flagstring = flagstring + inputstringarray[i];
                if (i + 1 != inputstringarray.Length)
                {
                    if (inputstringarray[i + 1] == '=')
                    {
                        flagstring = flagstring + inputstringarray[i + 1];
                        Console.Write("<" + flagstring + " Greater than Equal" + ">" + "\n");
                        flagstring = null;
                        i++;
                        return true;
                    }
                    else
                    {
                        Console.Write("<" + flagstring + " Greater than" + ">" + "\n");
                        flagstring = null;
                        return true;
                    }
                }
                else
                {
                    Console.Write("<" + flagstring + " Greater than" + ">" + "\n");
                    flagstring = null;
                    return true;
                }
            }
            return false;
        }
        static bool checkIdentifier(ref char[] inputstringarray, ref string flagstring, ref int i)
        {
            if (char.IsLetter(inputstringarray[i]))
            {
                flagstring = flagstring + inputstringarray[i];
                int j = i + 1;
                if (inputstringarray.Length != j)
                {
                    while(j < inputstringarray.Length)
                    {
                        if (!char.IsDigit(inputstringarray[j]) && !char.IsLetter(inputstringarray[j]))
                        {
                            break;
                          
                        }
                        else
                        {
                            flagstring = flagstring + inputstringarray[j];
                        }
                        j++;
                    }
                }
                i = j - 1;
                Console.Write("<" + flagstring + " Identifier" + ">" + "\n");

                flagstring = null;
                return true;
            }
            return false;
        }
        static bool checkNumber(ref char[] inputstringarray, ref string flagstring, ref int i)
        {
            if (char.IsDigit(inputstringarray[i]))
            {
                flagstring = flagstring + inputstringarray[i];
                bool isnumber = true;
                int j = i + 1;
                if (j != inputstringarray.Length)
                {
                    while (j < inputstringarray.Length)
                    {
                        if (char.IsDigit(inputstringarray[j]))
                        {
                            flagstring = flagstring + inputstringarray[j];

                        }
                        else if (inputstringarray[j] == '.')
                        {
                            if (j + 1 != inputstringarray.Length)
                            {
                                if (char.IsDigit(inputstringarray[j + 1]))
                                {
                                    flagstring = flagstring + inputstringarray[j];

                                }
                                else
                                {
                                    isnumber = false;
                                    break;
                                }
                            }
                            else
                            {
                                isnumber = false;
                                break;
                            }
                        }
                        else if (inputstringarray[j] == 'E')
                        {
                            flagstring = flagstring + inputstringarray[j];
                            if (j + 1 != inputstringarray.Length)
                            {
                                if (inputstringarray[j + 1] == '+' || inputstringarray[j + 1] == '-')
                                {
                                    flagstring = flagstring + inputstringarray[j + 1];
                                    if (char.IsDigit(inputstringarray[j + 2]))
                                    {
                                        flagstring = flagstring + inputstringarray[j + 2];
                                        int k = j + 3;
                                        for (; k < inputstringarray.Length; ++k)
                                        {
                                            if (char.IsDigit(inputstringarray[k]))
                                            {
                                                flagstring = flagstring + inputstringarray[k];
                                            }
                                            else break;
                                        }
                                        j = k - 1;
                                    }
                                    else
                                    {
                                        isnumber = false;

                                        printErrrorMessage(ref flagstring);
                                       
                                    }
                                }
                                else if (char.IsDigit(inputstringarray[j + 1]))
                                {
                                    flagstring = flagstring + inputstringarray[j + 1];
                                    int k = j + 2;
                                    for (; k < inputstringarray.Length; ++k)
                                    {
                                        if (char.IsDigit(inputstringarray[k]))
                                        {
                                            flagstring = flagstring + inputstringarray[k];
                                            continue;
                                        }
                                        else
                                            break;
                                    }
                                    j = k - 1;
                                }
                                else
                                {
                                    isnumber = false;
                                    printErrrorMessage(ref flagstring);
                                   
                                }
                            }
                            else
                            {
                                isnumber = false;
                                printErrrorMessage(ref flagstring);
                                j++;
                                
                            }

                        }
                        else
                        {
                            isnumber = true;
                            break;
                        }
                        j++;
                    }
                }
                i = j - 1;
                if (isnumber)
                {
                    Console.Write("<" + flagstring + " Number" + ">" + "\n");
                    flagstring = null;
                    return isnumber;
                }
            }

            return false;
        }
        static bool checkspace(ref char[] inputstringarray, ref string flagstring, ref int i)
        {
            if (char.IsWhiteSpace(inputstringarray[i]))
            {
                Console.Write("<" + "Space" + ">" + "\n");
                flagstring = null;
                return true;
            }
            return false;

        }
        static bool checkAssignmentOperator(ref char[] inputstringarray, ref string flagstring, ref int i)
        {
            if (inputstringarray[i] == ':')
            {
                flagstring = flagstring + inputstringarray[i];
                int j = i + 1;
                if (j != inputstringarray.Length)
                {
                    flagstring = flagstring + inputstringarray[j];
                    if (inputstringarray[j] == '=')
                    {
                        flagstring = flagstring + inputstringarray[j];
                        Console.Write("<" + flagstring + " Assignment Op" + ">" + "\n");
                        flagstring = null;
                        i = j;
                        return true;
                    }
                    else
                    {

                        printErrrorMessage(ref flagstring);
                        return false;
                    }
                }
                else
                {

                    printErrrorMessage(ref flagstring);
                    return false;
                }
            }
            return false;

        }
        static bool checkComment(ref char[] inputstringarray, ref string flagstring, ref int i)
        {
            if (inputstringarray[i] == '{')
            {
                flagstring = flagstring + inputstringarray[i];
                int j = i + 1;
                if (j != inputstringarray.Length)
                {
                    if (inputstringarray[j] == '}')
                    {
                        flagstring = flagstring + inputstringarray[j];
                        Console.Write("<" + flagstring + " Comment" + ">" + "\n");
                        flagstring = null;
                        i = j;
                        return true;
                    }
                    else
                    {

                        printErrrorMessage(ref flagstring);
                        return false;
                    }
                }
                else
                {

                    printErrrorMessage(ref flagstring);
                    return false;
                }
            }
            return false;

        }
        static bool checkDMASOperators(ref char[] inputstringarray, ref string flagstring, ref int i)
        {
            //add operator
            if (inputstringarray[i] == '+')
            {
                flagstring = flagstring + inputstringarray[i];
                Console.Write("<" + flagstring + " Add Operator" + ">" + "\n");
                flagstring = null;
                return true;
            }
            //subtract operator
            else if (inputstringarray[i] == '-')
            {
                flagstring = flagstring + inputstringarray[i];
                Console.Write("<" + flagstring + " Subtract Operator" + ">" + "\n");
                flagstring = null;
                return true;
            }
            //multiplication operator
            else if (inputstringarray[i] == '*')
            {
                flagstring = flagstring + inputstringarray[i];
                Console.Write("<" + flagstring + " Multiplication Operator" + ">" + "\n");
                flagstring = null;
                return true;
            }
            //division operator
            else if (inputstringarray[i] == '/')
            {
                flagstring = flagstring + inputstringarray[i];
                Console.Write("<" + flagstring + " Division Operator" + ">" + "\n");
                flagstring = null;
                return true;
            }
            return false;
        }
        static void printErrrorMessage(ref string s)
        {
            Console.Write("<" + s + " Error!" + ">" + "\n");
            s = null;

        }

    }   
}

