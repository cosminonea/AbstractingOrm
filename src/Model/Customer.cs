namespace Model
{
    using System.Collections.Generic;

    public class Customer
    {
        public Customer()
        {
          Orders = new List<Order>();  
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<Order> Orders { get; set; }

    }
}