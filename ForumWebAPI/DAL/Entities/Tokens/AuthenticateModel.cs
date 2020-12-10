using System;


namespace DAL.Entities.Tokens
{
    public class AuthenticateModel
    {
        public string AccessToken { get; set; }
        public int RefreshToken { get; set; }
        public DateTime ExpiresAt { get; set; }
    }
}

