using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IBillingRepository : IRepository<Billing>
    {
        Task<List<Billing>> GetBillingAll();
        Task<List<Billing>> GetBillingPendigs(string clientId);
        Task<List<Billing>> GetBillingHistory();
        Task<Billing> GetBillingToPay(int clientId, int period, string category);
        Task<List<Billing>> GetBillingSearch(string category);
    }
}
