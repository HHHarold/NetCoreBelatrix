﻿namespace Belatrix.WebApi.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }

        public virtual Product ProductNavigation { get; set; }
        public virtual Order OrderNavigation{ get; set; }
    }
}
