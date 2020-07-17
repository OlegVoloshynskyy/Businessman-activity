using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businessman
{
    class Bank
    {
        private static int cash;
        public delegate void AccountStateHandler(string message);
        public event AccountStateHandler call;
        
        public int Cash
        {
            get
            {
                return cash;
            }
            set
            {
                cash = value;
            }
        }

        public void Message(string message)
        {
            Console.WriteLine(message);
        }

        public void Withdraw(int sum)
        {
            call += Message;
            if (sum <= Cash && sum > 0)
            {
                Cash -= sum;
                Console.ForegroundColor = ConsoleColor.Green;
                if (call != null)
                    call($"It was taken {sum} from the account");
            }
            else if (sum >= Cash)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                if (call != null)
                    call("Not enough money in the account");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                if (call != null)
                    call("Wrong operation");
            }
        }
    }
}
