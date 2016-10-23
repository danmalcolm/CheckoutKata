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
            var rule = new DiscountRule("A", 3, 40);

            var calculation = rule.CalculateDiscount("A", 3);

            calculation.Should().NotBeNull();
            calculation.Quantity.Should().Be(3);
            calculation.DiscountedQuantity.Should().Be(3);
            calculation.DiscountedUnitPrice.Should().Be(40);
            calculation.Rule.Should().Be(rule);
        }

        [Fact]
        public void should_apply_discounts_to_matching_skus_with_multiple_of_break_quantity()
        {
            var rule = new DiscountRule("A", 3, 40);

            var calculation = rule.CalculateDiscount("A", 9);

            calculation.Should().NotBeNull();
            calculation.Quantity.Should().Be(9);
            calculation.DiscountedQuantity.Should().Be(9);
            calculation.DiscountedUnitPrice.Should().Be(40);
            calculation.Rule.Should().Be(rule);
        }

        [Fact]
        public void should_not_apply_discounts_to_non_matching_skus()
        {
            var rule = new DiscountRule("A", 3, 40);

            var calculation = rule.CalculateDiscount("B", 9);

            calculation.Should().BeNull();
        }

        [Fact]
        public void should_combine_discounted_and_non_discounted_lines_if_sku_quantity_not_multiple_of_break_quantity()
        {
            var rule = new DiscountRule("A", 3, 40);

            var calculation = rule.CalculateDiscount("A", 8);

            calculation.Should().NotBeNull();
            calculation.Quantity.Should().Be(8);
            calculation.DiscountedQuantity.Should().Be(6);
            calculation.DiscountedUnitPrice.Should().Be(40);
            calculation.Rule.Should().Be(rule);
        }
    }
}