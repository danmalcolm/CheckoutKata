namespace CheckoutKata
{
    /// <summary>
    /// Represents an individual "stock keeping unit" sold by the system
    /// </summary>
    public class Sku
    {
        public Sku(string code, decimal unitPrice)
        {
            Code = code;
            UnitPrice = unitPrice;
        }

        public string Code { get; }

        public decimal UnitPrice { get; }
    }
}