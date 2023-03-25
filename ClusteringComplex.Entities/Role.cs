
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClusteringComplex.Entities
{
    public class Role 
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string NameOfRole { get; set; }

        [MaxLength(254)]
        public string DescriptionOfRole { get; set; }

        public ICollection <User> Users { get; set; } 

        public Role()
        {
            Users = new List<User>();
        }
    }
}
