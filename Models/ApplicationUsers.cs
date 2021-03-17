using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Registrera.se.Models
{
    public abstract class ApplicationUsers : IdentityUser
    {
        [Required]
        public string Name { get; set; }
    }
}