using System.ComponentModel.DataAnnotations;
using User_Managment_RestApi.Models.Entity;

namespace User_Managment_RestApi.Models.DTO.RoleDTO
{
    public class RoleDetails
    {
        public int Id { get; set; }
        public string? RoleName { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedTime { get; set; }
        public ICollection<User>? Users { get; set; }
    }
}
