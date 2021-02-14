using System;
using System.Collections.Generic;
using System.Text;

namespace ChangeCalculator
{
    public class ChangeCalculator
    {
        decimal[] denominations;

        /// <summary>
        /// ChangeCalculator constructor with intialises the denominations array
        /// </summary>
        public ChangeCalculator()
        {
            denominations = new decimal[] { 50.00m, 20.00m, 10.00m, 5.00m, 
                2.00m, 1.00m, 0.50m, 0.20m, 0.10m, 0.05m, 0.02m, 0.01m };
        }

        /// <summary>
        /// Calculates the change given for a transaction
        /// </summary>
        /// <param name="moneyGiven">Money given for the transaction</param>
        /// <param name="price">Price of the product in the transaction</param>
        /// <returns>A dictionary which key is the denomination and the value is the count</returns>
        public Dictionary<decimal, int> CalculateChange(decimal moneyGiven, decimal price)
        {
            if(moneyGiven <= decimal.Zero)
            {
                throw new ArgumentOutOfRangeException(nameof(moneyGiven),
                    "The value needs to be greater than 0.");
            }

            if (price <= decimal.Zero)
            {
                throw new ArgumentOutOfRangeException(nameof(price),
                    "The value needs to be greater than 0.");
            }

            if (moneyGiven <= price)
            {
                throw new ArgumentException("Money given must be greater than price.");
            }

            var change = new Dictionary<decimal, int>();
            var changeNeeded = moneyGiven - price;

            foreach (var denomination in denominations)
            {
                var count = 0;

                while (denomination <= changeNeeded)
                {
                    changeNeeded -= denomination;
                    count++;
                }

                if(count > 0)
                {
                    change.Add(denomination, count);
                }    
            }

            return change;
        }

        /// <summary>
        /// Prints out the return object to the console
        /// </summary>
        /// <param name="change">Dictionary returned by CalculateChange</param>
        public static void PrettyPrint(Dictionary<decimal, int> change)
        {
            foreach(var key in change.Keys)
            {
                Console.WriteLine($"{change[key]} x {key:c}");
            }
        }
    }
}
