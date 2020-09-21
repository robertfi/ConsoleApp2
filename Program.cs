using System;
using System.IO;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputFile = args[0];
            string outputDir = args.Length > 1 ? args[1] : Directory.GetCurrentDirectory();


            Console.WriteLine($"Bulk copying all files listed in {inputFile} to {outputDir}");

            using StreamReader sr = new StreamReader(File.OpenRead(inputFile));
            while (!sr.EndOfStream)
            {
                string currentLine = sr.ReadLine();
                string[] parts = currentLine.Split(',');

                string destName = Path.Combine(outputDir, parts[0]);
                Console.WriteLine($"Copying {parts[1]} to {destName}");
                File.Copy(parts[1],destName,true);
            }
        }
    }
}
