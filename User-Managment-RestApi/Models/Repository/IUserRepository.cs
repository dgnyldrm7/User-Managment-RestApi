using Microsoft.AspNetCore.Mvc;
using User_Managment_RestApi.Models.Entity;
using User_Managment_RestApi.Models.DTO;

namespace User_Managment_RestApi.Models.Repository
{
    public interface IUserRepository
    {
        List<User> GetUsers();
        User GetByUserId(int? id);
        bool Delete(User data);
        int Post(User data);
        int Update(int id, User data);
    }
}
