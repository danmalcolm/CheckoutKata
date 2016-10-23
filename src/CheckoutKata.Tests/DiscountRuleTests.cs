using System.Linq;
using CheckoutKata.Discounts;
using FluentAssertions;
using Xunit;

namespace CheckoutKata.Tests
{
    public class DiscountRuleTests
    {
        [Fact]
        public void should_apply_discounts_to_skus_matching_quantity()
        {
            var rule = new DiscountRule(TestSkus.SkuA.Code, 3, 40);

            var lines = rule.CalculateDiscount(TestSkus.SkuA, 3).ToList();

            lines.Should().HaveCount(1);
            var line = lines[0];
            line.Sku.Should().Be(TestSkus.SkuA);
            line.Quantity.Should().Be(3);
            line.DiscountedUnitPrice.Should().Be(40);
            line.Rule.Should().Be(rule);
        }
    }
}