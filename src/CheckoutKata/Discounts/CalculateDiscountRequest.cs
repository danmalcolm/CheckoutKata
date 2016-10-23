using System.Collections.Generic;
using CheckoutKata.Catalogue;

namespace CheckoutKata.Discounts
{
    public class CalculateDiscountRequest
    {
        public List<DiscountRequestSkuData> Skus { get; }
    }

    public class DiscountRequestSkuData
    {
        public Sku Sku { get; }

        public int TotalQuantity { get; }
    }
}