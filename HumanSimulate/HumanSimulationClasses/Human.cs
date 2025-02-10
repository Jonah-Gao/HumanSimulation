using HumanSimulation.HumanSimulationClasses.Diseases;
using HumanSimulation.HumanSimulationClasses.Organs;

namespace HumanSimulation.HumanSimulationClasses
{
    public abstract class Human
    {
        public Human(string firstname, string lastname, DateTime birthday, int seed)
        {
            Random rnd = new(seed);
            Firstname = firstname;
            Lastname = lastname;
            Birthday = birthday;
            Saturation = 100d;
            MetabolismRate = 1d;
            Health = 100d;
            Organs = new()
            {
                { "Brain", new Brain(rnd.Next(60, 161), rnd.NextDouble() * 2 - 1) },
                { "Ears", new Ears((rnd.Next(-5, 6)) / 5d) },
                { "Eyes", new Eyes((rnd.Next(-10, 11)) / 10d) },
                { "Hands", new Hands((rnd.Next(-5, 6)) / 10d) },
                { "Mouth", new Mouth((rnd.Next(-7, 8)) / 10d) }
            };
            Diseases = [];
        }

        public string Firstname { get; private set; }
        public string Lastname { get; private set; }
        public DateTime Birthday { get; private set; }
        public double Health { get; protected set; }
        public double Height { get; protected set; }
        public double Weight { get; protected set; }
        public double Saturation { get; protected set; }
        public double Age { get; protected set; }
        public double MetabolismRate { get; protected set; }
        public double Immunity { get; protected set; }
        public bool Alive { get; protected set; } = true;
        protected List<Disease> Diseases { get; set; }
        protected Dictionary<string, Organ> Organs { get; set; }

        private double UpdateAge()
        {
            DateTime today = DateTime.Now;
            int age = today.Year - Birthday.Year;
            if (Birthday.Date > today.AddYears(-age))
            {
                age--;
            }
            return age;
        }

        public string GetName()
        {
            return Firstname + ' ' + Lastname;
        }

        public double GetIQ()
        {
            return ((Brain)Organs["Brain"]).IQ;
        }

        public string GetDiseases()
        {
            return Diseases.Count != 0 ? string.Join(", ", Diseases) : "None";
        }

        public string Think(string input)
        {
            Saturation -= MetabolismRate;
            return ((Brain)Organs["Brain"]).Compute(input);
        }

        public void Eat(double Calories)
        {
            Saturation += Math.Round(Calories / 1200d, 1);
        }

        public void Speak()
        {
            Console.WriteLine(Mouth.Speak(((Brain)Organs["Brain"]).Knowledge));
        }

        public void Hear(string sound)
        {
            string[] contents = ((Ears)Organs["Ears"]).Hear(sound);
            for (int i = 0; i < contents.Length; i += 2)
            {
                ((Brain)Organs["Brain"]).Learn(contents[i], contents[i + 1]);
            }
        }

        public void Read(string text)
        {
            string[] contents = ((Eyes)Organs["Eyes"]).Read(text);
            for (int i = 0; i < contents.Length; i += 2)
            {
                ((Brain)Organs["Brain"]).Learn(contents[i], contents[i + 1]);
            }
        }

        public static void HandShake(Human person)
        {
            Hands.HandShake(person);
        }

        public void Infect(Disease disease)
        {
            Random rnd = new();
            if (rnd.Next(0, 100) > Immunity - disease.IFR)
            {
                Diseases.Add(disease);
                Console.WriteLine("Successed");
            }
            else
            {
                Console.WriteLine("Failed");
            }
        }

        protected void ImmuneSystem()
        {
            for (int i = 0; i < Diseases.Count; i++)
            {
                Diseases[i].Damage(Immunity / 10d);
                if (Diseases[i].Health <= 0)
                {
                    Diseases.RemoveAt(i);
                }
            }
        }

        protected void UpdateImmunity()
        {
            Immunity = Math.Round(Math.Sin(Math.PI / 16d + Age / 110d * Math.PI / 180d) * 100, 2);
        }

        protected abstract void Grow();

        protected abstract void UpdateMetabolismRate();

        public void Metabolism()
        {
            if (Health > 0)
            {
                Alive = true;
                UpdateMetabolismRate();
                UpdateImmunity();
                ImmuneSystem();
                Grow();
                Age = UpdateAge();
                for (int i = 0; i < Diseases.Count; i++)
                {
                    Health = Diseases[i].Pathogenesis(Health);
                }
            }
            if (Health <= 0 && Alive)
            {
                Alive = false;
                Console.WriteLine($"\n{GetName()} ({Birthday.Year} - {DateTime.Now.Year})\nAge {Age} {(Age == 1 ? "year" : "years")}");
            }
        }

        public void Damage(double amount)
        {
            Health -= amount;
            foreach (var organ in Organs)
            {
                organ.Value.Health -= amount;
            }
        }
    }
}
