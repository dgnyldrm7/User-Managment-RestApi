using System.ComponentModel.DataAnnotations;

namespace User_Managment_RestApi.Models.Entity.DTO.RoleDTO
{
    public class RoleDTO
    {
        public int Id { get; set; }
        public string? RoleName { get; set; }
        public string? Details { get; set; }
    }
}
