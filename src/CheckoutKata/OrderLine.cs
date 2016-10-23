namespace CheckoutKata
{
    /// <summary>
    /// Contains details of an individual line within an order
    /// </summary>
    public class OrderLine
    {
        public OrderLine(string skuCode, int quantity, decimal unitPrice)
        {
            SkuCode = skuCode;
            Quantity = quantity;
            UnitPrice = unitPrice;
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
        public decimal UnitPrice { get; }

        public decimal TotalPrice => UnitPrice * Quantity;
    }
}