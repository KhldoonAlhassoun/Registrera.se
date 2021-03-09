using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Registrera.se.Models
{
    public class Teacher : User
    {
        public Teacher() { }

        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string About { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
