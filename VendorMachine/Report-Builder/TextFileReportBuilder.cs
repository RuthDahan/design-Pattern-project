using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendorMachine
{
    public class TextFileReportBuilder : DailyReportBuilder
    {
        protected override void AddHeader()
        {
            reportLines.Add("-------- Daily Report --------");
        }

        protected override void AddContent(PaymentHistory paymentHistories)
        {
            foreach (var payment in paymentHistories.paymentStates)
            {
                reportLines.Add( $"Date: {payment.State.Date}:Product: {payment.State.BoughtProduct.Name} Price:{payment.State.BoughtProduct.Price},PricePayment : {payment.State.PayedAmount},Change Given:{(payment.State.PayedAmount - payment.State.BoughtProduct.Price)}\n");
                
            }
        }

        protected override void AddFooter()
        {
            reportLines.Add("-------------------------------");
        }

        protected override void SaveReportToFile()
        {
            File.WriteAllLines("C:\\Users\\user\\Desktop\\try\\VendorMachine\\daily_report.txt", reportLines);
            Console.WriteLine("Report saved to daily_report.txt");
        }
    }
}
