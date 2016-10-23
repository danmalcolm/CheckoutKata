using System.Collections.Generic;

namespace CheckoutKata
{
    public class CheckoutCalculator
    {
        private readonly ISkuRepository repository;

        public CheckoutCalculator(ISkuRepository repository)
        {
            this.repository = repository;
        }

        public void AddSku(string skuCode)
        {
            var sku = repository.FindByCode(skuCode);
            TotalSkuPrice += sku.UnitPrice;
        }

        public decimal TotalSkuPrice { get; private set; }
    }
}