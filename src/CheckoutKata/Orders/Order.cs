using System.Collections.Generic;
using System.Linq;
using CheckoutKata.Catalogue;
using CheckoutKata.Discounts;

namespace CheckoutKata.Orders
{
    /// <summary>
    /// Contains details of items purchased during a sale
    /// </summary>
    public class Order
    {
        public List<OrderLine> OrderLines { get; } = new List<OrderLine>();

        public decimal TotalPrice => OrderLines.Sum(x => x.TotalPrice);
        
        public void AddOrderLine(Sku sku, int quantity, decimal unitDiscount, string discountDescription)
        {
            OrderLines.Add(new OrderLine(sku.Code, quantity, sku.UnitPrice, unitDiscount, discountDescription));
        }
    }
}