using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    class Linq1
    {
        /* -----------------------------------------------CLASSWORK 20.01.21 ----------------------------------------------------*/

        public void MyForEachLinq(int x) 
        {
            Console.WriteLine(x);
        }
        // *Etgar
        public void MyForeachZugi<T>(List<T> list, Action<T> foreachAction)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (i % 2 == 0)
                {
                    foreachAction(list[i]);
                }
            }
        }
        public void MyForeach(List<int> list, Action<int> foreachAction)
        {
            foreach (var item in list)
            {
                foreachAction(item);
            }
        }
        public bool WhereFuncForPositive(int x)
        {
            return x > 0;
        }
        public List<int> MyWhere(List<int> list, Func<int, bool> whereFunc)
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
        public List<T> MyWhereGeneric<T>(List<T> list, Func<T, bool> whereFunc)
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

        public T MyFindGeneric<T>(List<T> list, Func<T, bool> findFunc)
        {
            List<T> result = new List<T>();
            foreach (var item in list)
            {
                if (findFunc(item))
                {
                    return item;
                }
            }
            return default(T);
        }

        public List<T> MyFindAllGeneric<T>(List<T> list, Func<T, bool> findFunc)
        {
            List<T> result = new List<T>();
            foreach (var item in list)
            {
                if (findFunc(item))
                {
                    result.Add(item);
                }
            }
            if (result.Count == 0) return null;
            return result;
        }

        public int MyFindIndexGeneric<T>(List<T> list, Func<T, bool> findFunc)
        {
            foreach (var item in list)
            {
                if (findFunc(item))
                {
                    return list.IndexOf(item);
                }
            }
            return -1;
        }

        public T MyFindLastGeneric<T>(List<T> list, Func<T, bool> findFunc)
        {
            List<T> result = new List<T>();
            result[0] = default(T);
            foreach (var item in list)
            {
                if (findFunc(item))
                {
                    result[0] = item;
                }
            }
            return default(T);

        }

        public int MyFindLastIndexGeneric<T>(List<T> list, Func<T, bool> findFunc)
        {
            
            for (int i= list.Count-1; i<0;i--)
            {
                if (findFunc(list[i]))
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
