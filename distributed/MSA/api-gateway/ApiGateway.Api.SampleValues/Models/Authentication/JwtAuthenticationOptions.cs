namespace ApiGateway.Api.SampleValues.Models.Authentication
{
    public class JwtAuthenticationOptions
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string SignInKey { get; set; }
        public int LifeTime { get; set; }
    }
}
