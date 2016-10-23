using System.Collections.Generic;
using CheckoutKata.Catalogue;

namespace CheckoutKata
{
    public class CheckoutCalculator
    {
        private readonly ISkuRepository repository;
        private readonly Order order;

        public CheckoutCalculator(ISkuRepository repository)
        {
            this.repository = repository;
            order = new Order();
        }

        public void AddSku(string skuCode)
        {
            var sku = repository.FindByCode(skuCode);
            order.AddSku(sku);
        }

        public decimal TotalSkuPrice => order.TotalPrice;
    }
}