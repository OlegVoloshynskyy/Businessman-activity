using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Businessman
{
    class Program
    {
        public static bool check = false;
        static void Main(string[] args)
        {
            Oil_well oil_Well = new Oil_well();
            Thread thread1 = new Thread(oil_Well.Production);    
            Processing_plant processing_Plant = new Processing_plant();
            Thread thread2 = new Thread(processing_Plant.Revision);
            Gas_station gas_Station = new Gas_station();
            Thread thread3 = new Thread(gas_Station.Filling);
            thread1.Start();
            thread2.Start();
            thread3.Start();
            Withdraw_operation();

        }
        public static void Withdraw_operation()
        {
            Bank bank = new Bank();
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.F)
                {
                    check = true;
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("----------Withdraw operation-----------");
                    Console.WriteLine($"You have {bank.Cash}$ on your account!");
                    Console.WriteLine("Do you want to take any money? Y/N");
                    ConsoleKeyInfo key_1 = Console.ReadKey(true);
                    if (key_1.Key == ConsoleKey.Y)
                    {
                        Console.WriteLine("How much do you want to take?");
                        string s = Console.ReadLine();
                        int sum;
                        sum = Int32.Parse(s);
                        bank.Withdraw(sum);
                        bank.call -= bank.Message;
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("-----Continuation of work-----------");
                        Console.ResetColor();
                    }
                    else if (key_1.Key != ConsoleKey.Y)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("-----------You came out of the bank-------------");
                        Console.ResetColor();
                    }
                    check = false;
                }
                else if(key.Key == ConsoleKey.Escape)
                {
                    System.Environment.Exit(0);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("For this key is not found special operation");
                    Console.ResetColor();
                }
            }
        }
    }
}
