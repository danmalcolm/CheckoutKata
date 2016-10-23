using System.Collections.Generic;
using CheckoutKata.Catalogue;

namespace CheckoutKata.Discounts
{
    /// <summary>
    /// Discount that applies directly to a single sku
    /// </summary>
    public class DiscountRule
    {
        public DiscountRule(string skuCode, int breakQuantity, decimal discountedUnitPrice, string description)
        {
            SkuCode = skuCode;
            BreakQuantity = breakQuantity;
            DiscountedUnitPrice = discountedUnitPrice;
            Description = description;
        }

        public string SkuCode { get; }

        public int BreakQuantity { get; }

        public decimal DiscountedUnitPrice { get; }

        public string Description { get; }

        public SkuDiscountCalculation CalculateDiscount(string skuCode, int quantity)
        {
            if (skuCode == SkuCode)
            {
                int discountedQuantity = quantity / BreakQuantity * BreakQuantity;
                return new SkuDiscountCalculation(quantity, discountedQuantity, DiscountedUnitPrice, this);
            }
            else
            {
                return null;
            }
        }
    }
}