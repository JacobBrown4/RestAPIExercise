using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestAPIExercise.Models
{
    public class InvoiceLineItem
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ItemName { get; set; }
        public double WeightInLbs { get; set; }
        [Required]
        [ForeignKey(nameof(Invoice))]
        public int InvoiceId { get; set; }
    }
}
