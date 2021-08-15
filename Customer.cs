using System;

namespace SydneyCoffeewarehouse
{
    class Customer
    {
        // Properties
        public string Name { get; } 
        public int NumCoffeeBags { get; }
        public bool Reseller { get; }

        /// Using Constructor 

        /// <param name="name"></param>
        /// <param name="numCoffeeBags"></param>
        /// <param name="reseller"></param>
        public Customer(string name, int numCoffeeBags, bool reseller)
        {
            Name = name;
            NumCoffeeBags = numCoffeeBags;
            Reseller = reseller;
        }
        /// Conputes total sale value
        ///Total sale vlaue
        public double TotalSales()
        {
            double totalSales = 0;
            // determine based on quantity
            if (NumCoffeeBags > 15)
            {
                totalSales = NumCoffeeBags * 32.7;
            }
            else if (NumCoffeeBags > 6 && NumCoffeeBags <= 15)
            {
                totalSales = NumCoffeeBags * 34.5;
            }
            else
            {
                totalSales = NumCoffeeBags * 36;
            }

            // Resellers gets additional 20% discount
            if (Reseller)
            {
                totalSales -= totalSales * .20;
            }

            return totalSales;
        }


        /// Write the total sale value on the console screen

        public void DisplaySales()
        {
            Console.WriteLine("The Total sales from " + Name + " is-" + TotalSales().ToString("C"));
        }
    }
}