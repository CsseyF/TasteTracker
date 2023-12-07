using TasteTracker.Application.Services.Interfaces;

namespace TasteTracker.Application.Services
{
    public class HashingService : IHashingService
    {

        public string Hashpassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, "$2a$12$VvDRKYKGt4Zd2Ux35LeG2OI.Vr5f.UuY2q7MrnHlJj4K5diifQV3e");
        }
    }
}
