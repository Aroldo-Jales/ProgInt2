using ProgInt2.Domain.Entities;

namespace ProgInt2.Application.Common.Interfaces.Persistence
{
    public interface IUserRepository
    {
        Task Add(User user);
        Task Update(User user);
        User? GetUserByEmail(string email);
        User? GetUserById(Guid id);
    }
}