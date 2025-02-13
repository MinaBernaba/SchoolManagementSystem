namespace SchoolProject.Core.CQRS.Users.Queries.Responses
{
    public class GetUserMainInfoResponse
    {
        public string FullName { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Country { get; set; }
        public string? Address { get; set; }
    }
}
