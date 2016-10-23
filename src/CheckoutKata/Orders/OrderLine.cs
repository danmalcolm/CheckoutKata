namespace CheckoutKata.Orders
{
    /// <summary>
    /// Contains details of an individual line within an order
    /// </summary>
    public class OrderLine
    {
        public OrderLine(string skuCode, int quantity, decimal originalUnitPrice, decimal unitDiscount, string discountDescription)
        {
            SkuCode = skuCode;
            Quantity = quantity;
            OriginalUnitPrice = originalUnitPrice;
            UnitDiscount = unitDiscount;
            DiscountDescription = discountDescription;
        }

        /// <summary>
        /// Code identifying the Sku
        /// </summary>
        public string SkuCode { get; }

        /// <summary>
        /// Number of Skus
        /// </summary>
        public int Quantity { get; }

        /// <summary>
        /// The standard unit price for the Sku
        /// </summary>
        public decimal OriginalUnitPrice { get; }

        public decimal UnitDiscount { get; set; }

        public string DiscountDescription { get; set; }

        /// <summary>
        /// The unit price for the Sku in this order line including discounts
        /// </summary>
        public decimal UnitPrice => OriginalUnitPrice - UnitDiscount;

        public decimal TotalPrice => UnitPrice * Quantity;
    }
}