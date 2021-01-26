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
        public string name1;
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
        }

        static void Main(string[] args)
        {
            // functions first class member
            // delegate ==> method signature 
            //MyFunc_Void_No_Parameters();

            Thread t = new Thread(MyFunc_Void_No_Parameters);

            
        

            Study1(MyFunc_Void_No_Parameters);

            Study2("i love delegate!");

        }

        /// CLASSWORK:

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
        }

    }
}
