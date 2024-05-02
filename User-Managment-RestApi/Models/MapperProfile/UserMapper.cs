using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using User_Managment_RestApi.Models.ConnectContext;
using User_Managment_RestApi.Models.Entity;
using User_Managment_RestApi.Models.Entity.DTO.UserDTO;

namespace User_Managment_RestApi.Models.MapperProfile
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {

            CreateMap<User, UserDTO>()
                .ForMember(dest => dest.Details, opt => opt.MapFrom(src => GenerateUserDetails(src)))
                .ReverseMap();

            CreateMap<User, UserDetailsDTO>()
                .ForMember(k => k.RoleName , x => x.MapFrom(x => GetRoleName(x)))
                .ReverseMap();
        }

        private string GenerateUserDetails(User user)
        {
            return $"https://localhost:7022/api/GetUsers/{user.Id}";
        }

        private string? GetRoleName(User role)
        {
            return role.Role.RoleName;
        }
    }

}
