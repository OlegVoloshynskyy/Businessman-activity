using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Businessman
{
    class Gas_station
    {
        public delegate void Patrol_sold(string message);
        public event Patrol_sold show;
        static Mutex mutexObj = new Mutex();
        Processing_plant processing_Plant = new Processing_plant();
        Bank purchase = new Bank();

        public void Message(string message)
        {
            Console.WriteLine(message);
        }

        public void Filling()
        {
            show += Message;
            Random rand = new Random();
            int x = rand.Next(1, 10);
            while (true)
            {
                Thread.Sleep(x * 50);
                while (Program.check == false)
                {
                    if (processing_Plant.Patrol >= 100)
                    {
                        mutexObj.WaitOne();
                        {
                            processing_Plant.Patrol -= 60;
                            purchase.Cash += 70;
                        }
                        mutexObj.ReleaseMutex();
                        if (show != null)
                            show("The car was refueled, the total purchase =  " + purchase.Cash + "$");
                        Thread.Sleep(x * 500);
                    }
                }
                if (Program.check == true)
                {
                    Thread.Sleep(100);
                }
            }
        }
    }
}
