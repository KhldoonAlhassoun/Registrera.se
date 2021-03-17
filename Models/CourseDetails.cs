using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Registrera.se.Models
{
    public class CourseDetails
    {
        public CourseDetails() { }

        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string About { get; set; }

       
        [Required]
        public string Country { get; set; }
        
        [Required]
        public string City { get; set; }
        [Required]
        public string School { get; set; }
        [Required]
        public string Teacher { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }


    }
}


