using CheckoutKata.Discounts;
using FluentAssertions;
using Xunit;

namespace CheckoutKata.Tests
{
    public class CheckoutCalculatorTests
    {
        private readonly TestSkuRepository repository;
        private readonly CheckoutCalculator calculator;

        public CheckoutCalculatorTests()
        {
            repository = new TestSkuRepository();
            repository.Add(TestSkus.SkuA);
            repository.Add(TestSkus.SkuB);
            repository.Add(TestSkus.SkuC);
            repository.Add(TestSkus.SkuD);
            calculator = new CheckoutCalculator(repository);
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
    }
}
