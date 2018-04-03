using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo di = new DirectoryInfo("Data");

            if (di.Exists)
            {
                di.Delete(true);
            }

            di.Create();

            StreamWriter sw = File.CreateText("Data\\money.txt");

            Console.WriteLine("Hello!");

            // Income value
            int debetSum = 0;
            for(int i = 0; i < 10; i++)
            {
                string debet = "";
                int debetInt;

                Console.Write("Income: ");
                debet = Console.ReadLine();
                sw.WriteLine("Income: " + debet);

                int.TryParse(debet, out debetInt);
                debetSum += debetInt;    
            }

            sw.WriteLine("Your total income: " + debetSum.ToString());
            sw.WriteLine();

            // Outcome value
            int creditSum = 0;
            for (int i = 0; i < 10; i++)
            {
                string credit = "";
                int creditInt;

                Console.Write("Outcome: ");
                credit = Console.ReadLine();
                sw.WriteLine("Outcome: " + credit);

                int.TryParse(credit, out creditInt);
                creditSum += creditInt;
            }

            sw.WriteLine("Your total income: " + creditSum);
            sw.WriteLine();

            /*
                Counting balance and write balance to sw 
            */

            int balance = debetSum - creditSum;
            sw.WriteLine("Your balance:" + balance.ToString());

            if (balance > 0)
            {
                sw.WriteLine("You have some money");
            }
            else
            {
                sw.WriteLine("You are broke.");
            }

            sw.Close();

            Console.WriteLine("Press any key");
            Console.ReadKey();
        }
    }
}
