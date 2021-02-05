using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankEvents
{
    public class BuyHouseCommercial
    {
        public void CallCustomerPassed1M(object sender, PersonDetailsEventArgs e)
        {
            Console.WriteLine($"Call and suggest house for {e.Name} number {e.MobileNumber}");
        }
        public void Register1MWithBank(Bank b)
        {
            b.PassedMillion += CallCustomerPassed1M;
        }
    }
}

