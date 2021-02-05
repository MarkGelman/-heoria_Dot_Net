using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankEvents
{
    public class Bank
    {
        public event EventHandler<PersonDetailsEventArgs> PassedMillion;

        private List<Customer> m_customers = new List<Customer>();

        public void AddCustomer(Customer c)
        {
            m_customers.Add(c);
        }

        // Firing point!
        public void PassedTheMillionBanace(Customer c)
        {
            if (PassedMillion != null)
            {
                PassedMillion(this, new PersonDetailsEventArgs
                {
                    MobileNumber = c.MobileNumber,
                    Name = c.Name
                });
            }
        }
        public void Deposite(Customer c, double amount)
        {
            c.Balance += amount;
            if (c.Balance > 1_000_000 && !c.GotPriceForOver1M)
            {
                // Passed the 1M
                PassedTheMillionBanace(c);
            }
        }
        public void GetRefund(Customer c, double refund)
        {
            c.Balance += refund;
            if (c.Balance > 1_000_000 && !c.GotPriceForOver1M)
            {
                // Passed the 1M
                PassedTheMillionBanace(c);
            }
        }
    }
}

