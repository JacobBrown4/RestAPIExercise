using System.ComponentModel.DataAnnotations;

namespace RestAPIExercise.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        public virtual List<CustomerAddress> Addresses { get; set; } = new List<CustomerAddress>();
    }
}