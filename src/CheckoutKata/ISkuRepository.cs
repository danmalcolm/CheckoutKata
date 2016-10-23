namespace CheckoutKata
{
    /// <summary>
    /// Provides access to Sku objects
    /// </summary>
    public interface ISkuRepository
    {
        Sku FindByCode(string code);
    }
}