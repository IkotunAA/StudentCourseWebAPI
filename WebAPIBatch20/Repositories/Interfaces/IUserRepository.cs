using WebAPIBatch20.Entities;

namespace WebAPIBatch20.Repositories.Interfaces
{
    public interface IUserRepository
    {
        User Create(User user);
        User GetByEmail(string email);

        Role GetRoleByName(string roleName);
        //List<Role> GetSelectedRoles(List<int> ids);
    }
}
