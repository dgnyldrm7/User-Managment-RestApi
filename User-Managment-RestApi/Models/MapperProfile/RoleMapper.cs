using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using User_Managment_RestApi.Models.ConnectContext;
using User_Managment_RestApi.Models.DTO.RoleDTO;
using User_Managment_RestApi.Models.Entity;
using User_Managment_RestApi.Models.Entity.DTO.RoleDTO;
using User_Managment_RestApi.Models.Entity.DTO.UserDTO;

namespace User_Managment_RestApi.Models.MapperProfile
{
    public class RoleMapper : Profile
    {
        public RoleMapper()
        {


            CreateMap<Role, RoleDTO>()
                .ForMember(dest => dest.Details, opt => opt.MapFrom(src => GetRoleDetails(src)))
                .ReverseMap();



            CreateMap<Role, RoleDetails>()
                .ReverseMap();





        }




        private string GetRoleDetails(Role role)
        {
            return $"https://localhost:7022/api/GetRoles/{role.Id}";
        }

    }
}
