using System;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CCAssignment
{
    class Program
    {
        static int fileposition = 0;
        static int readcount=0;
        static int secondreadcount = 0;
        static bool endofstream = false;
        static void Display(string[] buffer)
        {
            for(int i = 0; i < secondreadcount-1; i++)
            {
                Console.WriteLine(buffer[buffer.Count()-1] + ":"+buffer[i]);


            }
            Thread.Sleep(2000);

        }
        static void FillBuffer(string filepath, string[] buffer, int buffersize)
        {
            try
            {
                FileStream fileStream = new FileStream(filepath, FileMode.Open, FileAccess.Read);
                StreamReader streamreader = new StreamReader(fileStream, Encoding.UTF8);
                int i = 0;
                while(i < fileposition)
                {
                    streamreader.ReadLine();
                    i++;
                }
                i = 0;
                string line;
                while (!streamreader.EndOfStream && i < buffer.Count()-1 && readcount <= buffersize)
                {
                    Console.WriteLine("Reading in: " + buffer[buffer.Count() - 1]);
                    fileposition++;
                    line = streamreader.ReadLine();
                    buffer[i] = line;
                    i++;
                    readcount++;
                  
                }
                if(streamreader.EndOfStream)
                {
                    endofstream = true;
                }
                secondreadcount = readcount;
                readcount = 0;
                
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error in Reading");
            }
           
        }
        
        static void Main(string[] args)
        {
            int buffersize = 4000;
            string[] prevbuffer;
            string[] nextbuffer;
            string[] buffer1 = new string[buffersize+1];
            string[] buffer2 = new string[buffersize+1];
            buffer1[buffersize] = "Buffer 1";
            buffer2[buffersize] = "Buffer 2";
            string filepath = @"D:\\1A Semesters\\8th semester\\CC\\Assignment 1\\datafile3.txt";
            prevbuffer = buffer1;
            nextbuffer = buffer2;
           
            Thread thr2 = new Thread(()=>FillBuffer(filepath, prevbuffer, buffersize));
            thr2.Start();

            Thread thr1 = new Thread(() => Display(prevbuffer));
            while (true)
            {
                if (thr2.IsAlive)
                {

                }
                else
                {
                    
                    thr2 = new Thread(() => FillBuffer(filepath, nextbuffer, buffersize));
                    Console.WriteLine("**********************************************************************************************");
                    Console.WriteLine("                                      MULTITHREADING STARTED                                  ");
                    Console.WriteLine("**********************************************************************************************");
                    Console.WriteLine("");
                    Thread.Sleep(2000);

                    thr1.Start();
                    thr2.Start();
                    break;
                }
            }
            while (!endofstream)
            {
                if (thr1.IsAlive == false)
                {
                    if (thr2.IsAlive == false)
                    {

                        Console.WriteLine("**********************************************************************************************");
                        Console.WriteLine("                                 Buffer Swap !!!                                               ");
                        Console.WriteLine("**********************************************************************************************");
                        Console.WriteLine("");
                        Thread.Sleep(2000);
                     
                        if (prevbuffer[prevbuffer.Count() - 1] == "Buffer 1")
                        {
                            prevbuffer = buffer2;
                            nextbuffer = buffer1;
                           
                            thr1 = new Thread(() => Display(prevbuffer));
                            thr2 = new Thread(() => FillBuffer(filepath, nextbuffer, buffersize));
                            thr1.Start();
                            thr2.Start();
                        }
                        else
                        {
                            prevbuffer = buffer1;
                            nextbuffer = buffer2;
                            thr1 = new Thread(() => Display(prevbuffer));
                            thr2 = new Thread(() => FillBuffer(filepath, nextbuffer, buffersize));
                            thr1.Start();
                            thr2.Start();
                        }
                    }
                }
            }
        }
    }
}
