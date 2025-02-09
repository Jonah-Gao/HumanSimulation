using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanSimulation.HumanSimulationClasses.Diseases
{
    public abstract class Disease
    {
        public Disease()
        {
            Health = 100d;
        }

        public double Health { get; protected set; }
        public double CFR { get; protected set; }
        public double IFR { get; protected set; }

        public Human Human
        {
            get => default;
            set
            {
            }
        }

        public double Pathogenesis(double Health)
        {
            return Health - CFR;
        }

        public void Damage(double damage)
        {
            Health -= damage;
        }
    }
}
