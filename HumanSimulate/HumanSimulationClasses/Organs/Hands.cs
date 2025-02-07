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
            Growth_Coef = 0.05d;
        }

        public static string HandShake(Human target)
        {
            return "Shaked hands with" + target.GetName();
        }

        public override void Grow()
        {
            Size += Growth_Coef;
        }
    }
}
