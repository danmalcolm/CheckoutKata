using System.Collections.Generic;
using CheckoutKata.Catalogue;
using CheckoutKata.Discounts;
using CheckoutKata.Orders;
using System.Linq;
using System.Runtime.InteropServices;

namespace CheckoutKata
{
    public class CheckoutCalculator
    {
        private readonly ISkuRepository repository;
        private readonly IDiscountRuleCache discountRuleCache;
        private readonly List<Sku> skus = new List<Sku>();

        public CheckoutCalculator(ISkuRepository repository, IDiscountRuleCache discountRuleCache)
        {
            this.repository = repository;
            this.discountRuleCache = discountRuleCache;
        }

        public void AddSku(string skuCode)
        {
            var sku = repository.FindByCode(skuCode);
            skus.Add(sku);
        }

        public Order GetOrder()
        {
            var skuQuantities = from sku in skus
                group sku by sku
                into bySku
                select new {Sku = bySku.Key, Quantity = bySku.Count()};

            var order = new Order();
            foreach (var skuQuantity in skuQuantities)
            {
                var sku = skuQuantity.Sku;
                int quantity = skuQuantity.Quantity;
                int discountedQuantity = 0;
                var discount = discountRuleCache.ActiveRules
                    .Select(x => x.CalculateDiscount(sku.Code, quantity))
                    .FirstOrDefault(x => x != null);
                if (discount != null)
                {
                    decimal unitDiscount = sku.UnitPrice - discount.DiscountedUnitPrice;
                    order.AddOrderLine(sku, discount.DiscountedQuantity, unitDiscount, discount.Rule.Description);
                    discountedQuantity = discount.DiscountedQuantity;
                }
                int remainingQuantity = quantity - discountedQuantity;
                if (remainingQuantity > 0)
                {
                    order.AddOrderLine(sku, remainingQuantity, 0m, "");
                }
            }
            return order;
        }
    }
}