using System.Collections.Generic;
using System.Linq;
using CheckoutKata.Discounts;

namespace CheckoutKata.Tests
{
    public class TestDiscountRuleCache : IDiscountRuleCache
    {
        private List<DiscountRule> rules = new List<DiscountRule>();

        public IEnumerable<DiscountRule> ActiveRules => rules;

        public void SetRules(IEnumerable<DiscountRule> rules) => this.rules = rules.ToList();
    }
}