using Microsoft.EntityFrameworkCore;
using User_Managment_RestApi.Models.ConnectContext;
using User_Managment_RestApi.Models.Entity;

namespace User_Managment_RestApi.Models.Repository.RoleRepo
{
    public class RoleRepository : IRoleRepository
    {
        private readonly DatabaseContext context;
        public RoleRepository(DatabaseContext _context)
        {
            context = _context;
        }




        //Get All Roles method!
        public List<Role> GetAllRoles()
        {
            return context.Roles.ToList();
        }





        //Get By Role Id method!
        public Role GetByRoleId(int? id)
        {
            var Role = context.Roles
                .Include(x => x.Users)
                .FirstOrDefault(x => x.Id == id);
            return Role;
        }






        //Post new Role method!
        public int Post(Role data)
        {
            context.Roles.Add(data);
            context.SaveChanges();
            
            return data.Id;
        }







        //Update Role Method!
        public int Update(int id, Role data)
        {
            var updateUser = GetByRoleId(id); //found it 
            
            updateUser.RoleName = data.RoleName;
            updateUser.CreatedTime = data.CreatedTime;
            updateUser.Description = data.Description;
            
            context.SaveChanges();
            
            return data.Id;
        }





        //Delete Method!
        public bool Delete(Role datas)
        {
            context.Roles.Remove(datas);
            context.SaveChanges();

            return true;
        }


    }
}
