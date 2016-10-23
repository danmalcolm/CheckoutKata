using System.Collections.Generic;
using System.Linq;

namespace CheckoutKata.Tests
{
    public class TestSkuRepository : ISkuRepository
    {
        private readonly List<Sku> skus = new List<Sku>();

        public void Add(Sku sku)
        {
            skus.Add(sku);
        }

        public Sku FindByCode(string code)
        {
            return skus.FirstOrDefault(x => x.Code == code);
        }
    }
}