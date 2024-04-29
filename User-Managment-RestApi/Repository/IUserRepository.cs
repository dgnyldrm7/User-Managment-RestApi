using Microsoft.AspNetCore.Mvc;
using User_Managment_RestApi.Models.Entity;
using User_Managment_RestApi.Models.Entity.DTO;

namespace User_Managment_RestApi.Repository
{
    public interface IUserRepository
    {
        Action<List<User>> GetUsers();
        User GetByUserId(int? id);
        bool Delete(User data);
        int Post(User data);
        ActionResult Update(int id, User data);
    }
}
