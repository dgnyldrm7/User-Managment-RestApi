using System.Text.Json.Serialization;
using System.Text.Json;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using User_Managment_RestApi.Models.ConnectContext;
using User_Managment_RestApi.Models.DTO.RoleDTO;
using User_Managment_RestApi.Models.Entity;
using User_Managment_RestApi.Models.Entity.DTO.RoleDTO;
using User_Managment_RestApi.Models.Entity.DTO.UserDTO;
using System.Net.Http.Json;
using System.Xml;
using static System.Runtime.InteropServices.JavaScript.JSType;
using User_Managment_RestApi.Models.Repository.RoleRepo;
using User_Managment_RestApi.Models.Repository.UserRepo;

namespace User_Managment_RestApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        //Dependency Injection!
        private readonly IMapper mapper;
        private readonly IRoleRepository roleRepository;
        public RolesController(IMapper _mapper , IRoleRepository _roleRepository)
        {
            mapper = _mapper;
            roleRepository = _roleRepository;
        }



        //GET ALL ROLES METHOD!
        [HttpGet("GetRoles")]
        public ActionResult<List<Role>> GetRoles()
        {
            var datas = roleRepository.GetAllRoles();
            if (datas == null)
            {
                return NotFound();
            }
            var RolesDTO = mapper.Map<List<RoleDTO>>(datas);
            if (RolesDTO == null)
            {
                return NotFound();
            }
            string Prev = "https://localhost:7022/api";
            var GetAllRoles = new
            {
                Prev,
                RolesDTO
            };
            return Ok(GetAllRoles);
        }







        //GetByRoleId ROLES METHOD!
        [HttpGet]
        [Route("GetRoles/{id:int}", Name = "GetByRoleId")]
        public ActionResult<RoleDetails> GetRoleById(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var roleWithUsers = roleRepository.GetByRoleId(id);
            if (roleWithUsers == null)
            {
                return NotFound();
            }
            if (roleWithUsers.Id != id)
            {
                return BadRequest();
            }
            var result = new
                {
                    prev = "https://localhost:7022/api",
                    _roles = new
                    {
                        id = roleWithUsers.Id,
                        roleName = roleWithUsers.RoleName,
                        description = roleWithUsers.Description,
                        createdTime = roleWithUsers.CreatedTime,
                        users = roleWithUsers.Users.Select(user => new
                        {
                            id = user.Id,
                            name = user.Name,
                            lastName = user.LastName,
                            email = user.Email
                        }).ToList()
                    }
                };
            // Belirli bir role ait olan kullanıcıları al
            return Ok(result);
        }








        //NEW ROLE ADD
        [HttpPost]
        [Route("PostRole", Name = "Post Role")]
        public ActionResult PostRole(Role datas)
        {
            if(datas == null)
            {
                return NotFound();
            }

            //added Info!
            var dataId = roleRepository.Post(datas);

            var postRole = mapper.Map<RoleDTO>(datas);
            return Created($"GetRoles/{dataId}", postRole);

        }



        //DELETE ROLE!
        [HttpDelete]
        [Route("DeleteRole/{id:int}", Name = "Delete Role")]
        public ActionResult DeleteRole(int? id)
        {
            if (id == null)
            {
                return NotFound("This id is empty");
            }

            var datas = roleRepository.GetByRoleId(id);

            if (datas == null)
            {
                return NotFound();
            }

            if (datas == null)
            {
                return NotFound();
            }
            try
            {
                roleRepository.Delete(datas);
            }
            catch (Exception error)
            {
                NotFound($"Bug is : {error}");
            }
            //204 - status code
            return NoContent();
        }





        //Update Role Method!
        [HttpPut]
        [Route("UpdateRole/{id:int}", Name = "Update Role")]
        public ActionResult PutRole(int id, Role datas)
        {
            if (id != datas.Id)
            {
                return BadRequest();
            }
            var role = roleRepository.GetByRoleId(id);
            if (role == null)
            {
                return NotFound();
            }

            var updateId = roleRepository.Update(id,datas);

            if (updateId != id)
            {
                return BadRequest();
            }

            //204 - status code - update
            return NoContent();
        }






    }
}


