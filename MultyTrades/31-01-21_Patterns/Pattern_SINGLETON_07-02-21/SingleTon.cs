using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theoria_Dot_Net._31_01_21_Patterns
{
    class SingleTon
    {
        public class ClockSingleton
        {
            private static ClockSingleton Instance;
            private static object key = new object();
            public static ClockSingleton GetInstance()
            {
                if (Instance == null)
                {
                    lock (key)
                    {
                        if (Instance == null)
                        {
                            Instance = new ClockSingleton();
                        }
                    }
                }
                return Instance;
            }

            private ClockSingleton()
            {

            }

            public DateTime GetDateTimeByRegion()
            {
                return DateTime.Now; // should do something smart ...
            }
        }

    }
}
