
using Theoria_Dot_Net._31_01_21_Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Theoria_Dot_Net._31_01_21_Patterns.SingleTon;
using MultyTrades;
using MultyTrades._31_01_21_Patterns.Pool_Pattern_10_02_21;
using static MultyTrades._31_01_21_Patterns.Pool_Pattern_10_02_21.PoolPattern;
using static MultyTrades._31_01_21_Patterns.Pool_Pattern_10_02_21.Solution_Targil_PoolPattern;

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

                Thread t = new Thread(foo);
                threads.Add(t);
                //t1.IsBackground = true;

                t.Start();
                Console.WriteLine("Main thread is going to sleep .............:");

                Thread.Sleep(1000);
            }
            Console.WriteLine("BOOM");
            Console.WriteLine("Main thread is over ...........");
            threads.ForEach(_ => _.Abort());

            /* ---------------------------------------------------------- Pattern_Queue 31-01-21 -----------------------------------------------------------*/

            Pattern_Queue workerQueue = new Pattern_Queue();
            //new Thread(Counter).Start();
            //new Thread(Counter).Start();
            //new Thread(Counter).Start();
            //new Thread(Counter).Start();

            Pattern_Queue wq = new Pattern_Queue(10);
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
/* ***************************************************  07-02-21 **********************************************************************************/

   /* -------------------------------------------- !!! PATTERN SINLETON !!! -------------------------------------------------------------*/


            ClockSingleton.GetInstance().GetDateTimeByRegion();
            if (ClockSingleton.GetInstance() == ClockSingleton.GetInstance())
            {
                Console.WriteLine("equal");
            }
            else
            {
                Console.WriteLine("Not equal!");
            }

            // ClockSingleton.GetInstance() = null; // Error!
            ClockSingleton sing = ClockSingleton.GetInstance();
            sing = null; // will not change the singleton

            /* -------------------------------------------- Solution_Targil_SINGLETON  -----------------------------------------------------*/
          
                DbConnection conn1 = ConnPooL.GetInstance().GetConnection();
                ConnPooL.GetInstance().ReturnConnection(conn1);

            /* -------------------------------------------- MONITOR_LOCK  ---------------------------------------------------------*/
            
                Thread t1 = new Thread(() =>
                {
                    try { Monitor_LOCK.DoWork(); } catch { Console.WriteLine("Exception"); }
                });
                Thread t2 = new Thread(() =>
                {
                    try { Monitor_LOCK.DoWork(); } catch { Console.WriteLine("Exception"); }
                });
                t1.Start();
                t2.Start();

                t1.Join();
                t2.Join();


            /* -------------------------------------------- PATTERN POOL  ---------------------------------------------------------*/
            MyConnectionPool.Instance.GetConnection(); // blocking
                                                       // Task:
                                                       // ...Blocking
                                                       // ...Sync
                                                       // ...Async

            // ................


            /* --------------------------------------------Solution_targil PATTERN POOL  -----------------------------------------*/
            Thread t01 = new Thread(() => MyFileManager.Instance.WriteToFile("Line1"));
            Thread t02 = new Thread(() => MyFileManager.Instance.WriteToFile("Line2"));
            Thread t3 = new Thread(() => MyFileManager.Instance.WriteToFile("Line3"));
            Thread t4 = new Thread(() => MyFileManager.Instance.DeleteFile());
            Thread t5 = new Thread(() => MyFileManager.Instance.CreateFile());
            Thread t6 = new Thread(() => MyFileManager.Instance.WriteToFile("Line4"));
            Thread t7 = new Thread(() => MyFileManager.Instance.CreateFile());
            //Thread t8 = new Thread(() => MyFileManager.Instance.DeleteFile());
            Thread t8 = new Thread(() => MyFileManager.Instance.WriteToFile("Done."));
            Thread t9 = new Thread(() => MyFileManager.Instance.WriteToFile("Line5"));

            t01.Start();
            Thread.Sleep(1000);
            t02.Start();
            Thread.Sleep(1000);
            t3.Start();
            Thread.Sleep(1000);
            t4.Start();
            Thread.Sleep(1000);
            t5.Start();
            Thread.Sleep(1000);
            t6.Start();
            Thread.Sleep(1000);
            t7.Start();
            Thread.Sleep(1000);
            t8.Start();
            Thread.Sleep(1000);
            t9.Start();
            Thread.Sleep(1000);

        }
    }
}
