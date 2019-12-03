using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretSantaPairer
{
    class Program
    {
        static void Main(string[] args)
        {
        }
        private static void Pair(string[] people)
        {
            List<string> santas = people.ToList();
            List<string> santees = people.ToList();
            Random rng = new Random();
            for(int i = 0; i < people.Length; i++)
            {
                string santa = santas[rng.Next(0, santas.Count)];
                santas.Remove(santa);
                string santee = "";
                string test;
                while(santee == "")
                {
                    test = santees[rng.Next(0, santees.Count)];
                    if(santa != test)
                    {
                        santee = test;
                    }
                }
                santees.Remove(santee);
                Console.WriteLine("{0} is {1}'s santa!", santa, santee);
            }
        }
    }
}
