using SportStore.API.Entities;
namespace SportStore.API.Interfaces
{
    public interface IRoleRepository
    {
        Role CreateRole(Role Role);
        List<Role> GetRoles();
        Role EditRole(Role Role, Guid id);
        bool DeleteRole(Guid id);
        Role FindRoleById(Guid id);
    }
}