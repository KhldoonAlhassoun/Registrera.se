using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Registrera.se.Models
{
    public class Teacher : ApplicationUsers
    {
        public Teacher() { }
        public string About { get; set; }
    }
}
