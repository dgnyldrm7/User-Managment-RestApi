using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using User_Managment_RestApi.ConnextContext;
using User_Managment_RestApi.Models.Entity;
using User_Managment_RestApi.Models.Entity.DTO;

namespace User_Managment_RestApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        //Dependency Injection
        public readonly DatabaseContext? context;
        public UsersController(DatabaseContext _context)
        {
            context = _context;
        }


        //GET USERS FUNCTONS
        [HttpGet]
        [Route("GetUsers", Name = "All Users")]
        public ActionResult<List<UserDTO>> GetUsers()
        {
            var users = context.Users.ToList();
            var DTO = new List<UserDTO>();
            foreach (var user in users)
            {
                UserDTO dto = new UserDTO()
                {
                    Id = user.Id,
                    Name = user.Name,
                    LastName = user.LastName,
                    Email = user.Email,
                    Password = user.Password,
                    CreatedTime = user.CreatedTime,
                    RoleId = user.RoleId,
                    Details = $"https://localhost:7022/api/GetUsers/{user.Id}"
            };
                DTO.Add(dto);
            }

            if(DTO == null)
            {
                return NotFound();
            }

        

            return Ok(DTO);

        }




        //GET USER ID FUNCTION
        [HttpGet]
        [Route("GetUsers/{id:int}", Name = "Get User By Id")]
        public ActionResult<User> GetByUserId(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            if (id < 1 || id > 4)
            {
                return BadRequest("This Id is Empty in Database!");
            }

            var foundData = context.Users.FirstOrDefault(x => x.Id == id);
            string Prev = "https://localhost:7022/api/GetUsers";

            return Ok(new { message = $"{id} id user is founded! ", foundData , Prev } );
        }


        





    }
}
