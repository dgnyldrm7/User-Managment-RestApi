﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace User_Managment_RestApi.Models.Entity
{
    public class Role
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please add RoleName!")]
        public string? RoleName { get; set; }

        public string? Description { get; set; }
        public DateTime CreatedTime { get; set; }

        // Kullanıcılar için koleksiyon
        public ICollection<User>? Users { get; set; }
    }


   
}


