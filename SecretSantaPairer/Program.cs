using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SecretSantaPairer
{
    class Program
    {
        static void Main(string[] args)
        {
            Write(Pair(GetNames()));
            Console.ReadKey();
        }
        private static string[] GetNames()
        {
            Console.WriteLine("Welcome to the Secret Santa Pairer program!");
            Console.WriteLine("Please type in the name of each person in the exchange followed by a return. If there are no names, type \"done\"\n");
            List<string> people = new List<string>();
            string input = "";
            while(true)
            {
                input = Console.ReadLine();
                if(input.ToLower() != "done")
                    people.Add(input);
                else break;
            }
            // Add a blank line just for aesthetics
            Console.WriteLine();
            return people.ToArray();
        }
        private static string[] Pair(string[] people)
        {
            string[] output = new string[people.Length];
            List<string> santas = people.ToList();
            List<string> santees = people.ToList();
            Random rng = new Random();
            for(int i = 0; i < people.Length; i++)
            {
                string santa = santas[rng.Next(0, santas.Count)];
                santas.Remove(santa);
                string santee = "";
                string test;
                // Make sure a unique santee is generated
                while(santee == "")
                {
                    test = santees[rng.Next(0, santees.Count)];
                    if(santa != test)
                    {
                        santee = test;
                    }
                }
                santees.Remove(santee);
                if(i < people.Length - 1)
                    output[i] = string.Format("{0} is {1}'s santa!", santa, santee);
                else
                    output[i] = string.Format("{0} is {1}'s santa!", santa, santee);
            }
            Console.WriteLine("Pairs created!");
            return output;
        }
        private static void Write(string[] output)
        {
            string path = CreateOutputFile();
            Console.WriteLine("Output file created in the root directory of the repo at \"{0}\"!", path);
            File.WriteAllLines(path, output);
            Console.WriteLine("Pairs writen to output file! Check the \"output.txt\" file in the root directory to see them!");
        }

        private static string CreateOutputFile()
        {
            // Returns the directory of the repo
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            // If the output file exists, delete it and create it. If not, create it.
            if(File.Exists(Path.Combine(path, "output.txt")))
                File.Delete(Path.Combine(path, "output.txt"));
            return Path.Combine(path, "output.txt");
        }
    }
}
