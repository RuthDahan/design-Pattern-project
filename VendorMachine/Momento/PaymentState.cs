using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendorMachine
{
    public class PaymentState
    {
        public DateTime Date { get; set; }
        public Product? BoughtProduct { get; set; }
        public decimal ? PayedAmount { get; set; }
        // Additional properties and methods related to payment state
    }
}
