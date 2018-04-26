namespace ServiceManagerAPI.Entities.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.Serialization;

    [DataContract]
    public class Service
    {
        [DataMember]
        public int Id { get; set; }

        [Required]
        [DataMember]
        public string ServiceName { get; set; }

        [DataMember]
        public string Description { get; set; }
    }
}
