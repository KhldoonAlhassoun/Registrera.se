using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Registrera.se.Models
{
    public class Library
    {
        public Library() { }
        public int Id { get; set; }
        List<Course> courses { get; set; }

    }
}
