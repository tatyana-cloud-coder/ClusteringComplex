using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClusteringComplex.Entities
{
    public class User 
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string MiddleName { get; set; }

        [Required]
        [MaxLength(90)]
        public string LastName { get; set;  }

        [Required]
        [Phone]
        [MaxLength(15)]
        public string PhoneNumber { get; set; }

        [EmailAddress]
        [MaxLength(254)]
        public string Email { get; set; }

        [Required]
        [MaxLength(50)]
        public string Login { get; set; }

        [Required]
        public string PasswordHashCode { get; set; } 

        public int? RoleId { get; set;  }

        public Role Role { get; set; }

    }
}
