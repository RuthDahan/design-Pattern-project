using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendorMachine
{
    public interface IStockObserver
    {
         void NotifyLowStock(Product product, ProviderDetails providerDetails);
    }

}
