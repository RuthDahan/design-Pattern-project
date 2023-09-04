using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendorMachine
{
    public class VendorPaymentMethod : State
    {

        private IStockObserver stockObserver;

        private const int NOTIFY_PROVIDER = 5;
        public VendorPaymentMethod()
        {
            stockObserver = new StockObserver();

        }


        public override decimal ProcessPayment(Product product, decimal paymentAmount, Stock stock)
        {
            decimal changeAmount = paymentAmount - product.Price;
            if (changeAmount >= 0)
            {
                ProductType p;
                var productType = Enum.TryParse(product.Name, out p);
                int amountLeft = stock.CountProductStock(p, product);
                // Check stock amount and notify provider if it's less than 5
                if (amountLeft < NOTIFY_PROVIDER)
                {
                    ProviderDetails? providerDetails = stock.GetProvider(p);
                    if (providerDetails != null)
                    {
                        stockObserver.NotifyLowStock(product, providerDetails);
                    }

                }
                this._vendor.TransitionTo(new VendorProcessProductMethod());
            }
            return changeAmount;
        }

        public override Product? ProcessProduct(Product product)
        {
            Console.WriteLine("not payed,canot procees it");
            return null;
        }

        public override Product? SelectProduct(string pro, Stock stock, bool bag, bool gift)
        {
            Console.WriteLine("selected product already");
            return null;
        }
        
    }
}






