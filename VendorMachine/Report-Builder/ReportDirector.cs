using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendorMachine
{
    public class ReportDirector
    {
        private DailyReportBuilder reportBuilder;
        private PaymentHistory paymentHistory;
        public ReportDirector(DailyReportBuilder builder, PaymentHistory paymentHistory)
        {
            reportBuilder = builder;
            this.paymentHistory = paymentHistory;
        }

        public void ConstructReport()
        {
            reportBuilder.CreateReport(paymentHistory);
            paymentHistory.paymentStates.Clear();
        }
    }
}
