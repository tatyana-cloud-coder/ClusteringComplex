using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClusteringComplex.MVC.Models
{
    public class RegisterModel
    {


        [Required(ErrorMessage = "Не указано имя ")]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Не указана фамилия")]
        [MaxLength(90)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Не указан номер телефона")]
        [Phone]
        [MaxLength(15)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Не указан логин")]
        [MaxLength(50)]
        public string Login { get; set; }
        public string Email { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароль введен неверно")]
        public string ConfirmPassword { get; set; }
    }
}

