using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportStore.API.Entities;
using SportStore.API.Interfaces;
namespace SportStore.API.Repositories
{
    public class RoleLocalRepository : IRoleRepository
{
    public IList<Role> Roles { get; set; } = new List<Role>();
    

    public Role CreateRole(Role Role)
    {
        Role.Id = Guid.NewGuid();
        Roles.Add(Role);
        return Role;
       
    }

    public bool DeleteRole(Guid id)
    {
        var result = FindRoleById(id);
        Roles.Remove(result);
        return true;
    }

    public Role EditRole(Role Role, Guid id)
    {
        var result = FindRoleById(id);
        result.Name = Role.Name;
        return result;
        
    }

    public Role FindRoleById(Guid id)
    {
        var result = Roles.Where(u => u.Id == id).FirstOrDefault();

        if (result == null)
        {
            throw new Exception($"Нет пользователя с id = {id}");
        }
        if (result == null)
        {
            throw new Exception($"Нет пользователя с id = {id}");
        }

        return result;
        
    }

    public List<Role> GetRoles()
    {
        return (List<Role>)Roles;
        
    }
}
}