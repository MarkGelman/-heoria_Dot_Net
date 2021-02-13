using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultyTrades._31_01_21_Patterns.Pool_Pattern_10_02_21
{
    class PoolPattern
    {
        public class MyDbConnection
        {

        }
        public class MyConnectionPool
        {
            // Singeton
            Queue<MyDbConnection> m_connections = new Queue<MyDbConnection>();
            public const int MAX_CONNECTIONS = 40;
            private object key = new object();

            private static MyConnectionPool m_Instance;
            private static object key_singleton = new object();

            public static MyConnectionPool Instance
            {
                get
                {
                    if (m_Instance == null)
                    {
                        lock (key_singleton)
                        {
                            if (m_Instance == null)
                            {
                                m_Instance = new MyConnectionPool();
                            }
                        }
                    }
                    return m_Instance;
                }
            }

            private MyConnectionPool()
            {
                for (int i = 0; i < MAX_CONNECTIONS; i++)
                {
                    m_connections.Enqueue(new MyDbConnection());
                }
            }

            public MyDbConnection GetConnection()
            {
                try
                {
                    Monitor.Enter(key);
                    while (m_connections.Count == 0)
                    {
                        Monitor.Wait(key);
                    }
                    var conn = m_connections.Dequeue();
                    return conn;
                }
                finally
                {
                    Monitor.Exit(key);
                }
            }

            public void RestoreConnection(MyDbConnection conn)
            {
                try
                {
                    Monitor.Enter(key);
                    m_connections.Enqueue(conn);
                }
                finally
                {
                    Monitor.Exit(key);
                }
            }
        }

    }
}
