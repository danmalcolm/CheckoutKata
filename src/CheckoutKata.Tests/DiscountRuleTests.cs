using System.Linq;
using CheckoutKata.Discounts;
using FluentAssertions;
using Xunit;

namespace CheckoutKata.Tests
{
    public class DiscountRuleTests
    {
        [Fact]
        public void should_apply_discounts_to_matching_skus_with_break_quantity()
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

        [Fact]
        public void should_apply_discounts_to_matching_skus_with_multiple_of_break_quantity()
        {
            var rule = new DiscountRule(TestSkus.SkuA.Code, 3, 40);

            var lines = rule.CalculateDiscount(TestSkus.SkuA, 9).ToList();

            lines.Should().HaveCount(1);
            var line = lines[0];
            line.Sku.Should().Be(TestSkus.SkuA);
            line.Quantity.Should().Be(9);
            line.DiscountedUnitPrice.Should().Be(40);
            line.Rule.Should().Be(rule);
        }

        [Fact]
        public void should_not_apply_discounts_to_non_matching_skus()
        {
            var rule = new DiscountRule(TestSkus.SkuA.Code, 3, 40);

            var lines = rule.CalculateDiscount(TestSkus.SkuB, 3).ToList();

            lines.Should().BeEmpty();
        }

        [Fact]
        public void should_combine_discounted_and_non_discounted_lines_if_sku_quantity_not_multiple_of_break_quantity()
        {
            var rule = new DiscountRule(TestSkus.SkuA.Code, 3, 40);

            var lines = rule.CalculateDiscount(TestSkus.SkuA, 8).ToList();

            lines.Should().HaveCount(2);
            var discountedLine = lines[0];
            discountedLine.Sku.Should().Be(TestSkus.SkuA);
            discountedLine.Quantity.Should().Be(6);
            discountedLine.DiscountedUnitPrice.Should().Be(40);
            discountedLine.Rule.Should().Be(rule);
            var remainingLine = lines[1];
            remainingLine.Sku.Should().Be(TestSkus.SkuA);
            remainingLine.Quantity.Should().Be(2);
            remainingLine.DiscountedUnitPrice.Should().Be(50);
            remainingLine.Rule.Should().BeNull();
        }
    }
}