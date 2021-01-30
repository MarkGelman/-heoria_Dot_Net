using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Delegates1
{
    class Program
    {
        public string name1;
        public delegate void Signature_For_Function_Void_With_No_Parameters();
        public delegate float Signature_For_Function_float_with_float_parameter(float f);
        public delegate int Signature_for_function_int_no_parameter();
        public delegate double Signature_for_function_double_with_doublex2_parameters(double d1, double d2);

        //---------------------------------------- CLASSWORK 17.01.21 ----------------------------------------------------------
        static double Multiply(double d1, double d2)
        {
            return d1 * d2;
        }
        static void PrintInvokeResult(Signature_for_function_double_with_doublex2_parameters f, double x, double y)
        {
            double result = f(x, y);
            Console.WriteLine(result);
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

        static void Foo()
        {

        }
        static void Foo2()
        {
            Console.WriteLine("hello");
        }
        static void FooWithObject(object o)
        {
            Console.WriteLine($"Hello with object {o}");
        }
        static double Divide(double d1, double d2)
        {
            return d1 / d2;
        }
        static void Main(string[] args)
        {

            PrintInvokeResult(Multiply, 3.5, 7.8);
            PrintInvokeResult((d1, d2) => d1 / d2, 3.5, 7.8);
            PrintInvokeResult((d1, d2) => d1 + d2, 3.5, 7.8);

            //static void PrintInvokeResult(Signature_for_function_double_with_doublex2_parameters f, double x, double y)
            //{
            //    double result = f(x, y);
            //    Console.WriteLine(result);
            //}

            // functions first class member
            // delegate ==> method signature 
            //MyFunc_Void_No_Parameters();

            Thread t = new Thread(MyFunc_Void_No_Parameters);
            // 1 create a functions in delegate of ParameterizedThreadStart
            // 2 create the thread , in ctor pass the function you just created name 
            Thread t1 = new Thread(Foo); // public Thread(ParameterizedThreadStart start);
            Thread t2 = new Thread(FooWithObject); // public Thread(ParameterizedThreadStart start);
            Thread t3 = new Thread(Foo2); // public Thread(ParameterizedThreadStart start);
            //ParameterizedThreadStart
            // lambda _ => { } 
            // lazy + less code
            // function inline
            Thread t4 = new Thread(() => Console.WriteLine("hello")); // anonymous -- ThreadStart
            Thread t5 = new Thread(o => Console.WriteLine($"Hello with object {o}")); // ParameterizedThreadStart

            t4.Start();
            t5.Start("the object is a string");

            List<int> l1 = new List<int> { 1, 2, 3, 5 };
            l1.ForEach(_ => Console.WriteLine(_));

            F2(F1);
            F2((s1, s2) =>
            {
                string str = s1 + s2;
                Console.WriteLine(str.ToLower());
            });
            
           Console.WriteLine(F4(F3, -4.555f, 19.4545f));
        }
        // create a signature (delegate) D1 that retruns void and accepts 2 string parameters\
        public delegate void D1(string s1, string s2);
            // create a function F1 that retruns void and accepts 2 string parameters -- in this function
            //  concat the two strings and print in upper case
        static void F1 (string s1,string s2)
        {
            string str = s1 + s2;
            Console.WriteLine(str.ToUpper());
        }
            
            // create a function F2 that gets a method with type D1 and invokes it with "hello ", "world"
            // from main call F2 and send it F1 as parameter
            // from main call F2 and send it lambda expression which does the same as F1 but with lower case
        static void F2 (D1 d)
        {
            d("hello ", "world");
        }
        // from main call F2 and send it lambda expression which print the two strings in reverse
        // create a signature (delegate) D2 that retruns float and accepts 2 floats parameters
        public delegate float D2 (float f1, float f2);
        // create a function F3 that retruns float and accepts 2 floats parameters -- in this function
        //  RETURN the sum of both numbers
        static float F3 (float f1, float f2)
        {
            return f1 + f2;
        }

        // create a function F4 that gets a method with type D2 and two floats and invokes the function with the 2 floats
        // from main Console.Writeline the result of F4 and send it F3 as parameter, -4.555f, 19.4545
        static float F4(D2 d,float f1,float f2)
        {
            return d(f1, f2);
        }



        // from main Console.Writeline the result of F4 and send it lambda expression which perform minus 20.38 5.25
        // from main Console.Writeline the result of F4 and send it lambda expression which perform multiply 14.4 60.27
        // from main Console.Writeline the result of F4 and send it lambda expression which perform div, 
        //       but first check if not divide by zero 54.24 75.06 (+ also: 54.24, 0)
        // from main Console.Writeline the result of F4 and send it lambda expression which perform pow 43 91.26
        // from main Console.Writeline the result of F4 and send it lambda expression which returns the bigger 45.71 31.19
        // from main Console.Writeline the result of F4 and send it lambda expression which returns the smaller 54.24 75.06

        
    }
        //---------------------------------------- CLASSWORK 17.01.21 ----------------------------------------------------------
}
