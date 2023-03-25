using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClusteringComplex.MVC.Models
{
    public class VKPageModel
    {
        [Required]
        public int VKId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Login { get; set; }

        [Required]
        [MaxLength(50)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
