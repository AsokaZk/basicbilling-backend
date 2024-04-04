using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.context;

namespace Persistence.Repositories
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        public ClientRepository(BasicBillingContext basicBillingContext)
            : base(basicBillingContext)
        {
        }
        public async Task<List<Client>> GetClients()
        {
            var clients = await GetAll()
                .ToListAsync();
            return clients;
        }
    }
}
