using ProgInt2.Domain.Entities;

namespace ProgInt2.Application.Common.Interfaces.Persistence
{
    public interface IUserRepository
    {
        User? GetUserByEmail(string email);
        Task Add(User user);
    }
}