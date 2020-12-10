using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities.Tokens
{
    public class RefreshToken
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int Token { get; set; }
        public DateTime ExpiresAt { get; set; }
    }
}
