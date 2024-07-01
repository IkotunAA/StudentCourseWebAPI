using Microsoft.EntityFrameworkCore;
using WebAPIBatch20.Context;
using WebAPIBatch20.Entities;
using WebAPIBatch20.Repositories.Interfaces;

namespace WebAPIBatch20.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly WebAPIDbContext _context;

        public UserRepository(WebAPIDbContext context)
        {
            _context = context;
        }

        public User Create(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public User? GetByEmail(string email)
        {
            return _context.Users
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                .SingleOrDefault(e => e.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
        }

        public Role GetRoleByName(string roleName)
        {
            return _context.Roles.SingleOrDefault(e => e.Name.Equals(roleName, StringComparison.OrdinalIgnoreCase));
        }
    }
}
