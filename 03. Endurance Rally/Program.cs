using System;
using System.Linq;

namespace Endurance_Rally
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var names = Console.ReadLine()
                .Split()
                .ToList();

            var zoneValues = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToList();

            var checkPoints = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            foreach (var driver in names)
            {
                bool outOfFuel = false;
                int endIndex = 0;
                double fuel = driver[0];

                for (int i = 0; i < zoneValues.Count; i++)
                {
                    if (checkPoints.Contains(i))
                    {
                        fuel += zoneValues[i];
                    }
                    else
                    {
                        fuel -= zoneValues[i];
                    }

                    if (fuel <= 0)
                    {
                        outOfFuel = true;
                        endIndex = i;
                        break;
                    }

                }
                if (outOfFuel == true)
                {
                    Console.WriteLine($"{driver} - reached {endIndex}");
                }
                else
                {
                    Console.WriteLine("{0} - fuel left {1:f2}", driver, fuel);
                }
            }
        }
    }
}
