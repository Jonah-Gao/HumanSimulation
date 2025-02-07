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
            Growth_Coef = 0.05d;
        }

        public void Growth()
        {
            Size += Growth_Coef;
        }

        public static string Speak(Dictionary<string, string> Knowledge)
        {
            StringBuilder stringBuilder = new();
            foreach(KeyValuePair<string, string> element in Knowledge)
            {
                stringBuilder.Append($"{element.Key} <=> {element.Value}\n");
            }
            return stringBuilder.ToString();
        }

        public static double Eat(double Calories)
        {
            return Calories * 0.9d;
        }

        public override void Grow()
        {
            Size += Growth_Coef;
        }
    }
}
