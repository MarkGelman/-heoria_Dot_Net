using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultyTrades
{
    class Monitor_LOCK
    {
        static object key = new object();
        public static void DoWork()
        {
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} entered");
            try
            {
                // waiting for key
                Monitor.Enter(key);

                // got key

                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} wait");
                Thread.Sleep(5000);
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} exit");
                int a = 1;
                int b = 0;
                int c = a / b;
            }
            finally
            {
                // returning key
                Monitor.Exit(key);
            }
        }

    }
}
