using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestAPIExercise.Models
{
    public class Invoice
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime InvoiceDate { get; set; }
        [Required]
        [ForeignKey(nameof(Customer))]
        public int? CustomerId { get; set; }
        public virtual Customer? Customer { get; set; }

        [Required]
        public int ShippingAddressId { get; set; }
        public virtual CustomerAddress? ShippingAddress { get; set; }

        public int? BillingAddressId { get; set; }
        public virtual CustomerAddress? BillingAddress { get; set; }

        public virtual List<InvoiceLineItem> LineItems { get; set; } = new List<InvoiceLineItem>();

        public double TotalWeightInLbs
        {
            get
            {
                if (LineItems.Count == 0)
                    return 0;
                double weight = 0;
                foreach (InvoiceLineItem item in LineItems)
                {
                    weight += item.WeightInLbs;
                }
                return weight;
            }
        }
    }
}
