using CheckoutKata.Catalogue;

namespace CheckoutKata.Discounts
{
    /// <summary>
    /// Contains result of applying discount to the skus within an order
    /// </summary>
    public class SkuDiscountResultLine
    {
        public SkuDiscountResultLine(Sku sku, int quantity, decimal discountedUnitPrice, DiscountRule rule)
        {
            Sku = sku;
            Quantity = quantity;
            DiscountedUnitPrice = discountedUnitPrice;
            Rule = rule;
        }

        public Sku Sku { get; }

        public int Quantity { get; }

        public decimal DiscountedUnitPrice { get; }

        public DiscountRule Rule { get; }
    }
}