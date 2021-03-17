using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Registrera.se.Models
{
    public class ViewModel
    {
        public IEnumerable<Place> PlacesList { get; set; }
        public IEnumerable<CourseDetails> CoursesList { get; set; }
        public IEnumerable<Teacher> TeachersList { get; set; }
    }
}
