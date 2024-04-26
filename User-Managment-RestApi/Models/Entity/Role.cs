using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace User_Managment_RestApi.Models.Entity
{
    public class Role
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please add RoleName!")]
        public string? RoleName { get; set; }

        [Required(ErrorMessage = "Please add Description!")]
        public string? Description { get; set; }


        public DateTime CreatedTime { get; set; }


        //Add properties!
        public ICollection<User>? _users { get; set; }
    }
}
