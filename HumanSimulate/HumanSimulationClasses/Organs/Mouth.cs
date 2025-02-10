using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanSimulation.HumanSimulationClasses.Organs
{
    public class Mouth : Organ
    {
        public Mouth(double Variance)
        {
            Size = 3.5d + Variance;
            GrowthCoef = 0.05d;
        }

        internal static string Speak(Dictionary<string, string> Knowledge)
        {
            StringBuilder stringBuilder = new();
            foreach(KeyValuePair<string, string> element in Knowledge)
            {
                stringBuilder.Append($"{element.Key} <=> {element.Value}\n");
            }
            return stringBuilder.ToString();
        }

        internal static double Eat(double Calories)
        {
            return Calories * 0.9d;
        }

        internal override void Grow()
        {
            Size += GrowthCoef;
        }
    }
}
