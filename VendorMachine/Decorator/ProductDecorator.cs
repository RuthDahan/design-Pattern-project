using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendorMachine;

namespace VendorMachine.Decorator
{
    public class ProductDecorator
    {
        protected Product product;

        public ProductDecorator(Product product)
        {
            this.product = product;
        }
    }
}
