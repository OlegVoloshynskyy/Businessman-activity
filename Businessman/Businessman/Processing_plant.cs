using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Businessman
{
    class Processing_plant 
    {
        static object locker = new object();
        public delegate void Mined_patrol(string message);
        public event Mined_patrol show;
        private static int patrol;

        public int Patrol
        {
            get
            {
                return patrol;
            }
            set
            {
                patrol = value;
            }
        }

        public void Message(string message)
        {
            Console.WriteLine(message);
        }

        Oil_well oil_well = new Oil_well();
        
        public void Revision()
        {
            show += Message;
            Random rand = new Random();
            int x = rand.Next(1, 10);
            while (true)
            {
                Thread.Sleep(x * 50);
                while (Program.check == false)
                {
                    if (oil_well.Oil >= 100)
                    {
                        lock (locker)
                        {
                            oil_well.Oil -= 100;
                            Patrol += 60;
                        }
                        if (show != null)
                            show("Portion of patrol was made, in total we have - " + Patrol + " liters");
                        Thread.Sleep(x * 600);
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
