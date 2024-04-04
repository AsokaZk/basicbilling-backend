using Domain.Entities;
using Persistence.context;

namespace Persistence.Seeders
{
    public class BillingCategorySeeder
    {
        private readonly BasicBillingContext basicBillingContext;

        public BillingCategorySeeder(BasicBillingContext basicBillingContext)
        {
            this.basicBillingContext = basicBillingContext;
        }

        public void Seed()
        {
            if (!basicBillingContext.BillingCategories.Any())
            {
                var categories = new List<BillingCategory>()
                {
                    new BillingCategory()
                    {
                        Name = "WATER"
                    },
                    new BillingCategory()
                    {
                        Name = "ELECTRICITY"
                    },
                    new BillingCategory()
                    {
                        Name = "SEWER"
                    }
                };

                basicBillingContext.BillingCategories.AddRange(categories);
                basicBillingContext.SaveChanges();
            }
        }
    }
}
