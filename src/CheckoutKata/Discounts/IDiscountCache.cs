using System.Collections.Generic;

namespace CheckoutKata.Discounts
{
    public interface IDiscountCache
    {
        IEnumerable<DiscountRule> ActiveRules { get; }
    }
}