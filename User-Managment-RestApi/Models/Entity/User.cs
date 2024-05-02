using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace User_Managment_RestApi.Models.Entity
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please add user name!")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Please add user lastname!")]
        public string? LastName { get; set; }

        [EmailAddress(ErrorMessage = "Please add your Email!")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Please add your Password!")]
        public string? Password { get; set; }

        [Compare(nameof(Password))]
        public string? ConfirmPassword { get; set; }

        public DateTime CreatedTime { get; set; }

        // Role ile ilişki
        public int RoleId { get; set; }
        public Role? Role { get; set; }
    }

}
