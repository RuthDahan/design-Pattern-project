using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendorMachine
{
    public class PaymentHistory
    {
        public List<PaymentStateMemento> paymentStates;

        public PaymentHistory()
        {
            paymentStates = new List<PaymentStateMemento>();
        }

        public void AddPaymentState(PaymentState state)
        {
            paymentStates.Add(new PaymentStateMemento(state));
        }

        public PaymentStateMemento GetLatestPaymentState()
        {
            if (paymentStates.Count > 0)
                return paymentStates[paymentStates.Count - 1];
            else
                return null;
        }
    }
}