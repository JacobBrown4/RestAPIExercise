using Microsoft.EntityFrameworkCore;

namespace RestAPIExercise.Models
{
    public class RestAPIContext : DbContext
    {
        private readonly ILoggerFactory _loggerFactory;
        public RestAPIContext(DbContextOptions<RestAPIContext> options, ILoggerFactory logger) : base(options)
        {
            _loggerFactory = logger;
        }
        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<CustomerAddress> CustomerAddresses { get; set; } = null!;
        public DbSet<Invoice> Invoices { get; set; } = null!;
        public DbSet<InvoiceLineItem> InvoiceLineItems { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLoggerFactory(_loggerFactory);
        }

    }
}
