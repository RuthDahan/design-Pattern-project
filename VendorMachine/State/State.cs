using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendorMachine
{
    public abstract class State
    {
        public VendorMachine _vendor ;

        public void SetVendor(VendorMachine vendor)
        {
            this._vendor = vendor;
        }

        public abstract Product SelectProduct(string pro,Stock stock, bool bag,bool gift);
        public abstract decimal ProcessPayment(Product product, decimal paymentAmoun,Stock stock);
        public abstract Product ProcessProduct(Product product);

    }
}
