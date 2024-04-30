using System.ComponentModel.DataAnnotations;
using User_Managment_RestApi.Models.Entity;

namespace User_Managment_RestApi.Models.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public DateTime CreatedTime { get; set; }

        public string? Details { get; set; }



        //foreing key!
        public int RoleId { get; set; }
    }
}
