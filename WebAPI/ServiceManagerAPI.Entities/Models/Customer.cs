namespace ServiceManagerAPI.Entities.Models
{
    using System.Collections.Generic;

    public class Customer
    {
        public Customer()
        {
            this.Orders = new HashSet<Order>();
        }

        public int Id { get; set; }

        public string CustomerName { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
