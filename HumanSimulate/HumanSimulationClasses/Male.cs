using HumanSimulation.HumanSimulationClasses.Organs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanSimulation.HumanSimulationClasses
{
    public class Male : Human
    {
        public Male(string firstname, string lastname, DateTime birthday, int seed) : base(firstname, lastname, birthday, seed)
        {
            Random rnd = new(seed);
            Weight = Math.Round(3.3d + rnd.Next(-10, 10) / 10d, 2);
            Height = 49.5d + rnd.Next(-8, 8);
        }

        protected override void Grow()
        {
            if (Saturation > 0)
            {
                Saturation -= MetabolismRate;
                Height += MetabolismRate * 0.011d;
                Weight += MetabolismRate * 0.011d;
                foreach (var organ in Organs)
                {
                    organ.Value.Grow();
                    Saturation -= organ.Value.GrowthCoef;
                }
                if (Health != 0)
                {
                    Saturation -= 0.5d;
                    Health = Health + 0.5d > 100 ? 100 : Health + 0.5d;
                }
            }
            if (Saturation <= 0)
            {
                Health -= MetabolismRate;
            }            
        }

        protected override void UpdateMetabolismRate() 
        {
            MetabolismRate = Math.Round(Math.Cos(Age / 110 * Math.PI / 180), 4);
        }
    }
}
