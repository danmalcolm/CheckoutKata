using System.Collections.Generic;
using System.Linq;

namespace CheckoutKata
{
    /// <summary>
    /// Contains details of good purchased during a sale
    /// </summary>
    public class Order
    {
        private readonly List<OrderLine> orderLines = new List<OrderLine>();

        public decimal TotalPrice => orderLines.Sum(x => x.TotalPrice);


        public void AddSku(Sku sku)
        {
            this.orderLines.Add(new OrderLine(sku.Code, 1, sku.UnitPrice));
        }
    }
}