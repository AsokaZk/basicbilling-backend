using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.context
{
    public class BasicBillingContext : DbContext
    {
        public BasicBillingContext(DbContextOptions<BasicBillingContext> options)
            : base(options)
        {

        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<BillingStatus> BillingStatus { get; set; }
        public DbSet<BillingCategory> BillingCategories { get; set; }
        public DbSet<Billing> Billings { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<BillingCategory>().HasData(
                new BillingCategory() { Id = 1,  Name = "WATER" },
                new BillingCategory() { Id = 2,  Name = "ELECTRICITY" },
                new BillingCategory() { Id = 3,  Name = "SEWER" }
            );
            builder.Entity<BillingStatus>().HasData(
                new BillingCategory() { Id = 1, Name = "Pending" },
                new BillingCategory() { Id = 2, Name = "Paid" }
            );
            builder.Entity<Client>().HasData(
                new Client() { Id = 100, Name = "Joseph Carlton" },
                new Client() { Id = 200, Name = "Maria Juarez" },
                new Client() { Id = 300, Name = "Albert Kenny" },
                new Client() { Id = 400, Name = "Jessica Phillips" },
                new Client() { Id = 500, Name = "Charles Johnson" }
            );
            builder.Entity<Billing>().HasData(new CreateBillings().GetBillingsSeed());
        }
    }
    public class CreateBillings
    {
        public Billing[] GetBillingsSeed()
        {
            int countId = 100;
            var billings = new Billing[30];
            for (int categoryId = 1; categoryId <= 3; categoryId++)
            {
                for (int i = 0; i < 5; i++)
                {
                    billings[countId - 100] = new Billing()
                    {
                        Id = countId,
                        Charge = "200",
                        Period = 202001,
                        ClientId = 100 * (i + 1),
                        BillingCategoryId = categoryId,
                        BillingStatusId = 1
                    };
                    countId++;
                    billings[countId - 100] = new Billing()
                    {
                        Id = countId,
                        Charge = "200",
                        Period = 202002,
                        ClientId = 100 * (i + 1),
                        BillingCategoryId = categoryId,
                        BillingStatusId = 1
                    };
                    countId++;
                }
            }
            return billings;
        }
    }
}
