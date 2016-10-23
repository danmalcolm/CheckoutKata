using System.Linq;
using CheckoutKata.Orders;
using FluentAssertions;
using Xunit;

namespace CheckoutKata.Tests
{
    public class OrderTests
    {
        [Fact]
        public void should_add_orderlines()
        {
            var order = new Order();
            order.AddSku(TestSkus.SkuA);
            order.AddSku(TestSkus.SkuB);

            var expected = new[]
            {
                new {SkuCode = TestSkus.SkuA.Code, UnitPrice = TestSkus.SkuA.UnitPrice, Quantity = 1},
                new {SkuCode = TestSkus.SkuB.Code, UnitPrice = TestSkus.SkuB.UnitPrice, Quantity = 1}
            };
            order.OrderLines.ShouldAllBeEquivalentTo(expected, options => options.ExcludingMissingMembers());
        }

        [Fact]
        public void should_calculate_total_of_orderlines()
        {
            var order = new Order();
            order.AddSku(TestSkus.SkuA);
            order.AddSku(TestSkus.SkuB);

            order.TotalPrice.Should().Be(TestSkus.SkuA.UnitPrice + TestSkus.SkuB.UnitPrice);
        }
    }
}