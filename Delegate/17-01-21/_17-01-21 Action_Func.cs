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

        /*------------EX2:-------------------*/
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

        // 4.Executor which gets as parameter int [] and  invoke the function
        //   From main call this executor with lambda and write an expression which sets all values in zero (void)

        public int[] Executor(Func<int[],int[]> f, int[] x)
        {
            return f(x);
        }

        // 5.Executor which gets as parameter double [] and  invoke the function
        //   From main call this executor with lambda and write an expression which returns the sum of all elements which are 
        //   bigger than the second parameter

        public double ExecutorDouble(Func<double[], double,double> f)
        {
            double min = 6.21;
            double[] arr_d = { 1, 2, 5, 1001239,-7.4568,1231.5345,2.22222,3.14};
            return f(arr_d,min);
        }

        void PrintArray()
        {
            int[] arr = { 1, 3, 5, 7 };
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
           
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]*2);
            }
        }
        public void RunOnArray (Action<int> f, int[] arr)
        {
                for (int i=0; i<arr.Length;i++)
                {
                    f(arr[i]);
                }
        }

        
       public int CountOnArray (Func<int,bool> f,int[]arr)
        {
            int counter = 0;
            for (int i=0; i<arr.Length; i++)
            {
                if (f(arr[i]))
                {
                    counter++;
                }
            }
            return counter;
        }

        // ---------------------------------- Упражнение ------------------------------------------------
        //No 1:
        /* create an executor function that gets as parameter a Func which gets an int and returns bool,and List<int>
           this excutor will run on each element of the list and each element which was return true will be added to the result list
           from main call this method using lambda and:
                1.get all items biger than 0
                2.get all items biger than average
                3.get all items smaller then -100*/

       

        public List<int> ExecutorList (Func<int,bool> f, List<int> list)
        {
            List<int> listResult = new List<int>();
            for (int i = 0; i<list.Count;i++)
            {
                if(f(list[i]))
                {
                    listResult.Add(list[i]);
                }
            }
            return listResult;
        }

        //No 2:
        /*Create another executor function that gets as parameter a Func whch gets an int and returns bool, List<int>
         and returns bool
         this executor will run on each element of the list and if one element was true will return true, if none will return
         false from main call this method using lambda and:
            1.get all items biger than 0;
            2.get all items biger than average
            3.get all items smaller then -100*/

        public bool TrueOrFalse(Func<int, bool> f, List<int> list)
        {
            List<int> listResult = new List<int>();
            for (int i = 0; i < list.Count; i++)
            {
                if (f(list[i]))
                {
                    return true;
                }
            }
            return false;
        }

        

    }



}
