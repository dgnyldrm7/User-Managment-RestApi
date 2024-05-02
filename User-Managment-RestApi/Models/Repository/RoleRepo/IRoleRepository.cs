using User_Managment_RestApi.Models.Entity;

namespace User_Managment_RestApi.Models.Repository.RoleRepo
{
    public interface IRoleRepository
    {
        List<Role> GetAllRoles();
        Role GetByRoleId(int? id);
        int Post(Role data);
        int Update(int id, Role data);
        bool Delete(Role data);
    }
}
