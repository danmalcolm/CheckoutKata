using System.Linq;
using CheckoutKata.Catalogue;
using CheckoutKata.Orders;
using FluentAssertions;
using Xunit;

namespace CheckoutKata.Tests
{
    public class OrderTests
    {
        private Sku skuA = TestSkus.SkuA;
        private Sku skuB= TestSkus.SkuB;

        [Fact]
        public void should_add_sku_details_to_orderline()
        {
            var order = new Order();
            order.AddOrderLine(TestSkus.SkuA, 3, 0, "");
            order.AddOrderLine(TestSkus.SkuB, 4, 0, "");

            var expected = new[]
            {
                new {SkuCode = skuA.Code, OriginalUnitPrice = skuA.UnitPrice, UnitPrice = skuA.UnitPrice, Quantity = 3},
                new {SkuCode = skuB.Code, OriginalUnitPrice = skuB.UnitPrice, UnitPrice = skuB.UnitPrice, Quantity = 4}
            };
            order.OrderLines.ShouldAllBeEquivalentTo(expected, options => options.ExcludingMissingMembers());
        }

        [Fact]
        public void non_discounted_orderlines_should_not_have_discounted_total_price()
        {
            var order = new Order();
            order.AddOrderLine(skuA, 3, 0, "");

            var expected = new[]
            {
                new {SkuCode = skuA.Code, OriginalUnitPrice = skuA.UnitPrice, UnitPrice = skuA.UnitPrice, UnitDiscount = 0, TotalPrice = skuA.UnitPrice * 3 }
            };
            order.OrderLines.ShouldAllBeEquivalentTo(expected, options => options.ExcludingMissingMembers());
        }

        [Fact]
        public void discounted_orderlines_should_include_discounted_price_and_discount_details()
        {
            var order = new Order();
            order.AddOrderLine(skuA, 3, 10, "3 for 120");

            var expected = new[]
            {
                new {SkuCode = skuA.Code, OriginalUnitPrice = skuA.UnitPrice, UnitPrice = 40m, UnitDiscount = 10m, TotalPrice = 120, DiscountDescription = "3 for 120" }
            };
            order.OrderLines.ShouldAllBeEquivalentTo(expected, options => options.ExcludingMissingMembers());
        }
    }
}