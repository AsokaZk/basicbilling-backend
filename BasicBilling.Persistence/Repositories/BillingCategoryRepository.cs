using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public  class BillingCategoryRepository : Repository<BillingCategory>, IBillingCategoryRepository
    {
        public BillingCategoryRepository(BasicBillingContext basicBillingContext)
            : base(basicBillingContext)
        {
        }

        public async Task<BillingCategory> GetCategoryByName(string name)
        {
            return await GetAll().FirstOrDefaultAsync(x => x.Name == name);
        }
    }
}
