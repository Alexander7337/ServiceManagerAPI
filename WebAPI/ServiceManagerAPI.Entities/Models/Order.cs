namespace ServiceManagerAPI.Entities.Models
{
    using ServiceManagerAPI.Entities.Contracts;

    public class Order : IEntity
    {
        public int Id { get; set; }

        public string OrderName { get; set; }

        public string Description { get; set; }

        public virtual Service Service { get; set; }
    }
}
