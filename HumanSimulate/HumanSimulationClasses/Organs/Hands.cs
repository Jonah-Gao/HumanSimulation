using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanSimulation.HumanSimulationClasses.Organs
{
    public class Hands : Organ
    {
        public Hands(double Variance)
        {
            Size = 7.5d + Variance;
            GrowthCoef = 0.05d;
        }

        internal static string HandShake(Human person)
        {
            return "Shaked hands with" + person.GetName();
        }

        internal override void Grow()
        {
            Size += GrowthCoef;
        }
    }
}
