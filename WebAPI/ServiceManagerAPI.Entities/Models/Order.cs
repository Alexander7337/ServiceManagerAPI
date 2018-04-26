namespace ServiceManagerAPI.Entities.Models
{
    public class Order
    {
        public int Id { get; set; }

        public string OrderName { get; set; }

        public string Description { get; set; }

        public virtual Service Service { get; set; }
    }
}
