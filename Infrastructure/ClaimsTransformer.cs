using DentistBookingForm.Data;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using System.Linq;

namespace DentistBookingForm.Infrastructure
{
    public class AddRolesClaimsTransformation : IClaimsTransformation
    {
        private readonly ApplicationDbContext _applicationDbContext;



        public AddRolesClaimsTransformation(ApplicationDbContext applicationDb)
        {
            _applicationDbContext = applicationDb;
        }

        public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            // Clone current identity
            var clone = principal.Clone();
            var newIdentity = (ClaimsIdentity)clone.Identity;

            // Support AD and local accounts
            var nameId = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier ||
                                                              c.Type == ClaimTypes.Name);
            if (nameId == null)
            {
                return principal;
            }

            //Get user from database
            var user = await _applicationDbContext.Users.FindAsync(nameId.Value.ToString());

            if (user == null)
            {
                return principal;
            }

            // Add role claims to cloned identity
            var nameClaim = new Claim(type: ClaimTypes.Name, value: user.FirstName);
            var surenameClaim = new Claim(type: ClaimTypes.Surname, user.LastName);

            newIdentity.AddClaim(nameClaim);
            newIdentity.AddClaim(surenameClaim);


            return clone;
        }
    }
}
