using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace IOTextStream
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var ioClass = new IOClass();

            ioClass.ReadLineText();

            ioClass.ReadAllText();

            ioClass.ReadLineFifteen();

            ioClass.CountHamlet();

            ioClass.NumberCount();

            ioClass.OutTxet();

            ioClass.WriteAllText();

            ioClass.GetFileSize();
        }
    }

    class IOClass
    {
        // Output hamlet for text files
        public void ReadLineText()
        {
            // Place hamlet.txt in the same directory as the executable
            var filePath = @"hamlet.txt";
            if (File.Exists(filePath))
            {
                using (var reader = new StreamReader(filePath, Encoding.UTF8))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        Console.WriteLine(line);
                    }
                }
            }
            Console.WriteLine();
        }

        // Read a text file at a time -> Output
        public void ReadAllText()
        {
            var filePath = @"hamlet.txt";
            var lines = File.ReadAllLines(filePath, Encoding.UTF8);
            foreach (var line in lines)
                Console.WriteLine(line);
            Console.WriteLine();
        }

        // Extract the first 15 lines
        public void ReadLineFifteen()
        {
            var filePath = @"hamlet.txt";
            var lines = File.ReadLines(filePath, Encoding.UTF8).Take(15).ToArray();
            foreach (var line in lines)
                Console.WriteLine(line);
            Console.WriteLine();
        }

        // Count lines that contain "Hamlets"
        public void CountHamlet()
        {
            var filePath = @"hamlet.txt";
            var count = File.ReadLines(filePath, Encoding.UTF8).Count(s => s.Contains("Hamlet"));
            Console.WriteLine(count);
            Console.WriteLine();
        }

        // Add a line number
        public void NumberCount()
        {
            var filePath = @"hamlet.txt";
            var lines = File.ReadLines(filePath)
                            .Select((s, ix) => String.Format("{0,4}: {1}", ix + 1, s))
                            .ToArray();
            foreach (var line in lines)
                Console.WriteLine(line);
            Console.WriteLine();
        }

        // Output text to a file
        public void OutTxet()
        {
            var filePath = @"BlueBird.txt";
            using (var writer = new StreamWriter(filePath))
            {
                writer.WriteLine("Much to his surprise, the Fairy turned crimson with rage. ");
                writer.WriteLine("It was a hobby of hers to be like nobody, because she was a fairy and able to change her appearance, from one moment to the next, as she pleased. ");
                writer.WriteLine("That evening, she happened to be ugly and old and hump-backed; she had lost one of her eyes; and two lean wisps of grey hair hung over her shoulders.");
                writer.WriteLine("What do I look like? she asked Tyltyl. Am I pretty or ugly? Old or young?");
            }
        }

        // Output an array of characters to text
        public void WriteAllText()
        {
            var names = new List<string> {"Alabama", "Alaska", "Arizona", "Arkansas", "California", "Colorado", 
                                          "Connecticut", "Delaware", "Florida", "Georgia", "Hawaii", "Idaho", };
            var filePath = @"State.txt";
            // Output states with more than 7 characters
            File.WriteAllLines(filePath, names.Where(s => s.Length > 7));
        }

        // Get the file size
        public void GetFileSize()
        {
            // Get the size of hamlet.txt
            var fi1 = new FileInfo(@"hamlet.txt");
            long size1 = fi1.Length;
            Console.WriteLine(size1); 

            // Get the size of BlueBird.txt
            var fi2 = new FileInfo(@"BlueBird.txt");
            long size2 = fi2.Length;
            Console.WriteLine(size2); 

            // Get the size of State.txt
            var fi3 = new FileInfo(@"State.txt");
            long size3 = fi3.Length;
            Console.WriteLine(size3); 
        }
    }
}