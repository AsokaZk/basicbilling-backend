using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.context;

namespace Persistence.Repositories
{
    public class BillingStatusRepository : Repository<BillingStatus>, IBillingStatusRepository
    {
        public BillingStatusRepository(BasicBillingContext basicBillingContext)
            : base(basicBillingContext)
        {
        }

        public async Task<BillingStatus> GetStatusByName(string name)
        {
            return await GetAll().FirstOrDefaultAsync(x => x.Name == name);
        }
    }
}
