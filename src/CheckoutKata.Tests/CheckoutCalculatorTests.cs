using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CheckoutKata.Tests
{
    public class CheckoutCalculatorTests
    {
        [Fact]
        public void should_calculate_total_cost_for_single_sku()
        {
            var productRepository = new TestProductRepository();
            productRepository.Add(new Sku("A", 10m));
            var calculator = new CheckoutCalculator(productRepository);

            calculator.AddSku("A");

            calculator.TotalSkuPrice.Should.Be(10m);
        }
    }
}
