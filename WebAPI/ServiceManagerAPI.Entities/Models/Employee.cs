namespace ServiceManagerAPI.Entities.Models
{
    using System.Collections.Generic;

    public class Employee
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
