using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Delegate
{
    class Program
    {
        /*public string name1;
        public delegate void Signature_For_Function_Void_With_No_Parameters();
        public delegate float Signature_For_Function_float_with_float_parameter(float f);
        
        static void Study1(ThreadStart ts)
        {
            //ts.Invoke();
        }
        static void Invokder10Times(Signature_For_Function_Void_With_No_Parameters ms)
        {
            for (int i = 0; i < 10; i++)
            {
                ms();
            }
        }
        static void Study2(String name)
        {
            Console.WriteLine(name);
        }

        static void MyFunc_Void_No_Parameters()
        {
            Console.WriteLine("I am MyFunc_Void_No_Parameters");
        }*/

        static void Main(string[] args)
        {
            /*// functions first class member
            // delegate ==> method signature 
            //MyFunc_Void_No_Parameters();

            Thread t = new Thread(MyFunc_Void_No_Parameters);

            Study1(MyFunc_Void_No_Parameters);

            Study2("i love delegate!");*/

            /*/// CLASSWORK:

        // 1 create a functions in delegate of ParameterizedThreadStart
        // 2 create the thread , in ctor pass the function you just created name 
        Thread t1 = new Thread(foo); // public Thread(ThreadStart start);
        Thread t2 = new Thread(FooWithObject);//public Thread(ParameterizedThreadStart start);
        static void foo ()
        {

        }

        static void FooWithObject (object o)
        {

        }
        // 3 create a delegate for function that returns int and get no parameter
        // 4 create a delefate for function that returns double and gets two dobules
        // 4.1 create a real function that gets 2 doubles and return double (which is sum of both parameters)
        // 5 create a function that gets as parameter the function type (delegate) you created in 4
        //   in this function invoke the method you created in 4.1. and print the result

        public delegate double Signature_For_Function_double_with_doublex2_parameters(double d1, double d2);//CW (4)

        static double Multiply(double d1, double d2)
        {
            return d1 * d2;
        }

        static void PrintMultiply(Signature_For_Function_double_with_doublex2_parameters f, double x, double y)//CW (4.1-5)
        {
            double result = f(x, y);
            Console.WriteLine(result);
        }*/

            /*
               ---------------------------------------- CLASSWORK 17.01.21 ----------------------------------------------------------
                        1. Executor (<lambda-print the number * 2> (void))
                        2. Executor (<lambda-return Math.Sqrt(the_number)> (float))
            */

            _17_01_21 obj = new _17_01_21();
            obj.Executor(x => Console.WriteLine(x * 2), 100);
            Console.WriteLine(obj.Executor(x => Math.Sqrt(x), 4));

            //CW2:
            // No 1
            obj.Executor((x,y) => Console.WriteLine(x + y), 100,3);
            // No 2
            Console.WriteLine(obj.Executor(x => x*x,24.3));
            // No 3
            int[] arr = { 1, 2, 4, 9 };
            obj.Executor( _ =>
                                   {
                                       for (int i = 0; i < _.Length; i++)
                                       {
                                           _[i] =  0;
                                       }
                                   }
                                    ,arr );
            // No 4
            
            obj.ExecutorDouble((rra,min)=> 
            {
                double sum = 0.0;
                foreach (var item in rra)
                {
                    sum = sum + item > min ? item : 0.0;
                }
                return sum;
            });

            obj.RunOnArray(_ => Console.WriteLine(_), arr);

            //ещё пример
            //Сначала длиный способ
            int count100 = 0;
            for(int i=0;i<arr.Length; i++)
            {
                if (arr[i]>100)
                {
                    count100++;
                }
            }

            //A теперь короткий
            count100 = obj.CountOnArray(x => x > 100, arr);

           //Меняя условие нужно снова писать:
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] ==  0)
                {
                    count100++;
                }
            }

            // а можно так:
            count100 = obj.CountOnArray(x => x ==0, arr);

            /* --------------------------------- Упражнение ------------------------------------------------------*/
            //No 1
            List<int> listToSend = new List<int> { 1, -2, 1000, 2112, 8, -239, 0 };
            List<int> result = obj.ExecutorList(x => x > 0, listToSend);
            result = obj.ExecutorList(x => x > listToSend.Sum()/listToSend.Count , listToSend);
            result = obj.ExecutorList(x => x <-100, listToSend);

            //No 2
            bool trueOrFalse;
            trueOrFalse=obj.TrueOrFalse(x => x > 0, listToSend);
            trueOrFalse = obj.TrueOrFalse(x => x > listToSend.Sum() / listToSend.Count, listToSend);
            trueOrFalse = obj.TrueOrFalse(x => x < -100, listToSend);

            

        }




    }






}
