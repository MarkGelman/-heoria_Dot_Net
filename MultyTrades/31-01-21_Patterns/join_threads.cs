using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultyTrades
{
    class join_threads
    {
        void CW ()
        {
            Thread counterThread = new Thread(() =>
            {
                for (int i = 1; i <= 5; i++)
                {
                    Console.WriteLine(i);
                    Thread.Sleep(1 * 1000);
                }
            });

            counterThread.IsBackground = true;
            counterThread.Start();
            counterThread.Join(); // blocking -- waiting for counterThread
            // to finish ........................
            Console.WriteLine("After join ...");
        }
        

    }
}
