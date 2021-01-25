/* Вся программа состоит из процессов(VS,Word,Any Desk...) кот состоят из threads.Процесс заканчивается только когда заканчиваются 
 * все Threads его.
 * Foreground - важный трэйд
 * Daemon - второстепеный трэйд
 * Процессор может задействовать только один трэйд одновременно.
 * Библиотека TPN разбивает большой трэйд на несколько трейдов более маленьких. К примеру, Main - это трэйд, кот в свою очередь можно
 * разбить на несколько небольших трэйдов.
 * 
 */
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
                Thread.Sleep(500);
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("45 * 12 = ?");

            var ct = Thread.CurrentThread;

            // Если в режиме Debug навести курсор на ct то в intellicenc получим следующую инфу:
            //  IsAlive (true/false) => продолжает работать или закончился;
            //  IsBackground (true/false) => трэйд главный или второстепеный;
            //  IsThreadPoolThread (true/false) => это патерн в проге кот позволяет концентрировать много трэйдов в одном месте,
            //    чтобы их можно было быстро задействовать;
            //  ManagedThreadId => это трэйд кот привязан к CLR. На курсе мы будем работать толька с такими трэйдами;
            //  Name => имя не всегда вводят -- эта вещь не обязательна;
            //  Priority => Степень значимости данного трэйда (HiPriority,Normal,LowPriority). Уже не используют т.к было много проблем
            //  ThreadState => на каком этапе находится данный трэйд (Running, Start ...

            // int result = Convert.ToInt32(Console.ReadLine()); 

            //Этот процесс называется -- blocking. В это время комп висит и ждёт пока пользователь не введёт требуюмую инфу.
            // Трэйды предназначены, для того чтобы в это время комп что-то делал, а не ждал пока дейтсвующий процесс закончится.

            for (int i = 3; i >= 0; i--)
            {
                Console.WriteLine($"Main thread {i}");

                //Thread t1_ = new Thread(() => { }); // lambda expression
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
