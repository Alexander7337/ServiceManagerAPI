namespace ServiceManagerAPI.Entities.Models
{
    using ServiceManagerAPI.Entities.Contracts;
    using System.Collections.Generic;

    public class Customer : IEntity
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
