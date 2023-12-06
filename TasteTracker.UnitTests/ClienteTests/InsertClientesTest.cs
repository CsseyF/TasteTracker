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
    public class InsertClientesTest
    {
        [Fact]
        public async Task test_findAll_clientes()
        {
            var mockClienteService = new Mock<IClienteService>();
            var seeder = new ClienteDataSeeder();
            var controller = new ClienteController(mockClienteService.Object);

            var entity = seeder.GenerateData(1).First();

            var result = await controller.Insert(new CreateClienteDto()
            {
                Email = entity.Email,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Password = entity.Password,
            }, CancellationToken.None);

            Assert.IsType<CreatedResult>(result);
        }
    }
}