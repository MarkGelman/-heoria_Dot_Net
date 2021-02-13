using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultyTrades._31_01_21_Patterns.Pool_Pattern_10_02_21
{
    class Solution_Targil_PoolPattern
    {
        public class MyFileManager
        {

            public const string FILE_PATH = @"d:\temp\demo.txt";
            object key = new object();

            private static MyFileManager m_Instance;
            private static object sin_key = new object();
            public static MyFileManager Instance
            {
                get
                {
                    if (m_Instance == null)
                    {
                        lock (sin_key)
                        {
                            if (m_Instance == null)
                            {
                                m_Instance = new MyFileManager();
                            }
                        }
                    }
                    return m_Instance;
                }
            }

            private MyFileManager()
            {

            }

            public void WriteToFile(string text)
            {
                try
                {
                    Monitor.Enter(key);
                    while (!File.Exists(FILE_PATH))
                    {
                        Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} will wait");
                        Monitor.Wait(key);
                    }
                    Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} done waiting");

                    File.AppendAllText(FILE_PATH, text);
                }
                finally
                {
                    Monitor.Exit(key);
                }
            }
            public void CreateFile()
            {
                try
                {
                    Monitor.Enter(key);

                    if (!File.Exists(FILE_PATH))
                    {
                        Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} will create the file");
                        var fs = File.Create(FILE_PATH);
                        fs.Close();
                    }
                    Thread.Sleep(50);
                    Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} will Pulase all");
                    Monitor.PulseAll(key); // free all waiting threads (in write_to_file)
                }
                finally
                {
                    Monitor.Exit(key);
                }
            }
            public void DeleteFile()
            {
                try
                {
                    Monitor.Enter(key);
                    if (File.Exists(FILE_PATH))
                    {
                        Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} will delete the file");
                        File.Delete(FILE_PATH);
                    }
                }
                finally
                {
                    Monitor.Exit(key);
                }
            }
        }

    }
}
