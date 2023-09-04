using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendorMachine;

namespace VendorMachine.Decorator
{
    public class BagDecorator : ProductDecorator
    {
        public BagDecorator(Product product) : base(product)
        {
            this.product.Price += 2;
        }
    }
}
