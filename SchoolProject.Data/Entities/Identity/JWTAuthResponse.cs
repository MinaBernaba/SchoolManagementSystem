using System.Text.Json.Serialization;

namespace SchoolProject.Data.Entities.Identity
{
    public class JWTAuthResponse
    {
        public string Token { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public List<string>? Roles { get; set; }

        [JsonIgnore]
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiration { get; set; }

    }
}
