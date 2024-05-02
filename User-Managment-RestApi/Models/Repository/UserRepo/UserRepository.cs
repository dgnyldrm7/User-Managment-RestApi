using Microsoft.AspNetCore.Mvc;
using User_Managment_RestApi.Models.Entity;
using User_Managment_RestApi.Models.DTO;
using static System.Runtime.InteropServices.JavaScript.JSType;
using User_Managment_RestApi.Models.ConnectContext;
using Microsoft.EntityFrameworkCore;

namespace User_Managment_RestApi.Models.Repository.UserRepo
{
    public class UserRepository : IUserRepository
    {
        //Depended injection!
        private readonly DatabaseContext _context;
        public UserRepository(DatabaseContext Context)
        {
            _context = Context;
        }



        //Get All Users!
        public List<User> GetUsers()
        {
            return _context.Users.ToList();
        }


        //GetUserById
        public User GetByUserId(int? id)
        {
            var user = _context.Users.Include(u => u.Role).FirstOrDefault(x => x.Id == id);

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





        public int Update(int id, User data)
        {
            var updateUser = GetByUserId(id); //found it 

            updateUser.Name = data.Name;
            updateUser.LastName = data.LastName;
            updateUser.Email = data.Email;
            updateUser.Password = data.Password;
            updateUser.ConfirmPassword = data.ConfirmPassword;

            _context.SaveChanges();

            return data.Id;
        }


    }
}
