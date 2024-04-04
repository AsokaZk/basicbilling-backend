using Domain.Dtos;
using Domain.Entities;
using Domain.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IBillingService
    {
        Task<List<Billing>> GetBillingAll();
        Task<List<Billing>> GetBillingPendigs(GetBillingParams queryParams);
        Task<List<Billing>> GetBillingHistory();
        Task<List<Billing>> CreateBilling(CreateBillingResource billing);
        Task<Billing> PayBilling(PayBillingResource billing);
        Task<List<Billing>> GetBillingSearch(GetBillingSearchParams queryParams);
    }
}
