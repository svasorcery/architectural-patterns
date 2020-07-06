namespace ApiGateway.Clients.MvcAngular.Models
{
    public class TokenResponse
    {
        public string Subject { set; private get; }
        public int Expires_in { set; private get; }
        public string Access_token { set; private get; }

        public string Sub => Subject;
        public int ExpiresIn => Expires_in;
        public string AccessToken => Access_token;
    }
}
