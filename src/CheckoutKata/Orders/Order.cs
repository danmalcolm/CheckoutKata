using System.Collections.Generic;
using System.Linq;
using CheckoutKata.Catalogue;

namespace CheckoutKata.Orders
{
    /// <summary>
    /// Contains details of good purchased during a sale
    /// </summary>
    public class Order
    {
        public List<OrderLine> OrderLines { get; } = new List<OrderLine>();

        public decimal TotalPrice => OrderLines.Sum(x => x.TotalPrice);
        
        public void AddSku(Sku sku)
        {
            OrderLines.Add(new OrderLine(sku.Code, 1, sku.UnitPrice));
        }
    }
}