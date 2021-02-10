using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Theoria_Dot_Net
{
    public class Pattern_Queue
    {
        List<Action> m_queue = new List<Action>();

        List<Thread> m_workers;

        object key = new object();

        public int Count
        {
            get
            {
                return m_queue.Count;
            }
        }

        public void Consume()
        {
            // critical section
            // lock -- Monitor.Enter
            Action work_func = null;
            lock (key)
            {
                while (m_queue.Count == 0)
                {
                    Thread.Yield();
                    
                }
                work_func = m_queue[m_queue.Count - 1]; // 1
                m_queue.RemoveAt(m_queue.Count - 1); // 1
            }
            work_func.Invoke();
        }
        public Pattern_Queue()
        {

        }
        public Pattern_Queue(int num_workers)
        {
            m_workers = new List<Thread>();
            for (int i = 0; i < num_workers; i++)
            {
                Thread one_thread = new Thread(Consume);
                //one_thread.IsBackground = true;
                m_workers.Add(one_thread);
                m_workers[i].Start();
            }
        }

        public void Produce(Action work)
        {
            m_queue.Insert(0, work);
        }
    }
}

