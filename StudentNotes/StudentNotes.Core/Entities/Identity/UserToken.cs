using System;

namespace StudentNotes.Core.Entities.Identity
{
    public class UserToken : EntityBase
    {
        public string Token { get; set; }

        public DateTime TokenExpiryTime { get; set; }
    }
}

