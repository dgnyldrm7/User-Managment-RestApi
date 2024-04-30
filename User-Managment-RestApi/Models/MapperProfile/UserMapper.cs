using AutoMapper;
using User_Managment_RestApi.Models.DTO;
using User_Managment_RestApi.Models.Entity;

namespace User_Managment_RestApi.Models.MapperProfile
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<User, UserDTO>()
                .ForMember(dest => dest.Details, opt => opt.MapFrom(src => GenerateUserDetails(src)))
                .ReverseMap();
        }

        private string GenerateUserDetails(User user)
        {
            return $"https://localhost:7022/api/GetUsers/{user.Id}";
        }
    }

}
