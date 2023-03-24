using Microsoft.AspNetCore.Identity;

namespace RegisterLoginASP.Models.Domain
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string profilePicture { get; set; }
    }
}
