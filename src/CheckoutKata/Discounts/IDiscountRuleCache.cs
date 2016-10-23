using System.Collections.Generic;

namespace CheckoutKata.Discounts
{
    public interface IDiscountRuleCache
    {
        /// <summary>
        /// Gets currently active sku discount rules
        /// </summary>
        IEnumerable<DiscountRule> ActiveRules { get; }
    }
}