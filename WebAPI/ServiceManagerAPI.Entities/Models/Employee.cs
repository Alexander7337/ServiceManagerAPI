namespace ServiceManagerAPI.Entities.Models
{
    using ServiceManagerAPI.Entities.Contracts;
    using System.Collections.Generic;

    public class Employee : IEntity
    {
        public Employee()
        {
            this.Customers = new HashSet<Customer>();
        }

        public int Id { get; set; }

        public string EmployeeName { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}
