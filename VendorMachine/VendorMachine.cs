using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace VendorMachine
{
    public class VendorMachine
    {
        private Product? product;
        private decimal payed;
        private State? _state = null;
        private Form1 _form1;
        private readonly Stock stock;
        private PaymentHistory paymentHistory;

        public VendorMachine(State state, Form1 form1)
        {
            this.TransitionTo(state);
            stock = new Stock();
            paymentHistory = new PaymentHistory();
            Initalstock();
            SendReport();
            _form1 = form1;
        }
        public void TransitionTo(State state)
        {

            this._state = state;
            _state.SetVendor(this);
        }
        public Product SelectProduct(string pro, bool bag, bool gift)
        {

            product = _state.SelectProduct(pro, stock, bag, gift);
            TransitionTo(new VendorPaymentMethod());
            return product;
        }
        public decimal ProcessPayment(decimal paymentAmount)
        {
            payed = paymentAmount;
            decimal change = _state.ProcessPayment(product, payed, stock);
            return change;
        }
        public Product ProcessProduct()
        {
            product = this._state.ProcessProduct(product);
            PaymentState paymentState = new() { Date = DateTime.Now, BoughtProduct = product, PayedAmount = payed };
            paymentHistory.AddPaymentState(paymentState);
            this._state = new VendorSelectionMethod();
            return product;
        }
        public void SendReport()
        {
            string reportType = "text";
            DailyReportBuilder reportBuilder = reportType switch
            {
                "text" => new TextFileReportBuilder(),
                _ => new TextFileReportBuilder(),
            };
            ReportDirector reportDirector = new(reportBuilder, paymentHistory);
            ReportScheduler reportScheduler = new(reportDirector);
            reportScheduler.ScheduleReportSending();
        }
        public void Initalstock()
        {
            Product p = new Product() { Name = "Bisly", Price = 5 };
            Product p1 = new Product() { Name = "Bisly", Price = 5 };
            Product p2 = new Product() { Name = "Bisly", Price = 5 };
            Product p3 = new Product() { Name = "Bisly", Price = 5 };
            Product p4 = new Product() { Name = "Bisly", Price = 5 };
            Product s = new Product() { Name = "Choclate", Price = 7 };
            Product s1 = new Product() { Name = "Choclate", Price = 7 };
            Product s2 = new Product() { Name = "Choclate", Price = 7 };
            Product s3 = new Product() { Name = "Choclate", Price = 7 };
            Product s4 = new Product() { Name = "Choclate", Price = 7 };
            Product s5 = new Drink() { Name = "Cocoa", Price = 15 };
            Product s6 = new Drink() { Name = "OrangeJuice", Price = 15 };
            Product s7 = new Drink() { Name = "Tea", Price = 15 };
            Product s8 = new Drink() { Name = "Cappuchino", Price = 15 };
            Product s9 = new Drink() { Name = "IceCoffee", Price = 15 };
            stock.AddProduct(ProductType.Bisly, p);
            stock.AddProduct(ProductType.Bisly, p);
            stock.AddProduct(ProductType.Bisly, p);
            stock.AddProduct(ProductType.Bisly, p1);
            stock.AddProduct(ProductType.Bisly, p2);
            stock.AddProduct(ProductType.Bisly, p3);
            stock.AddProduct(ProductType.Bisly, p4);
            ProviderDetails pd = new() { Name = "Osem" };
            stock.SetProvider(ProductType.Bisly, pd);
            stock.AddProduct(ProductType.Choclate, s);
            stock.AddProduct(ProductType.Choclate, s1);
            stock.AddProduct(ProductType.Choclate, s2);
            stock.AddProduct(ProductType.Choclate, s3);
            stock.AddProduct(ProductType.Choclate, s4);
            ProviderDetails ps = new() { Name = "Osem" };
            stock.SetProvider(ProductType.Choclate, ps);
            stock.AddProduct(ProductType.Cocoa, s5);
            stock.AddProduct(ProductType.OrangeJuice, s6);
            stock.AddProduct(ProductType.Tea, s7);
            stock.AddProduct(ProductType.Cappuchino, s8);
            stock.AddProduct(ProductType.IceCoffee, s9);
            ProviderDetails pa = new() { Name = "Tnuva" };
            ProviderDetails pt = new() { Name = "Semitzki" };
            ProviderDetails pp = new() { Name = "Prigat" };
            stock.SetProvider(ProductType.Tea, pt);
            stock.SetProvider(ProductType.Cocoa, pa);
            stock.SetProvider(ProductType.OrangeJuice, pp);
            stock.SetProvider(ProductType.Cappuchino, pa);
            stock.SetProvider(ProductType.IceCoffee, pa);






        }


    }
}
