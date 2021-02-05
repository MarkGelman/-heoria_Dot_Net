using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EventsDelegates
{
    class multi_delegate
    {
        delegate void Func_void_no_parameters();
        static void MultiDelegate()
        {
            // +=
            Func_void_no_parameters del1 = () => {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("Hello world! 1");
                    Thread.Sleep(1000);
                }

            };

            del1 += () => {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("Good morning... 2");
                    Thread.Sleep(1000);
                }
            };
            Delegate[] del_arr = del1.GetInvocationList();

            foreach (var item in del_arr)
            {
                Thread t = new Thread(() => { item.DynamicInvoke(); });
                t.Start();
            }

            //del1();
            //del1.Invoke();
            Console.WriteLine("Main finished...");
        }
    }
}
