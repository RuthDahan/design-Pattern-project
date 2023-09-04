using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendorMachine;

namespace VendorMachine.Decorator
{
    public class GiftDecorator : ProductDecorator
    {
        public GiftDecorator(Product product) : base(product)
        {
            this.product.Price += 4;
        }
    }
}
