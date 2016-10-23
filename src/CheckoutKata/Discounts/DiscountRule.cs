using System.Collections.Generic;
using CheckoutKata.Catalogue;

namespace CheckoutKata.Discounts
{
    /// <summary>
    /// Discount that applies directly to a single sku
    /// </summary>
    public class DiscountRule
    {
        public DiscountRule(string skuCode, int breakQuantity, decimal discountedUnitPrice)
        {
            SkuCode = skuCode;
            BreakQuantity = breakQuantity;
            DiscountedUnitPrice = discountedUnitPrice;
        }

        public string SkuCode { get; }

        public int BreakQuantity { get; }

        public decimal DiscountedUnitPrice { get; }

        public IEnumerable<SkuDiscountResultLine> CalculateDiscount(Sku sku, int quantity)
        {
            if (sku.Code == SkuCode)
            {
                int discountedQuantity = quantity/BreakQuantity * BreakQuantity;
                yield return new SkuDiscountResultLine(sku, discountedQuantity, DiscountedUnitPrice, this);
                int remainingQuantity = quantity % BreakQuantity;
                if (remainingQuantity > 0)
                {
                    yield return new SkuDiscountResultLine(sku, remainingQuantity, sku.UnitPrice, null);
                }
            }
        }
    }
}