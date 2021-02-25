using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Registrera.se.Models
{
    public class Course
    {
        public Course() { }

        public int Id { get; set; }
        
        [Required]
        public string Title { get; set; }

        [Required]
        public string About { get; set; }

        
        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        
        [Required]
        public Place place { get; set; }
        [Required]
        public Teacher teacher { get; set; }
    }
}

