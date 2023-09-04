using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendorMachine
{
    internal class VendorProcessProductMethod : State
    {

        public override decimal ProcessPayment(Product product, decimal paymentAmoun, Stock stock)
        {
            Console.WriteLine("already inserted money ,now processing product");
            return 0;
        }

        public override Product ProcessProduct(Product product)
        {
            if (product != null)
                if (product is Drink)
                {
                    Enum.TryParse(product.Name, out ProductType productType);
                    DrinkBuilder builder;
                    switch (productType)
                    {
                        case ProductType.IceCoffee:
                            builder = new IceCofeeBuilder(product as Drink);
                            break;
                        case ProductType.OrangeJuice:
                            builder = new OrangeJuiceBuilder(product as Drink);
                            break;
                        case ProductType.Cocoa:
                            builder = new CocoaBuilder(product as Drink);
                            break;
                        case ProductType.Cappuchino:
                            builder = new CappuchinoBuilder(product as Drink);
                            break;
                        case ProductType.Tea:
                            builder = new TeaBuilder(product as Drink);
                            break;
                        default:builder= null;
                            break;

                    }
                    DrinkDirector drinkDirector = new ();
                    return drinkDirector.ConstructDrink(builder);
                }
            return product;
        }

        public override Product SelectProduct(string pro, Stock stock, bool bag, bool gift)
        {
            Console.WriteLine("alrady selcted product and payd for it ,now procesing it");
           return null;
        }
    }
}
