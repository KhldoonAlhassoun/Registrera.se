using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Registrera.se
{
    public class EnsureRolesExistService
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public EnsureRolesExistService(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        public async Task Initialize()
        {
            if (!await roleManager.RoleExistsAsync("Administrator"))
            {
                await roleManager.CreateAsync(new IdentityRole("Administrator"));
            }

            if (!await roleManager.RoleExistsAsync("Teacher"))
            {
                await roleManager.CreateAsync(new IdentityRole("Teacher"));
            }

            if (!await roleManager.RoleExistsAsync("Student"))
            {
                await roleManager.CreateAsync(new IdentityRole("Student"));
            }
        }
    }
}
