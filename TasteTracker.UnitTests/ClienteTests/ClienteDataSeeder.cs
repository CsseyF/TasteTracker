using TasteTracker.Core.Entities;
using Bogus;

namespace TasteTracker.UnitTests.ClienteTests
{
    public class ClienteDataSeeder
    {
        public IEnumerable<Cliente> GenerateData(int amount)
        {
            var people = new Faker<Cliente>("pt_BR")
                .CustomInstantiator(p => new Cliente()
                {
                    Id = Guid.NewGuid(),
                    FirstName = p.Name.FirstName(),
                    LastName = p.Name.LastName(),
                    Email = p.Internet.Email(),
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    IsActive = true,
                    Password = p.Internet.Password(),
                });

            return people.Generate(amount);
        }
    }
}
