namespace SchoolProject.Data.Helpers
{
    public class JWTOptions
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int LifeTime { get; set; }
        public string SigningKey { get; set; }

    }
}
