using System.ComponentModel.DataAnnotations;

namespace User_Managment_RestApi.Models.Entity
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please add user name!")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Please add user lastname!")]
        public string? LastName { get; set; }

        [EmailAddress(ErrorMessage = "Please add your Email!")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Please add your Password!")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Plase add your confirm password!")]
        [Compare(nameof(Password))]
        public string? ConfirmPassword { get; set; }

        public DateTime CreatedTime { get; set; }




        //Add properties!
        public Role? _roles { get; set; }

        //foreing key!
        public int RoleId { get; set; }

    }
}
