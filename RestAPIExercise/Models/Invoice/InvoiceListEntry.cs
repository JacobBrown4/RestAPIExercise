namespace RestAPIExercise.Models
{
    public class InvoiceListEntry
    {
        public int Id { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string Customer { get; set; }
        public string ShippingAddress { get; set; }
        public string BillingAddress { get; set; }
        public int AmountOfLineItems { get; set; } = 0;

    }
}
