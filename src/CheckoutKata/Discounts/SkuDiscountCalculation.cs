namespace CheckoutKata.Discounts
{
    /// <summary>
    /// Contains result of applying discount to total quantity of a given sku within the order.
    /// </summary>
    public class SkuDiscountCalculation
    {
        public SkuDiscountCalculation(int quantity, int discountedQuantity, decimal discountedUnitPrice, DiscountRule rule)
        {
            Quantity = quantity;
            DiscountedQuantity = discountedQuantity;
            DiscountedUnitPrice = discountedUnitPrice;
            Rule = rule;
        }

        public int Quantity { get; }

        public int DiscountedQuantity { get; set; }

        public decimal DiscountedUnitPrice { get; }

        public DiscountRule Rule { get; }
    }
}