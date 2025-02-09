using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanSimulation.HumanSimulationClasses.Organs
{
    public abstract class Organ
    {
        public double Health { get; set; } = 100d;
        public double Size { get; protected set; }
        public double Growth_Coef { get; protected set; } = 0;

        public Human Human
        {
            get => default;
            set
            {
            }
        }

        public abstract void Grow();
    }
}
