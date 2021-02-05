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
            int first_item = obj.MyFindGeneric(list, x => x > 0);

            // list.FindAll
            List<int> listAll = obj.MyFindAllGeneric(list, x => x > 0);
            //from all numbers get smaller than 0 and then first bigger than -50 by concat (соединение листов)
            int res = list.Where(x => x < 0).First(x => x < -50);
            // list.FindIndex
            int first_index = obj.MyFindIndexGeneric(list_double, x => x > 0);
            // list.FindLast
            double last_item = obj.MyFindLastGeneric(list_double, x => x > 5);
            // list.FindLastIndex
            int last_index = obj.MyFindLastIndexGeneric(list_double, x => x > 0);

            List<int> double_size = list.Select(_ => _ * 2).ToList();

            //take list of double
            //take the double {-0.979,4.1232,3.17,80.0}
            //with: original, AbsValue, Power2
            //print this list --> try to do all this in one line

            var res1 = new List<double>() { -0.979, 4.1232, 3.17, 80.0 }.Select(_ => new { Original = _, Abs = Math.Abs(_), 
                                                                      Pow2 = Math.Pow(_, 2) });
            res1.ToList().ForEach(_ => { Console.WriteLine($"{_.Original} {_.Abs} {_.Pow2}"); });
        }
    }
}
