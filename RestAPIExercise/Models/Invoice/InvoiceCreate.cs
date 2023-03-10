using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RestAPIExercise.Models
{
    public class InvoiceCreate
    {
        [Required]
        public DateTime InvoiceDate { get; set; }
        [DefaultValue(1)]

        public int? CustomerId { get; set; }
        [DefaultValue(1)]
        public int ShippingAddressId { get; set; }
        [DefaultValue(1)]
        public int? BillingAddressId { get; set; }
    }
}
