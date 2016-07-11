using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Welp.Web.Data;
using Welp.Web.Models;

namespace Welp.Web.Helpers
{
    public interface IUserManagerService
    {
        Profile GetProfile(ClaimsPrincipal principal);
        ApplicationUser GetUser(Profile profile);
        ApplicationUser GetUser(ClaimsPrincipal principal);
        string GetUserFirstName(ClaimsPrincipal principal);
    }


    public class UserManagerService : IUserManagerService
    {
        private UserManager<ApplicationUser> _userManager;
        private ApplicationDbContext _context;

        public UserManagerService(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public Profile GetProfile(ClaimsPrincipal principal)
        {
            var id = _userManager.GetUserId(principal);
            return _context.Profiles.FirstOrDefault(p => p.Id == id);
        }

        public ApplicationUser GetUser(Profile profile)
        {
            return profile != null ? _context.Users.FirstOrDefault(u => u.Id == profile.Id) : null;
        }

        public ApplicationUser GetUser(ClaimsPrincipal principal)
        {
            return _userManager.GetUserAsync(principal).Result;
        }

        public string GetUserFirstName(ClaimsPrincipal principal)
        {
            var id = _userManager.GetUserId(principal);
            if (id != null)
            {
                var profile = _context.Profiles.FirstOrDefault(p => p.Id == id);
                var name = profile != null ? profile.FirstName : _userManager.GetUserName(principal);
                if (name != null && name.Contains(' '))
                    return name.Substring(0, name.IndexOf(' '));
                else
                    return name;
            }
            return null;
        }
    }
}
