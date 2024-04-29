﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using User_Managment_RestApi.ConnextContext;
using User_Managment_RestApi.Models.Entity;
using User_Managment_RestApi.Models.Entity.DTO;
using User_Managment_RestApi.Repository;

namespace User_Managment_RestApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        //Dependency Injection with Repository Design Pattern!
        private readonly IUserRepository userRepository;
        public UsersController(IUserRepository _userRepository)
        {
            userRepository = _userRepository;
        }


        //GET USERS FUNCTONS
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("GetUsers", Name = "All Users")]
        public ActionResult<List<UserDTO>> GetUsers()
        {
            //var users = context.Users.ToList();

            var DTO = new List<UserDTO>();
            //foreach (var user in users)
            //{
            //    UserDTO Users = new UserDTO()
            //    {
            //        Id = user.Id,
            //        Name = user.Name,
            //        LastName = user.LastName,
            //        Email = user.Email,
            //        Password = user.Password,
            //        CreatedTime = user.CreatedTime,
            //        RoleId = user.RoleId,
            //        Details = $"https://localhost:7022/api/GetUsers/{user.Id}"
            //};
            //    DTO.Add(Users);
            //}
            //if(DTO == null)
            //{
            //    return NotFound();
            //}

            string Prev = "https://localhost:7022/api";

            var response = new
            {
                Prev,
                DTO
            };

            return Ok( response );

        }




        //GET USER ID FUNCTION
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("GetUsers/{id:int}", Name = "Get User By Id")]
        public ActionResult<User> GetByUserId(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            if (id < 1)
            {
                return BadRequest( $"This Id = {id} is negative number");
            }
            var foundData = userRepository.GetByUserId(id);
            if (foundData == null)
            {
                return BadRequest($"This Id = {id} was deleted in Database! or NULL");
            }
            string Prev = "https://localhost:7022/api/GetUsers";
            return Ok(new { message = $"{id} id user is founded! ", foundData , Prev } );
        }









        //DELETE USER ID
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [Route("UserDelete/{id:int}" , Name = "Delete User")]
        public ActionResult Delete(int? id)
        {
            if( id == null)
            {
                return NotFound("This id is empty");
            }
            var data = userRepository.GetByUserId(id);
            if ( data == null)
            {
                return NotFound();
            }
            try
            {
                userRepository.Delete(data);
            }
            catch(Exception error)
            {
                NotFound($"Bug is : {error}");
            }
            //204 - status code
            return NoContent();
        }







        //POST NEW USER
        [HttpPost]
        [Route("PostUser", Name = "Post New User")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult PostUser(User data)
        {
            if( data == null)
            {
                return NotFound("Your datas are empty!");
            }
            int number = userRepository.Post(data);
            return Created($"GetUsers/{number}", data);
        }








        //PUT METHOD OLD USER - UPDATE OPTIONS
        [HttpPut]
        [Route("UpdateUser/{id:int}", Name = "Update User")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult PutUser(int id , User data)
        {
            if(id != data.Id)
            {
                return BadRequest();
            }
            ////var updateUser = context.Users.FirstOrDefault(m => m.Id == id);

            //if( updateUser == null)
            //{
            //    return NotFound();
            //}

            //updateUser.Name = data.Name;
            //updateUser.LastName = data.LastName;
            //updateUser.Email = data.Email;
            //updateUser.Password = data.Password;
            //updateUser.ConfirmPassword = data.ConfirmPassword;

            //context.SaveChanges();

            //204 - status code - update
            return NoContent();
        }

        





    }
}
