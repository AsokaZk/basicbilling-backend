using Domain.Entities;
using Domain.Interfaces;
using Persistence.context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Seeders
{
    public class BillingStatusSeeder
    {
        private readonly BasicBillingContext basicBillingContext;

        public BillingStatusSeeder(BasicBillingContext basicBillingContext)
        {
            this.basicBillingContext = basicBillingContext;
        }

        public void Seed()
        {
            if (!basicBillingContext.BillingStatus.Any())
            {
                var status = new List<BillingStatus>()
                {
                    new BillingStatus()
                    {
                        Name = "Pending"
                    },
                    new BillingStatus()
                    {
                        Name = "Paid"
                    }
                };

                basicBillingContext.BillingStatus.AddRange(status);
                basicBillingContext.SaveChanges();
            }
        }
    }
}
