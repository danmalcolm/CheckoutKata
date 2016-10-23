using System.Collections.Generic;

namespace CheckoutKata.Tests
{
    /// <summary>
    /// Know set of Skus set up for use in tests
    /// </summary>
    public static class TestSkus
    {
        public static readonly Sku SkuA = new Sku("A", 50m);
        public static readonly Sku SkuB = new Sku("B", 30m);
        public static readonly Sku SkuC = new Sku("C", 60m);
        public static readonly Sku SkuD = new Sku("D", 99m);

        public static IEnumerable<Sku> All => new[] {SkuA, SkuB, SkuC, SkuD};
    }
}