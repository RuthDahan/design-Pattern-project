using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendorMachine.Decorator;
namespace VendorMachine
{
    public class VendorSelectionMethod : State
    {

        public override Product SelectProduct(string pro, Stock stock, bool bag, bool gift)
        {


            ProductType productType;
            Enum.TryParse(pro, out productType);
            var product = stock.GetProduct(productType);
            

            if (bag & gift)
            {
                new GiftDecorator(product);
                new BagDecorator(product);
                
            }
            if (gift) {
                 new GiftDecorator(product);
                
            }
            if (bag) {
               new BagDecorator(product);
                
            }

            return product;

        }
        public override decimal ProcessPayment(Product product, decimal paymentAmount, Stock stock)
        {
            Console.WriteLine("Payment is not allowed without selecting a product.");
            return 0;
        }

        public override Product ProcessProduct(Product product)
        {
            Console.WriteLine("Process is not allowd before selecting and payment");
            return null;
        }
    }
}