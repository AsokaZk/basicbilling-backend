using Common.Exceptions;
using Core.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BasicBilling.Controllers
{
    [ApiController]
    [Route("client")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<ActionResult<Client>> GetClients()
        {
            try
            {
                return Ok(await _clientService.GetClients());
            }
            catch (ModelNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
