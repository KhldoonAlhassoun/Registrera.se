using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Registrera.se.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Registrera.se
{
    public class ApplicationUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<ApplicationUsers, IdentityRole>
    {
        public ApplicationUserClaimsPrincipalFactory(UserManager<ApplicationUsers> userManager, RoleManager<IdentityRole> roleManager, IOptions<IdentityOptions> options)
            :base(userManager, roleManager,options)
        {

        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUsers user)
        {
            var userIdentity = await base.GenerateClaimsAsync(user);
            userIdentity.AddClaim(new Claim("UserId", user.Id ?? ""));
            userIdentity.AddClaim(new Claim("UserName", user.Name ?? ""));
            userIdentity.AddClaim(new Claim("UserEmail", user.Email ?? ""));

            return userIdentity;
        }
    }
}
