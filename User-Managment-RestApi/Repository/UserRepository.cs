using Microsoft.AspNetCore.Mvc;
using User_Managment_RestApi.Models.Entity;
using User_Managment_RestApi.Models.Entity.DTO;
using User_Managment_RestApi.ConnextContext;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace User_Managment_RestApi.Repository
{
    public class UserRepository : IUserRepository
    {
        //Depended injection!
        private readonly DatabaseContext _context;
        public UserRepository(DatabaseContext Context)
        {
            _context = Context;
        }




        public ActionResult<List<User>> GetUsers()
        {
            return _context.Users.ToList();
        }


        //GetUserById
        public User GetByUserId(int? id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);
            
            return user;
        }


        //Delete Method!
        public bool Delete(User datas)
        {
            _context.Users.Remove(datas);
            _context.SaveChanges();

            return true;
        }



        //Post Method
        public int Post(User data)
        {
            _context.Users.Add(data);
            _context.SaveChanges();
            return data.Id;
        }





        public ActionResult Update(int id, User data)
        {
            throw new NotImplementedException();
        }

        Action<List<User>> IUserRepository.GetUsers()
        {
            throw new NotImplementedException();
        }


        
    }
}
