namespace ApiGateway.Api.Authentication.JwtBearer.Models
{
    public class UserAccount
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
