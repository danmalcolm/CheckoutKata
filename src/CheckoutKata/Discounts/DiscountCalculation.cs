using System.Collections.Generic;

namespace CheckoutKata.Discounts
{
    /// <summary>
    /// Contains results of calculating discounts on an order
    /// </summary>
    public class DiscountCalculation
    {
        public DiscountCalculation(List<SkuDiscountResultLine> lines)
        {
            Lines = lines;
        }

        public List<SkuDiscountResultLine> Lines { get; }
    }
}