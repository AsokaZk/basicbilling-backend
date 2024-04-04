using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Persistence.Repositories
{
    public class BillingRepository : Repository<Billing>, IBillingRepository
    {
        public BillingRepository(BasicBillingContext basicBillingContext)
            : base(basicBillingContext)
        {
        }

        public async Task<List<Billing>> GetBillingAll()
        {
            var billings = await GetAll()
                .Include(category => category.BillingCategory)
                .Include(status => status.BillingStatus)
                .Include(client => client.Client)
                .Where(status => status.BillingStatus.Name == "Pending")
                .ToListAsync();
            return billings;
        }

        public async Task<List<Billing>> GetBillingPendigs(string clientId)
        {
            var billings = await GetAll()
                .Include(category => category.BillingCategory)
                .Include(status => status.BillingStatus)
                .Include(client => client.Client)
                .Where(x => x.ClientId == Convert.ToInt32(clientId))
                .Where(status => status.BillingStatus.Name == "Pending")
                .ToListAsync();
            return billings;
        }

        public async Task<List<Billing>> GetBillingHistory()
        {
            var billings = await GetAll()
                .Include(category => category.BillingCategory)
                .Include(status => status.BillingStatus)
                .Include(client => client.Client)
                .Where(status => status.BillingStatus.Name == "Paid")
                .ToListAsync();
            return billings;
        }

        public async Task<Billing> GetBillingToPay(int clientId, int period, string category)
        {
            var billing = await GetAll()
                .Include(category => category.BillingCategory)
                .Include(status => status.BillingStatus)
                .Include(client => client.Client)
                .Where(x => x.ClientId == clientId)
                .Where(p => p.Period == period)
                .Where(c => c.BillingCategory.Name == category)
                .FirstOrDefaultAsync();
            return billing;
        }

        public async Task<List<Billing>> GetBillingSearch(string category)
        {
            var billings = await GetAll()
                .Include(category => category.BillingCategory)
                .Include(status => status.BillingStatus)
                .Include(client => client.Client)
                .Where(x => x.BillingCategory.Name == category)
                .ToListAsync();
            return billings;
        }
    }
}
