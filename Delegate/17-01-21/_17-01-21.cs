using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    class _17_01_21
    {
        public delegate void Function_void_with_int_parameter(int num);
        public delegate double Function_float_with_int_parameter(int num);
       /* public void Executor (Function_void_with_int_parameter n,int x)
        {
            n(x);
        }

        public double Executor(Function_float_with_int_parameter n, int x)
        {
          
            return n(x);
        }*/

        public void Executor(Action<int> n, int x)
        {
            n(x);
        }

        public double Executor(Func<int, double> n, int x)//В угольных скобках последний тип он DOUBLE. Поэтому --  это не тип параметра принимаемого ф-цией последним, 
                                                            //а тип значения, которая данная функция возвращает.
        {

            return n(x);
        }

        /*------------CW2:-------------------*/
             //   USE FUNC OR ACTION //

        // 1.Executor which gets as parameter int, int and invoked the function
        //   From main call this executor with lambda and write an expression which prints their sum
         
        public void Executor(Action<int,int> f,int x, int y)
        {
            f(x, y);
        }

        // 2.Executor which gets as parameter double and return the result of function invoke
        //   From main call this executor with lambda and write an expression which return their mul

        public double Executor(Func<double, double> f, double x)
        {
            return f(x);
        }

        // 3.Executor which gets as parameter int [] and  invoke the function
        //   From main call this executor with lambda and write an expression which sets all values in zero (void)

        public void Executor(Action<int[]> f, int [] x)
        {
            f(x);
        }

        // 3.Executor which gets as parameter int [] and  invoke the function
        //   From main call this executor with lambda and write an expression which sets all values in zero (void)

        public int[] Executor(Func<int[],int[]> f, int[] x)
        {
            return f(x);
        }

        // 4.Executor which gets as parameter double [] and  invoke the function
        //   From main call this executor with lambda and write an expression which returns the sum of all elements which are 
        //   bigger than the second parameter

        public double Executor(Func<double[], double> f, double[] x)
        {
            return f(x);
        }
    }
}
