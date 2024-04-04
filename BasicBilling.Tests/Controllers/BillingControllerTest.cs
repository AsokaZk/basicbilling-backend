using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using BasicBilling.API.Controllers;
using Core.Interfaces;
using Domain.Dtos;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace BasicBilling.Tests.Controllers
{
    public class BillingControllerTest
    {
        private readonly Mock<IMapper> mapper;

        public BillingControllerTest() 
        {
            mapper = new Mock<IMapper>();
        }

        [Fact]
        public async void Get_billing_pending_should_Return_List_of_billings()
        {
            GetBillingParams queryParams = new GetBillingParams { ClientId = "1"};
            List<Billing> billingsPendings = new List<Billing> { 
                new Billing
                {
                    Id = 1,
                    BillingStatusId = 1,
                    BillingCategoryId = 1,
                    ClientId = 1,
                    Period = 202001,
                    Charge = "200"
                } 
            };
            List<BillingDto> billingsPendingsResult = new List<BillingDto> { 
                new BillingDto
                {
                    Id = 1,
                    ClientId = 1,
                    Period = 202001,
                    Charge = 200,
                    Status = "Pending",
                    Category = "WATER",
                    Name = "Juan Perez"
                }
            };

            var billingServiceMock = new Mock<IBillingService>();

            billingServiceMock.Setup(billingService => billingService.GetBillingPendigs(It.IsAny<GetBillingParams>()))
                .Returns(Task.FromResult(billingsPendings));

            mapper.Setup(x => x.Map<List<BillingDto>>(It.IsAny<List<Billing>>()))
                .Returns(billingsPendingsResult);

            var billingController = new BillingController(billingServiceMock.Object, mapper: mapper.Object);
            var result = await billingController.GetBillingPendigs(queryParams);

            result.Should().BeOfType<ActionResult<List<BillingDto>>>();
            var objectResult = result.Result as OkObjectResult;

            Assert.Equal(200, objectResult.StatusCode);

            List<BillingDto> billingPendigsResult = objectResult.Value as List<BillingDto>;
            Assert.Equal(billingsPendings[0].Period, billingPendigsResult[0].Period);
        }

        [Fact]
        public async void Get_billing_search_should_Return_List_of_billings()
        {
            GetBillingSearchParams queryParams = new GetBillingSearchParams { Category = "SEWER" };
            List<Billing> billingsPendings = new List<Billing> {
                new Billing
                {
                    Id = 2,
                    BillingStatusId = 1,
                    BillingCategoryId = 3,
                    ClientId = 1,
                    Period = 202001,
                    Charge = "200",
                    BillingCategory = new BillingCategory { Name = "SEWER" }
                }
            };
            List<BillingDto> billingsPendingsResult = new List<BillingDto> {
                new BillingDto
                {
                    Id = 1,
                    ClientId = 1,
                    Period = 202001,
                    Charge = 200,
                    Status = "Pending",
                    Category = "SEWER",
                    Name = "Juan Perez"
                }
            };

            var billingServiceMock = new Mock<IBillingService>();

            billingServiceMock.Setup(billingService => billingService.GetBillingPendigs(It.IsAny<GetBillingParams>()))
                .Returns(Task.FromResult(billingsPendings));

            mapper.Setup(x => x.Map<List<BillingDto>>(It.IsAny<List<Billing>>()))
                .Returns(billingsPendingsResult);

            var billingController = new BillingController(billingServiceMock.Object, mapper: mapper.Object);
            var result = await billingController.GetBillingSearch(queryParams);

            result.Should().BeOfType<ActionResult<List<BillingDto>>>();
            var objectResult = result.Result as OkObjectResult;

            Assert.Equal(200, objectResult.StatusCode);

            List<BillingDto> billingPendigsResult = objectResult.Value as List<BillingDto>;
            Assert.Equal(billingsPendings[0].BillingCategory.Name, billingPendigsResult[0].Category);
        }
    }
}
