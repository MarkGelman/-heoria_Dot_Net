using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankEvents
{
    public class Ariela
    {
        public event EventHandler<PersonDetailsEventArgs> WonWeekend;

        public void NotofyWhoWonWeekeend(string name, string mobile)
        {
            if (WonWeekend != null)
            {
                WonWeekend.Invoke(this, new PersonDetailsEventArgs
                {
                    Name = name,
                    MobileNumber = mobile
                });
            }
        }
        public void PlayLotto()
        {
            /// .......................
            NotofyWhoWonWeekeend("Rubi", "057-1267832");
        }
    }
}

