using Microsoft.EntityFrameworkCore;
using Serilog;

namespace RestAPIExercise.Models
{
    internal class SeedData
    {
        internal static void Seed(RestAPIContext context)
        {
            ArgumentNullException.ThrowIfNull(context, nameof(context));
            context.Database.EnsureCreated();
            if (!context.Customers.Any())
            {
                context.Customers.AddRange(
                    new Customer
                    {
                        Id = 1,
                        FirstName = "Henry",
                        LastName = "Jones",
                        Email = "IndianaJones@Marshall.edu",
                        PhoneNumber = "765-555-1234"
                    }
                    );
                context.SaveChanges();
            }
        }
    }
    internal static class DbInitializerExtension
    {
        public static IApplicationBuilder SeedSQLServer(this IApplicationBuilder app)
        {
            ArgumentNullException.ThrowIfNull(app, nameof(app));

            using var scope = app.ApplicationServices.CreateScope();
            var services = scope.ServiceProvider;
            try
            {
                var context = services.GetRequiredService<RestAPIContext>();
                SeedData.Seed(context);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "An unhandled except occured when seeding");
            }

            return app;
        }
    }
}
