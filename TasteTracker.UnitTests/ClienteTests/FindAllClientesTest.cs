using TasteTracker.Application.Services.Interfaces;
using Faker;
using TasteTracker.Core.Entities;
using TasteTracker.API.Controllers;
using TasteTracker.UnitTests.ClienteTests;
using TasteTracker.Application.Dtos;
using Moq;
using TasteTracker.Application.Dtos.ClienteDtos;
using Microsoft.AspNetCore.Mvc;

namespace TasteTracker.UnitTests
{
    public class FindAllClientesTest
    {
        [Fact]
        public async Task test_findAll_clientes()
        {
            var mockClienteService = new Mock<IClienteService>();
            var controller = new ClienteController(mockClienteService.Object);


            var result = await controller.FindAll(CancellationToken.None);

            Assert.IsType<OkObjectResult>(result);
        }
    }
}