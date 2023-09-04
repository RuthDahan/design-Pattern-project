using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendorMachine
{
    public class StockObserver : IStockObserver
    {
        public  void NotifyLowStock(Product product, ProviderDetails providerDetails)
        {
            MessageBox.Show($"Low stock for {product.Name}. Notifying provider{providerDetails.Name}");
            // Logic to notify the provider
        }
    }
}
