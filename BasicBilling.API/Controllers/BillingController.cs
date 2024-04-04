using AutoMapper;
using Common.Exceptions;
using Core.Interfaces;
using Domain.Dtos;
using Domain.Entities;
using Domain.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Persistence.context;

namespace BasicBilling.API.Controllers
{
    [Route("billing")]
    [ApiController]
    public class BillingController : ControllerBase
    {
        private readonly IBillingService _billingService;
        private readonly IMapper _mapper;

        public BillingController(IBillingService billingService, IMapper mapper) 
        {
            _billingService = billingService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<BillingDto>>> GetBillingAll()
        {
            try
            {
                List<Billing> billings = await _billingService.GetBillingAll();

                var billingsDto = _mapper.Map<List<BillingDto>>(billings);
                return Ok(billingsDto);
            }
            catch (ModelNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpGet("pending")]
        public async Task<ActionResult<List<BillingDto>>> GetBillingPendigs([FromQuery] GetBillingParams queryParams)
        {
            try
            {
                List<Billing> billings = await _billingService.GetBillingPendigs(queryParams);

                var billingsDto = _mapper.Map<List<BillingDto>>(billings);
                return Ok(billingsDto);
            }
            catch (ModelNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpGet("history")]
        public async Task<ActionResult<List<BillingDto>>> GetBillinghistory()
        {
            try
            {
                List<Billing> billings = await _billingService.GetBillingHistory();

                var billingsDto = _mapper.Map<List<BillingDto>>(billings);
                return Ok(billingsDto);
            }
            catch (ModelNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpGet("search")]
        public async Task<ActionResult<List<BillingDto>>> GetBillingSearch([FromQuery] GetBillingSearchParams queryParams)
        {
            try
            {
                List<Billing> billings = await _billingService.GetBillingSearch(queryParams);

                var billingsDto = _mapper.Map<List<BillingDto>>(billings);
                return Ok(billingsDto);
            }
            catch (ModelNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost("bills")]
        public async Task<ActionResult<Billing>> CreateBilling([FromBody] CreateBillingResource billingResource)
        {
            try
            {
                List<Billing> billings = await _billingService.CreateBilling(billingResource);
                var billingsDto = _mapper.Map<List<BillingDto>>(billings);

                return Ok(billingsDto);
            }
            catch (ModelNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost("pay")]
        public async Task<ActionResult<Billing>> PayBilling([FromBody] PayBillingResource billingResource)
        {
            try
            {
                Billing billing = await _billingService.PayBilling(billingResource);
                var billingDto = _mapper.Map<BillingDto>(billing);

                return Ok(billingDto);
            }
            catch (ModelNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
