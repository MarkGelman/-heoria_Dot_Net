using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    class Linq2
    {

        static void MyForEachLinq(int x)
        {
            Console.WriteLine(x);
        }
        // *Etgar
        static void MyForeachZugi<T>(List<T> list, Action<T> foreachAction)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (i % 2 == 0)
                {
                    foreachAction(list[i]);
                }
            }
        }
        static void MyForeach(List<int> list, Action<int> foreachAction)
        {
            foreach (var item in list)
            {
                foreachAction(item);
            }
        }
        static bool WhereFuncForPositive(int x)
        {
            return x > 0;
        }
        static List<int> MyWhere(List<int> list, Func<int, bool> whereFunc)
        {
            List<int> result = new List<int>();
            foreach (var item in list)
            {
                if (whereFunc(item))
                {
                    result.Add(item);
                }
            }
            return result;
        }
        static List<T> MyWhereGeneric<T>(List<T> list, Func<T, bool> whereFunc)
        {
            List<T> result = new List<T>();
            foreach (var item in list)
            {
                if (whereFunc(item))
                {
                    result.Add(item);
                }
            }
            return result;
        }
        static int MyFind(List<int> list, Func<int, bool> f)
        {
            foreach (var item in list)
            {
                if (f(item))
                {
                    return item;
                }
            }
            return 0;
        }
        static T MyFind<T>(List<T> list, Func<T, bool> f)
        {
            foreach (var item in list)
            {
                if (f(item))
                {
                    return item;
                }
            }
            return default(T);
        }
        class Person
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
        }
        static void Change(int x)
        {
            x = 0;
        }
        static bool Check_if_n_items_pass_condition(List<int> list, int how_many_times, Predicate<int> f)
        {
            int counter = 0;
            foreach (var item in list)
            {
                if (f(item))
                {
                    counter++;
                    if (counter >= how_many_times)
                        return true;
                }
            }
            return false;
        }
        void IEnurable()
        {
            List<double> res_ = lazy.ToList();
            IEnumerable<double> lazy = doubles.Where(_ => _ > 4);
            for (int i = 0; i < doubles.Count; i++)
            {
                doubles[i] = 0;
            }
        }
        // The following method should return true if each element in the squares sequence
        // is equal to the square of the corresponding element in the numbers sequence.
        // Try to write the entire method using only LINQ method calls, and without writing
        // any loops.
        public static bool TestForSquares(IEnumerable<int> numbers, IEnumerable<int> squares)
        {
            return false;
        }
        // Given a sequence of words, get rid of any that don't have the character 'e' in them,
        // then sort the remaining words alphabetically, then return the following phrase using
        // only the final word in the resulting sequence:
        //    -> "The last word is <word>"
        // If there are no words with the character 'e' in them, then return null.
        //
        // TRY to do it all using only LINQ statements. No loops or if statements.
        public static string GetTheLastWord(IEnumerable<string> words)
        {
            return false;
        }
    }
}
