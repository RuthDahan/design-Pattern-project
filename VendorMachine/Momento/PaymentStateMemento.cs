using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendorMachine
{
    public class PaymentStateMemento
    {
        public PaymentState State { get; private set; }

        public PaymentStateMemento(PaymentState state)
        {
            State = state;
        }
    }
}
