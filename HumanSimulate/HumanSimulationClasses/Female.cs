using HumanSimulation.HumanSimulationClasses.Organs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanSimulation.HumanSimulationClasses
{
    public class Female : Human
    {
        public Female(string firstname, string lastname, DateTime birthday, int seed) : base(firstname, lastname, birthday, seed)
        {
            Random rnd = new(seed);
            Weight = Math.Round(3.2d + rnd.Next(-8, 8) / 10d, 2);
            Height = 49.5d + rnd.Next(-6, 6);
        }

        protected override void Grow()
        {
            if (Saturation > 0)
            {
                Saturation -= MetabolismRate * 0.1d;
                Height += MetabolismRate * 0.01d;
                Weight += MetabolismRate * 0.01d;
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
            MetabolismRate = Math.Round(Math.Cos(Age / 110d * Math.PI / 180d), 4);
        }
    }
}
