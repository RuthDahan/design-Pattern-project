using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendorMachine
{
    public class Stock
    {
        private Dictionary<ProductType, List<Product>> products = new Dictionary<ProductType, List<Product>>();
        private Dictionary<ProductType, ProviderDetails> providers = new Dictionary<ProductType, ProviderDetails>();
        

        public void AddProduct(ProductType type, Product product)
        {
            if (!products.ContainsKey(type))
                products[type] = new List<Product>() { };

            products[type].Add(product);
        }
        public Product? GetProduct(ProductType type)
        {
            if (products.ContainsKey(type))
                if (products[type].Count > 0)
                {
                    var GetP = products[type].ElementAt(0);
                    products[type].Remove(GetP);
                    return GetP;
                }

            return null;
        }
        public int CountProductStock(ProductType type, Product product)
        {
            int count = 0;
            if (products.ContainsKey(type))
                if (products[type].Contains(product))
                    count = products[type].Count;
            return count;
        }
        public ProviderDetails? GetProvider(ProductType type)
        {
            if (providers.ContainsKey(type))
                return providers[type];
            return null;
        }
        public void SetProvider(ProductType type, ProviderDetails provider)
        {
            providers[type] = provider;
        }
    }
}

