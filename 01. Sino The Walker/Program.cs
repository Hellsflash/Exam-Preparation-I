using System;
using System.Globalization;

namespace Sino_The_Walker
{
   public class Program
    {
       public static void Main(string[] args)
        {
            var timeOfLeaving = DateTime.ParseExact(Console.ReadLine(), "HH:mm:ss", CultureInfo.InvariantCulture);
            var steps = long.Parse(Console.ReadLine()) % (60 * 60 * 24);
            var secondsForStep = long.Parse(Console.ReadLine()) % (60 * 60 * 24);

            var secondWalking = steps * secondsForStep;

            var result = timeOfLeaving + TimeSpan.FromSeconds(secondWalking);



            Console.WriteLine("Time Arrival: {0:HH:mm:ss}", result);

        }
    }
}
