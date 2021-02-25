using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Registrera.se.Models
{
    public class Place
    {
        public Place() { }

        
        public int Id { get; set; }
        [Required]
        public string Region { get; set; }
        [Required]
        public string City { get; set; }
    }
}
