using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            /* -----------------------------------------------CLASSWORK 20.01.21 ----------------------------------------------------*/
            Linq1 obj = new Linq1();

            List<int> list = new List<int>() { 1, -2, 3, -4, 6, -100, 2, 3 };
            List<double> list_double = new List<double>() { -0.979, 4.1232, 3.17, 80.0 };

            //list.ForEach(MyForEachLinq);
            list.ForEach(x => Console.WriteLine(x));
            obj.MyForeachZugi<int>(list, x => Console.WriteLine(x));
            obj.MyForeach(list, x => Console.WriteLine(x));

            List<int> result_list = list.Where(obj.WhereFuncForPositive).ToList();
            List<int> result_list1 = list.Where(x => x > 0).ToList();
            List<int> result_list2 = obj.MyWhere(list, x => x > 0);
            List<double> result_list3 = obj.MyWhereGeneric<double>(list_double, x => x > 0);
            List<double> result_list4 = obj.MyWhereGeneric(list_double, x => x > 0);

            // TODO:
            // use all 5 with lambda + check results!
            // 1 + 2 + 3 => write methods that do the same (*etgar: also Generic)
            // list.Find
            // list.FindAll
            // list.FindIndex
            // list.FindLast
            // list.FindLastIndex
        }
    }
}
