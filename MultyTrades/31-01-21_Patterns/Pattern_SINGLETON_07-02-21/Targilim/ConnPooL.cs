using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theoria_Dot_Net
{
    public class DbConnection
    {

    }

    class ConnPooL
    {
        private const int MAX = 10;
        private List<DbConnection> m_connections;
        private object conn_key = new object();
        public DbConnection GetConnection()
        {
            lock (conn_key)
            {
                if (m_connections.Count > 0)
                {
                    DbConnection result = m_connections[m_connections.Count - 1];
                    m_connections.RemoveAt(m_connections.Count - 1);
                    return result;
                }
            }
            return null;
        }
        public void ReturnConnection(DbConnection conn)
        {
            lock (conn_key)
            {
                m_connections.Add(conn);
            }
        }

        // 1
        private ConnPooL()
        {
            m_connections = new List<DbConnection>();
            for (int i = 0; i < MAX; i++)
            {
                m_connections.Add(new DbConnection());
            }
        }

        // 2
        private static ConnPooL Instance;
        // 3
        private static object key = new object();
        // 4
        public static ConnPooL GetInstance()
        {
            if (Instance == null)
            {
                lock (key)
                {
                    if (Instance == null)
                    {
                        Instance = new ConnPooL();
                    }
                }
            }
            return Instance;
        }
    }

   

}

