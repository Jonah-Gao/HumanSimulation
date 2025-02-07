using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanSimulation.HumanSimulationClasses.Diseases
{
    public class Flu : Disease
    {
        public Flu()
        {
            Random rnd = new();
            CFR = 0.1d;
            IFR = rnd.Next(5, 20);
        }

        public override string ToString()
        {
            return "Flu";
        }
    }
}
