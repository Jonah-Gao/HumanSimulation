using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanSimulation.HumanSimulationClasses.Diseases
{
    public class Ebola : Disease
    {
        public Ebola()
        {
            Random rnd = new();
            Health = 500d;
            CFR = rnd.Next(25, 90);
            IFR = rnd.Next(10, 70);
        }

        public override string ToString()
        {
            return "Ebola";
        }
    }
}
