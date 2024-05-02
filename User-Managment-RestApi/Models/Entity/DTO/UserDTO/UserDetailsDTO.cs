using System.ComponentModel.DataAnnotations;
using User_Managment_RestApi.Models.Entity;
using User_Managment_RestApi.Models.DTO.RoleDTO;

namespace User_Managment_RestApi.Models.Entity.DTO.UserDTO
{
    public class UserDetailsDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
        public DateTime CreatedTime { get; set; }
        public int RoleId { get; set; }
        public string? RoleName { get; set; }

    }
}
