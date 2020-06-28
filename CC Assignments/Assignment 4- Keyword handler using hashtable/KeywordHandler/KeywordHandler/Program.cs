using System;
using System.Collections;

namespace KeywordHandler
{
    class Program
    {
        // Keyword Recoginition using hashtable
        // Submitted by: Komal Shehzadi (2016-CS-178)
        // shared resources
        // hashtable used throughout the program
        static private Hashtable table = new Hashtable();
        // main method
        static void Main(string[] args)
        {
            // function to start the execution
            start();
        }
        // function to check the input string in hashtable and returns true with keynumber in case of keyword
        // otherwise false
        static bool CheckKeyword(string str, ref string keynumber)
        {
            bool iskeyword = false;
            // Get a collection of the keys.
            ICollection keysintable = table.Keys;

            foreach (string k in keysintable)
            {
                if (table[k].Equals(str))
                {
                    iskeyword = true;
                    keynumber = k;
                    break;
                }
            }
            return iskeyword;
        }

        // start function to take input and start the process
        static void start()
        {
            FillTable();
            string continueornot = "y";
            while (continueornot == "y" || continueornot == "Y")
            {

                string str;
                string keynumber = "";
                Console.WriteLine("*****************************************************");
                Console.WriteLine("Keyword Recogintion Using HashTable");
                Console.Write("Enter input string: ");
                str = Console.ReadLine();

                if (CheckKeyword(str, ref keynumber))
                {

                    Console.WriteLine("<" + keynumber + ", " + table[keynumber] + ">");
                    Console.WriteLine("It is a Keyword!");
                    Console.WriteLine("********************************************");
                }
                else
                {
                    Console.WriteLine("It is an Identifier or Operator or Symbol!");
                    Console.WriteLine("*********************************************");
                }
                Console.WriteLine("Press 'y' or 'Y' to continue and any other key to exit.");
                continueornot = Console.ReadLine();
            }
        }
        // function to fill hashtable
        static void FillTable()
        {
            table.Add("01", "while");
            table.Add("02", "nameof");
            table.Add("03", "join");
            table.Add("04", "global");
            table.Add("05", "group");
            table.Add("06", "value");
            table.Add("07", "var");
            table.Add("08", "set");
            table.Add("09", "decimal");
            table.Add("10", "default");
            table.Add("11", "delegate");
            table.Add("12", "do");
            table.Add("13", "double");
            table.Add("14", "else");
            table.Add("15", "enum");
            table.Add("16", "event");
            table.Add("17", "explicit");
            table.Add("18", "abstract");
            table.Add("19", "as");
            table.Add("20", "base");
            table.Add("21", "bool");
            table.Add("22", "break");
            table.Add("23", "byte");
            table.Add("24", "case");
            table.Add("25", "catch");
            table.Add("26", "char");
            table.Add("27", "checked");
            table.Add("28", "class");
            table.Add("29", "const");
            table.Add("30", "continue");
            table.Add("31", "extern");
            table.Add("32", "false");
            table.Add("33", "finally");
            table.Add("34", "finally");
            table.Add("35", "float");
            table.Add("36", "for");
            table.Add("37", "foreach");
            table.Add("38", "out");
            table.Add("39", "is");
            table.Add("40", "lock");
            table.Add("41", "long");
            table.Add("42", "namespace");
            table.Add("43", "new");
            table.Add("44", "null");
            table.Add("45", "object");
            table.Add("46", "operator");
            table.Add("47", "override");
            table.Add("48", "params");
            table.Add("49", "private");
            table.Add("50", "protected");
            table.Add("51", "public");
            table.Add("52", "goto");
            table.Add("53", "if");
            table.Add("54", "implicit");
            table.Add("55", "in");
            table.Add("56", "int");
            table.Add("57", "interface");
            table.Add("58", "internal");
            table.Add("59", "readonly");
            table.Add("60", "ref");
            table.Add("61", "return");
            table.Add("62", "sbyte");
            table.Add("63", "sealed");
            table.Add("64", "short");
            table.Add("65", "throw");
            table.Add("66", "true");
            table.Add("67", "try");
            table.Add("68", "typeof");
            table.Add("69", "uint");
            table.Add("70", "ulong");
            table.Add("71", "unchecked");
            table.Add("72", "unsafe");
            table.Add("73", "ushort");
            table.Add("74", "using");
            table.Add("75", "sizeof");
            table.Add("76", "stackalloc");
            table.Add("77", "static");
            table.Add("78", "string");
            table.Add("79", "struct");
            table.Add("80", "switch");
            table.Add("81", "this");
            table.Add("82", "virtual");
            table.Add("83", "void");
            table.Add("84", "volatile");

        }
    }
}
