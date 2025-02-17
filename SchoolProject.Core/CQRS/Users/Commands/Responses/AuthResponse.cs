namespace SchoolProject.Core.CQRS.Users.Commands.Responses
{
    public class AuthResponse
    {
        public string Token { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public List<string>? Roles { get; set; }
        public DateTime ExpiresOn { get; set; }
    }
}
