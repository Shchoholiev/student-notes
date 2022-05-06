using System;

namespace StudentNotes.Core.Entities.Identity
{
    public class UserToken
    {
        string Token { get; set; }
        DateTime TokenExpiryTime { get; set; }
    }
}

