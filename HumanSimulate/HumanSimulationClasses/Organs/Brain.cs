using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanSimulation.HumanSimulationClasses.Organs
{
    public class Brain : Organ
    {
        public Brain(int _IQ, double Variance)
        {
            Size = 10d + Variance;
            Growth_Coef = 0.6d;
            IQ = _IQ;
        }

        public double IQ { get; private set; }
        public Dictionary<string, string> Knowledge { get; private set; } = [];



        public string Compute(string input)
        {
            // Implementation here
            Random rnd = new();
            if (rnd.Next(0, (int)IQ + 10) <= IQ)
            {
                return $"{input} = {input}";
            }
            return $"{input} ≠ {input}";
        }

        public void Learn(string name, string description)
        {
            Knowledge[name] = description;
        }

        public override void Grow()
        {
            IQ += Growth_Coef / 10d;
            Size += Growth_Coef / 10d;
        }
    }
}