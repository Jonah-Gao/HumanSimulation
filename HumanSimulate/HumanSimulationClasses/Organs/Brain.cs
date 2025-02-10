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
            GrowthCoef = 0.6d;
            IQ = _IQ;
        }

        internal double IQ { get; private set; }
        internal Dictionary<string, string> Knowledge { get; private set; } = [];



        internal string Compute(string input)
        {
            // Implementation here
            Random rnd = new();
            if (rnd.Next(0, (int)Math.Pow(2, IQ/10d) + 100) <= (int)Math.Pow(2, IQ / 10d))
            {
                return $"{input} = {input}";
            }
            return $"{input} ≠ {input}";
        }

        internal void Learn(string name, string description)
        {
            Knowledge[name] = description;
        }

        internal override void Grow()
        {
            IQ += GrowthCoef / 10d;
            Size += GrowthCoef / 10d;
        }
    }
}