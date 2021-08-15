using System;

namespace SydneyCoffeewarehouse
{
    internal class Program
    {
        /// Get number of coffee beans bags from user
        /// returns Number of Bags
        private static int GetNumBags()
        {
            Console.Write("Enter the number of coffee beans bags (bag/1kg): ");
            int numBags = int.Parse(Console.ReadLine());

            while (numBags <= 0 || numBags > 200)
            {
                Console.WriteLine("Invalid value.. Number of bags should be between 1 - 200");
                Console.Write("Enter the number of coffee beans bags (bag/1kg): ");
                numBags = int.Parse(Console.ReadLine());
            }

            return numBags;
        }

        /// Get if the customer is reseller
        ///true if reseller; else, false;
        private static bool IsReseller()
        {
            Console.Write("Enter yes/no to indicate whether you are a reseller: ");
            string reseller = Console.ReadLine()?.ToLower();

            while (reseller != "no" && reseller != "yes")
            {
                Console.WriteLine("Invalid value.. it can be yes/no only");
                Console.Write("Enter yes/no to indicate whether you are a reseller: ");
                reseller = Console.ReadLine()?.ToLower();
            }

            return reseller == "yes";
        }

        private static void DisplayLine()
        {
            Console.WriteLine(new string('-', 100));
        }


        /// Display summary of sales
           /// <param name="customers"> array of customers </param>
        private static void DisplaySummary(Customer[] customers)
        {
            Console.WriteLine();
            Console.WriteLine(String.Format("{0," + Console.WindowWidth / 3 + "}", "--Summary of Sales--"));
            DisplayLine();
            DisplayLine();
            // print table heading
            Console.WriteLine($"{"Name",-15} {"Quantity",15} {"Reseller",15} {"Charge",15}");
            // Assume first customer is most and least spending
            Customer mostSpending = customers[0];
            Customer leastSpending = customers[0];
            
            // print all the customer details
            foreach (Customer customer in customers)
            {
                Console.WriteLine(
                    $"{customer.Name,-15} {customer.NumCoffeeBags,15} {(customer.Reseller ? "yes" : "no"),15} {customer.TotalSales().ToString("C"),15}");
                // Update most spending
                if (customer.TotalSales() > mostSpending.TotalSales())
                {
                    mostSpending = customer;
                }

                // update least spending
                if (customer.TotalSales() < mostSpending.TotalSales())
                {
                    leastSpending = customer;
                }
            }

            DisplayLine();
            DisplayLine();

            // display most and least spending
            Console.WriteLine("The customer spending most is " + mostSpending.Name + " " + mostSpending.TotalSales().ToString("C"));
            Console.WriteLine("The customer spending least is " + leastSpending.Name + " " + leastSpending.TotalSales().ToString("C"));
            Console.WriteLine("===================================**THANK YOU**=====================================");
        }

        private static void Main()
        {
            // get number of clients
            Console.Write("\n Enter Number of Customers: ");
            int numCustomers = int.Parse(Console.ReadLine());
            Console.WriteLine();

            //Display heading
            Console.WriteLine(String.Format("{0," + Console.WindowWidth / 3 + "}", "**Welcome to Sydney Coffee Program**"));
            Console.WriteLine();


            // Create array of Customers
            Customer[] customers = new Customer[numCustomers];

            // Get details for all the customers
            for (int index = 0; index < customers.Length; index++)
            {
                Console.Write("Enter customer name: ");
                string name = Console.ReadLine();
                int numBags = GetNumBags();
                bool reseller = IsReseller();
                // Create new customer object
                Customer customer = new Customer(name, numBags, reseller);
                customer.DisplaySales();
                // Add it to array
                customers[index] = customer;
                DisplayLine();
            }

            //Display summary
            DisplaySummary(customers);
            Console.ReadKey();
        }
    }
}