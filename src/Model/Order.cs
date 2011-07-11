namespace Model
{
    using System;
    using System.Collections.Generic;

    public class Order
    {
        public Order()
        {
            OrderItems = new List<OrderItem>();
        }
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
    }
}