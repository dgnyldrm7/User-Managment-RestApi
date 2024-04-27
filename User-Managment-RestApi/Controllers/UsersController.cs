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
        public readonly DatabaseContext context;
        public UsersController(DatabaseContext _context)
        {
            context = _context;
        }


        //GET USERS FUNCTONS
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("GetUsers", Name = "All Users")]
        public ActionResult<List<UserDTO>> GetUsers()
        {
            var users = context.Users.ToList();
            var DTO = new List<UserDTO>();
            foreach (var user in users)
            {
                UserDTO Users = new UserDTO()
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
                DTO.Add(Users);
            }
            if(DTO == null)
            {
                return NotFound();
            }

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

            var foundData = context.Users
                .FirstOrDefault(x => x.Id == id);

            if(foundData == null)
            {
                return BadRequest($"This Id = {id} was deleted in Database! or NULL");
            }

            string Prev = "https://localhost:7022/api/GetUsers";

            return Ok(new { message = $"{id} id user is founded! ", foundData , Prev } );
        }






        //DELETE USER ID
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [Route("UserDelete/{id:int}" , Name = "Delete User")]
        public ActionResult Delete(int? id)
        {
            if( id == null)
            {
                return NotFound("This id is empty");
            }

            var data = context.Users.FirstOrDefault(x => x.Id == id);

            if( data == null)
            {
                return NotFound();
            }

            context.Users.Remove(data);

            try
            {
                context.SaveChanges();
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
        public ActionResult PostUser(User data)
        {

            if( data == null)
            {
                return NotFound("Your datas are empty!");
            }

            context.Users.Add(data);
            context.SaveChanges();

            return Created($"GetUsers/{data.Id}", data);
        }


        





    }
}
