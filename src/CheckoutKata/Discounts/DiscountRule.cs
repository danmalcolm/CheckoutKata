using System.Collections.Generic;
using CheckoutKata.Catalogue;

namespace CheckoutKata.Discounts
{
    /// <summary>
    /// Discount that applies directly to a single sku
    /// </summary>
    public class DiscountRule
    {
        public DiscountRule(string skuCode, int quantity, decimal discountedUnitPrice)
        {
            SkuCode = skuCode;
            Quantity = quantity;
            DiscountedUnitPrice = discountedUnitPrice;
        }

        public string SkuCode { get; }

        public int Quantity { get; }

        public decimal DiscountedUnitPrice { get; }

        public IEnumerable<SkuDiscountResultLine> CalculateDiscount(Sku sku, int quantity)
        {
            yield break;
        }
    }
}