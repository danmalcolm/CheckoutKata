using System.Linq;
using CheckoutKata.Discounts;
using FluentAssertions;
using Xunit;

namespace CheckoutKata.Tests
{
    public class CheckoutCalculatorTests
    {
        private readonly TestSkuRepository repository;
        private readonly CheckoutCalculator calculator;
        private readonly TestDiscountRuleCache discountRuleCache;

        public CheckoutCalculatorTests()
        {
            repository = new TestSkuRepository();
            repository.Add(TestSkus.SkuA);
            repository.Add(TestSkus.SkuB);
            repository.Add(TestSkus.SkuC);
            repository.Add(TestSkus.SkuD);

            discountRuleCache = new TestDiscountRuleCache();

            calculator = new CheckoutCalculator(repository, discountRuleCache);
        }

        [Fact]
        public void should_calculate_total_cost_for_single_sku()
        {
            calculator.AddSku("A");

            calculator.GetOrder().TotalPrice.Should().Be(50m);
        }

        [Fact]
        public void should_calculate_total_cost_for_same_sku_added_multiple_times()
        {
            calculator.AddSku("A");
            calculator.AddSku("A");

            calculator.GetOrder().TotalPrice.Should().Be(100m);
        }

        [Fact]
        public void should_calculate_total_cost_for_mixed_skus()
        {
            calculator.AddSku("A");
            calculator.AddSku("B");
            calculator.AddSku("C");
            calculator.AddSku("D");

            calculator.GetOrder().TotalPrice.Should().Be(239m);
        }

        [Fact]
        public void should_calculate_total_cost_for_mixed_skus_added_multiple_times()
        {
            calculator.AddSku("A");
            calculator.AddSku("A");
            calculator.AddSku("B");
            calculator.AddSku("B");
            calculator.AddSku("C");
            calculator.AddSku("C");
            calculator.AddSku("D");
            calculator.AddSku("D");

            calculator.GetOrder().TotalPrice.Should().Be(478m);
        }

        [Fact]
        public void should_include_discounted_lines_for_skus_matching_break_quantity_of_rule()
        {
            var rule1 = new DiscountRule("A", 3, 40m, "3 for 120");
            var rule2 = new DiscountRule("B", 2, 22.5m, "2 for 45");

            calculator.AddSku("A");
            calculator.AddSku("A");
            calculator.AddSku("A");
            calculator.AddSku("B");
            calculator.AddSku("B");

            var order = calculator.GetOrder();

            order.OrderLines.Should().HaveCount(2);
            var expected = new[]
            {
                new {SkuCode = "A", OriginalUnitPrice = TestSkus.SkuA.UnitPrice, UnitPrice = 40m, UnitDiscount = 10m, TotalPrice = 120, DiscountDescription = "3 for 120" },
                new {SkuCode = "B", OriginalUnitPrice = TestSkus.SkuB.UnitPrice, UnitPrice = 22.5m, UnitDiscount = 7.25m, TotalPrice = 45, DiscountDescription = "2 for 45" }
            };

            order.OrderLines.ShouldAllBeEquivalentTo(expected, options => options.ExcludingMissingMembers());
        }   
    }
}
