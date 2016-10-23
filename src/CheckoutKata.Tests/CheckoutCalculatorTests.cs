using FluentAssertions;
using Xunit;

namespace CheckoutKata.Tests
{
    public class CheckoutCalculatorTests
    {
        [Fact]
        public void should_calculate_total_cost_for_single_sku()
        {
            var repository = new TestSkuRepository();
            repository.Add(new Sku("A", 10m));
            var calculator = new CheckoutCalculator(repository);

            calculator.AddSku("A");

            calculator.TotalSkuPrice.Should().Be(10m);
        }
    }
}
