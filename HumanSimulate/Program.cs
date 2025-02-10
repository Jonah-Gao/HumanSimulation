using HumanSimulation.HumanSimulationClasses;
using HumanSimulation.HumanSimulationClasses.Diseases;
using static System.Math;

namespace HumanSimulation
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Male Person = new("Andrew", "Harrison", DateTime.Now, 14);
            Task.Run(() => Human(Person));
            string input = string.Empty;
            Console.WriteLine("Commands:\n-Status\n-Hear\n-Look\n-Speak\n-Eat\n-Think\n-Infect\n-Damage(Dev)");
            while (!input.Equals("Exit", StringComparison.CurrentCultureIgnoreCase))
            {
                input = Console.ReadLine() ?? string.Empty;
                switch (input.ToUpper())
                {
                    case "STATUS":
                        Console.WriteLine($"Name:\t\t{Person.GetName()}\nBirthday:\t{Person.Birthday}\nHealth:\t\t{Round(Person.Health, 2)}%\nIQ:\t\t{Round(Person.GetIQ(), 2)}\nHeight:\t\t{Round(Person.Height, 2)}cm\nWeight:\t\t{Round(Person.Weight, 2)}kg\nAge:\t\t{Person.Age}\nSaturation:\t{Round(Person.Saturation, 2)}%\nMetabolismRate:\t{Round(Person.MetabolismRate, 2)}\nImmunity:\t{Person.Immunity}%\nDisease:\t{Person.GetDiseases()}\nAlive:\t\t{Person.Alive}");
                        break;
                    case "HEAR" when Person.Alive:
                        Console.Write("Sound: ");
                        string sound = Console.ReadLine() ?? string.Empty;
                        Person.Hear(sound);
                        break;
                    case "LOOK" when Person.Alive:
                        Console.Write("Text: ");
                        string text = Console.ReadLine() ?? string.Empty;
                        Person.Read(text);
                        break;
                    case "SPEAK" when Person.Alive:
                        Person.Speak();
                        break;
                    case "EAT" when Person.Alive:
                        Console.Write("Calories: ");
                        double calories = double.Parse(Console.ReadLine() ?? string.Empty);
                        Person.Eat(calories);
                        break;
                    case "THINK" when Person.Alive:
                        Console.Write("Question: ");
                        string question = Console.ReadLine() ?? string.Empty;
                        Console.WriteLine(Person.Think(question));
                        break;
                    case "DAMAGE":
                        Console.Write("Amount: ");
                        double amount = double.Parse(Console.ReadLine() ?? string.Empty);
                        Person.Damage(amount);
                        break;
                    case "INFECT" when Person.Alive:
                        Console.WriteLine("1 - Flu\n2 - Ebola");
                        string disease = Console.ReadLine() ?? string.Empty;
                        switch (disease)
                        {
                            case "1":
                                Person.Infect(new Flu());
                                break;
                            case "2":
                                Person.Infect(new Ebola());
                                break;
                        }
                        break;
                    case "HELP":
                        Console.WriteLine("Commands:\n-Status\n-Hear\n-Look\n-Speak\n-Eat\n-Think\n-Infect\n-Damage(Dev)");
                        break;
                }
            }

        }

        static async Task Human(Human Body)
        {
            while (true)
            {
                Body.Metabolism();
                await Task.Delay(10000);
            }
        }
    }
}
