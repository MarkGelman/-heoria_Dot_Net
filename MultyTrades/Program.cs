
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Theoria_Dot_Net
{
    class Program
    {
        static void foo()
        {
            for (int i = 1; i < 10; i++)
            {
                Console.WriteLine($"---{i}--- this is t1 thread id : {Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(80);
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("45 * 12 = ?");

            var ct = Thread.CurrentThread;
            // int result = Convert.ToInt32(Console.ReadLine()); 
            for (int i = 3; i >= 0; i--)
            {
                Console.WriteLine($"Main thread {i}");

                Thread t1 = new Thread(foo);
                t1.IsBackground = true;

                t1.Start();
                Console.WriteLine("Main thread is going to sleep .............:");

                Thread.Sleep(1000);
            }
            Console.WriteLine("BOOM");
            Console.WriteLine("Main thread is over ...........");
        }
    }
}
