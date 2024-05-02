using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using User_Managment_RestApi.Models.ConnectContext;
using User_Managment_RestApi.Models.Entity;
using User_Managment_RestApi.Models.Entity.DTO.UserDTO;
using User_Managment_RestApi.Models.Repository.UserRepo;

namespace User_Managment_RestApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        //Dependency Injection with Repository Design Pattern!
        private readonly IUserRepository userRepository;

        //Dependency injection here -> AutoMapper
        private readonly IMapper mapper;

        public UsersController(IUserRepository _userRepository , IMapper _mapper)
        {
            userRepository = _userRepository;
            mapper = _mapper;
        }


        //GET USERS FUNCTONS
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("GetUsers", Name = "All Users")]
        public ActionResult<List<UserDTO>> GetUsers()
        {
            //Users is coming list type!
            var users = userRepository.GetUsers();
            //changed from User to UserDTO
            var UsersDDTO = mapper.Map<List<UserDTO>>(users);

            if (UsersDDTO == null)
            {
                return NotFound();
            }
            string Prev = "https://localhost:7022/api";
            var response = new
            {
                Prev,
                UsersDDTO
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
            var _foundData = userRepository.GetByUserId(id);

            var foundData = mapper.Map<UserDetailsDTO>(_foundData);

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
            var updateUser = userRepository.GetByUserId(id);

            if (updateUser == null)
            {
                return NotFound();
            }

            var updateId = userRepository.Update(id,data);

            if(updateId != id)
            {
                return BadRequest();
            }

            //204 - status code - update
            return NoContent();
        }

        





    }
}
