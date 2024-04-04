using AutoMapper;
using Core.Interfaces;
using Domain.Dtos;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Resources;

namespace Core.Service
{
    public class BillingService : IBillingService
    {
        private readonly IBillingRepository billingRepository;
        private readonly IClientRepository clientRepository;
        private readonly IBillingCategoryRepository categoryRepository;
        private readonly IBillingStatusRepository statusRepository;
        private readonly IMapper _mapper;

        public BillingService(IBillingRepository billingRepository,
                                IBillingCategoryRepository categoryRepository,
                                IClientRepository clientRepository,
                                IBillingStatusRepository statusRepository,
                                IMapper mapper)
        {
            this.billingRepository = billingRepository;
            this.clientRepository = clientRepository;
            this.categoryRepository = categoryRepository;
            this.statusRepository = statusRepository;
            _mapper = mapper;
        }

        public async Task<List<Billing>> CreateBilling(CreateBillingResource billingResource)
        {
            Task<BillingStatus> billingStatusDefault = statusRepository.GetStatusByName("Pending");
            Task<BillingCategory> billingCategoryDefault = categoryRepository.GetCategoryByName(billingResource.Category);

            var billing = _mapper.Map<CreateBillingResource, Billing>(billingResource);

            billing.BillingStatusId = billingStatusDefault.Result.Id;
            billing.BillingCategoryId = billingCategoryDefault.Result.Id;

            List<Client> clients = await clientRepository.GetClients();
            List<Billing> billings = new List<Billing>();

            foreach (Client client in clients)
            {
                Billing newBilling = new Billing();
                newBilling.ClientId = client.Id;
                newBilling.Charge = "200";
                newBilling.BillingCategoryId = billing.BillingCategoryId;
                newBilling.BillingStatusId = billing.BillingStatusId;
                newBilling.Period = billing.Period;
                billings.Add(newBilling);
            }

            return await billingRepository.AddList(billings);
        }

        public async Task<Billing> PayBilling(PayBillingResource billingResource)
        {
            Task<BillingStatus> billingStatusDefault = statusRepository.GetStatusByName("Paid");
            
            Billing billing = await billingRepository.GetBillingToPay(billingResource.ClientId, billingResource.Period, billingResource.Category);
            
            billing.BillingStatusId = billingStatusDefault.Result.Id;

            return await billingRepository.Update(billing);
        }

        public async Task<List<Billing>> GetBillingPendigs(GetBillingParams queryParams)
        {
            return await billingRepository.GetBillingPendigs(queryParams.ClientId);
        }

        public async Task<List<Billing>> GetBillingHistory()
        {
            return await billingRepository.GetBillingHistory();
        }

        public async Task<List<Billing>> GetBillingSearch(GetBillingSearchParams queryParams)
        {
            return await billingRepository.GetBillingSearch(queryParams.Category);
        }

        public async Task<List<Billing>> GetBillingAll()
        {
            return await billingRepository.GetBillingAll();
        }
    }
}
