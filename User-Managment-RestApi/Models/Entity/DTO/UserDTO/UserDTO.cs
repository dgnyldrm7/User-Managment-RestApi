using System.ComponentModel.DataAnnotations;
using User_Managment_RestApi.Models.Entity;

namespace User_Managment_RestApi.Models.Entity.DTO.UserDTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Details { get; set; }
    }
}
