﻿
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
        static Random r = new Random();//targil
        static object key = new object();//WorkerQueue
        public static void Counter()
        {
            Console.WriteLine($"=== thread : {Thread.CurrentThread.ManagedThreadId} before lock ...");
            lock (key)
            {
                for (int i = 1; i <= 10; i++)
                {
                    Console.WriteLine($"=== thread : {Thread.CurrentThread.ManagedThreadId} i: {i}");
                    Thread.Sleep(1 * 1000);
                }
            }
        }

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
            List<Thread> threads = new List<Thread>();
            Console.WriteLine("45 * 12 = ?");

            var ct = Thread.CurrentThread;
            // int result = Convert.ToInt32(Console.ReadLine()); 
            for (int i = 3; i >= 0; i--)
            {
                Console.WriteLine($"Main thread {i}");

                Thread t1 = new Thread(foo);
                threads.Add(t1);
                //t1.IsBackground = true;

                t1.Start();
                Console.WriteLine("Main thread is going to sleep .............:");

                Thread.Sleep(1000);
            }
            Console.WriteLine("BOOM");
            Console.WriteLine("Main thread is over ...........");
            threads.ForEach(_ => _.Abort());

            /* ---------------------------------------------------------- 31-01-21 -----------------------------------------------------------*/

            WorkerQueue workerQueue = new WorkerQueue();
            //new Thread(Counter).Start();
            //new Thread(Counter).Start();
            //new Thread(Counter).Start();
            //new Thread(Counter).Start();

            WorkerQueue wq = new WorkerQueue(10);
            wq.Produce(() =>
            {
                for (int i = 1; i <= 5; i++)
                {
                    Console.WriteLine($"=== i_1_5 {i}");
                    Thread.Sleep(1 * 1000);
                }
            });

            wq.Produce(() =>
            {
                for (int i = 1; i <= 3; i++)
                {
                    Console.WriteLine($"=== i_1_3 {i}");
                    Thread.Sleep(1 * 1000);
                }
            });

            wq.Produce(() =>
            {
                for (int i = 1; i <= 8; i++)
                {
                    Console.WriteLine($"=== i_1_8 {i}");
                    Thread.Sleep(1 * 1000);
                }
            });

            Console.WriteLine("Main waiting...");
            Thread.Sleep(100);
            Console.WriteLine("Main finished...");

            /* -------------------------------------------- Solution_Targil -----------------------------------------------------*/
            SolutionTargil sl = new SolutionTargil();
            List<Thread> thread = new List<Thread>();
            thread.Add(new Thread(() => {
                for (int i = 0; i < 100; i++)
                {
                    sl.Push(i);
                    Thread.Sleep(r.Next(100, 500));
                }
            }));
            thread.Add(new Thread(() => {
                Thread.Sleep(500);
                for (int i = 0; i < 50; i++)
                {
                    sl.Pop();
                    Thread.Sleep(r.Next(500, 1000));
                }
            }));
            threads.Add(new Thread(() => {
                for (int i = 0; i < 5; i++)
                {
                    sl.Peep();
                    Thread.Sleep(r.Next(100, 200));
                }
            }));
            Console.WriteLine("Wait...");
            //Thread.Sleep(3000);
            foreach (var item in threads)
            {
                item.Start();
            }


        }
    }
}
