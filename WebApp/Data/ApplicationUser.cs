using Microsoft.AspNetCore.Identity;

namespace WebApp.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Nick { get; set; }
        public string? PhoneNumber { get; set; }
        public string? ProfilePicture { get; set; }
    }
}
