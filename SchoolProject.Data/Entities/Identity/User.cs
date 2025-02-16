using Microsoft.AspNetCore.Identity;

namespace SchoolProject.Data.Entities.Identity
{
    public class User : IdentityUser<int>
    {
        public string FullName { get; set; }
        public override string Email { get; set; }
        public override string UserName { get; set; }
        public string? Address { get; set; }
        public string? Country { get; set; }
    }
}
