using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HumanSimulation.HumanSimulationClasses.Organs
{
    public class Ears : Organ
    {
        public Ears(double Variance)
        {
            Growth_Coef = 0.01d;
            Size = 4 + Variance;
        }

        public static string ShuffleString(string input)
        {
            Random rand = new();
            char[] array = input.ToCharArray();
            int n = array.Length;

            for (int i = n - 1; i > 0; i--)
            {
                int j = rand.Next(0, i + 1);
                (array[j], array[i]) = (array[i], array[j]);
            }

            return new(array);
        }

        public string[] Hear(string input)
        {
            Random rand = new();
            string[] contents = input.Split(" <=> ");
            for (int i = 0; i < contents.Length; i++)
            {
                if (rand.Next(0, 100) > Health)
                {
                    contents[i] = ShuffleString(contents[i]);
                }
            }
            return contents;
        }

        public override void Grow()
        {
            Size += Growth_Coef;
        }
    }
}
