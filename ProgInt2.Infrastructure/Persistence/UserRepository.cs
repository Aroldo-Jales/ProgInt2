using ProgInt2.Application.Common.Interfaces.Persistence;
using ProgInt2.Domain.Entities;
using ProgInt2.Infrastructure.Database;

namespace ProgInt2.Infrastructure.Persistence
{    
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _dbcontext;
        
        public UserRepository(AppDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task Add(User user)
        {            
            await _dbcontext.Users!.AddAsync(user);
            await _dbcontext.SaveChangesAsync();       
        }

        public async Task Update(User user)
        {
            User updateUser = _dbcontext.Users!.SingleOrDefault(u => u == user)!;
            updateUser.Password = user.Password;
            await _dbcontext.SaveChangesAsync();
        }

        public User? GetUserByEmail(string email)
        {
            return _dbcontext.Users!.SingleOrDefault(user => user.Email == email);
        }

        public User? GetUserById(Guid id)
        {
            return _dbcontext.Users!.SingleOrDefault(user => user.Id == id);
        }
    }
}