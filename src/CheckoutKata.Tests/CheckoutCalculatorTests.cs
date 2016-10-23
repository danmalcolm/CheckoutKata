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
            repository.Add(new Sku("A", 10m));
            calculator = new CheckoutCalculator(repository);
        }

        [Fact]
        public void should_calculate_total_cost_for_single_sku()
        {
            calculator.AddSku("A");

            calculator.TotalSkuPrice.Should().Be(10m);
        }

        [Fact]
        public void should_calculate_total_cost_for_same_sku_added_multiple_times()
        {
            calculator.AddSku("A");
            calculator.AddSku("A");

            calculator.TotalSkuPrice.Should().Be(20m);
        }
    }
}
