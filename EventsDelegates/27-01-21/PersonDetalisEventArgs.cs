using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankEvents
{
    public class PersonDetailsEventArgs : EventArgs
    {
        public string Name { get; set; }
        public String MobileNumber { get; set; }
    }
}

