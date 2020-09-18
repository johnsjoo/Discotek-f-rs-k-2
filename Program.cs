using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discotek_försök_2
{
    class Program
    {
        static void Main(string[] args)
        {


            List<Person> disco = DiscoPersons();
            LoopKeyPressed(disco);

            
            Console.ReadKey(true);
        }

        

        private static void LoopKeyPressed(List<Person>disco)
        {
            var sickPeople = 0;
            var hour = 0;
            disco[0].Infected = true;
            disco[0].InfectedWhen = 0;

            Console.Write("Sick people: ");
            Console.WriteLine($" {disco[0].Infected}");
            Console.WriteLine("*************************************");
            Console.WriteLine("Press 'p' to see next hour of the pandemic!");

            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.KeyChar == 'p')
                {
                    Console.Clear();
                    foreach (var p in disco)
                    {
                        if (p.Infected)
                        {
                            sickPeople++;
                            if (p.InfectedWhen < 5)
                            {
                                p.InfectedWhen++;
                            }
                            else
                            {
                                p.Imune = true;

                                Console.WriteLine($"{p.InfectedWhen}");
                                Console.WriteLine($"Immuna personer: {p.Imune}");
                            }


                        }
                        else if (!p.Infected && sickPeople != 0)
                        {
                            p.Infected = true;
                            sickPeople--;
                        }


                        Console.WriteLine($"{p.Infected}");
                    }
                    

                }
                Console.WriteLine($"Number of people in the disco : {disco.Count}");
                Console.WriteLine($"Total Hours: {hour}");
                hour = HCounter(hour);

                Console.WriteLine("***********************************************");

            }
        }
        private static int HCounter(int hour)
        {
            hour++;
            return hour;
        }

        private static List<Person> DiscoPersons()
        {
            var disco = new List<Person>();
            for (int i = 0; i < 50; i++)
            {
                Person p = new Person();
                p.Infected = false;
                p.Imune = false;
                disco.Add(p);
            }

            return disco;
        }

    }
    class Person 
    {
        public bool Infected { get; set; }
        public int InfectedWhen { get; set; }
        public bool Imune { get; set; }
    }
}
