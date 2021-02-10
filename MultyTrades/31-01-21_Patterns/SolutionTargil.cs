using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theoria_Dot_Net
{
    class SolutionTargil
    {
        List<int> numbers = new List<int>();
        public object key = new object();
        //public object key2 = new object();

        public void Push(int item)
        {
            lock (key)
            {
                numbers.Insert(0, item);
                Console.WriteLine($"Push {item}");
            }
        }
        public int Pop()
        {
            int result = 0;
            lock (key)
            {
                result = numbers[numbers.Count - 1];
                numbers.RemoveAt(0);
                Console.WriteLine($"Remove {result}");
            }
            return result;
        }
        public int Peep()
        {
            int result = 0;
            lock (key)
            {
                result = numbers[numbers.Count - 1];
                Console.WriteLine($"Peep {result}");
            }
            return result;
        }
        public void Clear()
        {
            lock (key)
            {
                numbers.Clear();
            }
        }
        public int Counter
        {
            get
            {
                int counter = 0;
                lock (key)
                {
                    counter = numbers.Count;
                }
                return counter;
            }
        }

    }
}
