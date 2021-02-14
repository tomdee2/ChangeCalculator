using System;

namespace ChangeCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var calculator = new ChangeCalculator();
            var output = calculator.CalculateChange(20.00m, 5.50m);

            Console.WriteLine("Your change is:");
            ChangeCalculator.PrettyPrint(output);
        }
    }
}
