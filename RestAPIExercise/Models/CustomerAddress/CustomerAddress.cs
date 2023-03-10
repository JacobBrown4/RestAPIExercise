using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestAPIExercise.Models
{
    public enum AddressType { Billing, Shipping, Inactive };
    public class CustomerAddress
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DefaultValue("1 John Marshall Dr")]
        public string AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        [Required]
        [DefaultValue("Huntington")]
        public string City { get; set; }
        [Required]
        [DefaultValue("West Virginia")]
        public string State { get; set; }
        public string County { get; set; }
        [Required]
        [DefaultValue("25755")]
        public int PostalCode { get; set; }
        [Required]
        public AddressType AddressType { get; set; }

        [ForeignKey(nameof(Customer))]
        [DefaultValue("1")]
        public int CustomerId { get; set; }
    }
}
