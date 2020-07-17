using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Businessman
{
    class Oil_well
    {
        static object locker = new object();
        public delegate void Mined_oil(string message);
        public event Mined_oil show;
        private static int oil;

        public void Message(string message)
        {
            Console.WriteLine(message);
        }

        public int Oil
        {
            get
            {
                return oil;
            }
            set
            {
                oil = value;
            }
        }
        

    public void Production()
        {
            show += Message;
            while (true)
            {
                while (Program.check == false)
                {
                    Random rand = new Random();
                    int x = rand.Next(1, 10);
                    lock (locker)
                    {
                        Oil += 100;
                        if (show != null)
                            show($"It was mined new amount of oil, we have - {Oil} liters in total");
                    }
                    Thread.Sleep(x * 600);
                    if(Program.check == true)
                    {
                        Thread.Sleep(100);
                    }
                }

            }
        }     
    }
}
