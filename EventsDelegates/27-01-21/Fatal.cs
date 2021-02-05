
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankEvents
{
    public class Fatal
    {
        public void GiveFreeWeekend(object sender, PersonDetailsEventArgs e)
        {
            // give weekend for promotion (marketing)
            // Name
            // Mobile phone
            if (sender is Bank)
            {
                Console.WriteLine($"{e.Name} is getting free weekend from Bank.. calling {e.MobileNumber}");
            }
            else
            {
                Console.WriteLine($"{e.Name} is getting free weekend .. calling {e.MobileNumber}");
            }

        }

        public void RegisterBankWithFreeWeekend(Bank b)
        {
            b.PassedMillion += GiveFreeWeekend;

            // forbidden in Events
            //b.PassedMillion = GiveFreeWeekend;
            //b.PassedMillion(null, EventArgs.Empty);
        }
        public void RegisterBankWithFreeWeekend(Ariela a)
        {
            a.WonWeekend += GiveFreeWeekend;
        }
        public void DettachFromBankFreeWeekend(Bank b)
        {
            b.PassedMillion -= GiveFreeWeekend;
        }
    }
}

