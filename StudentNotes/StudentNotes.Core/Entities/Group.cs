using System;
using System.Collections.Generic;
using StudentNotes.Core.Entities.Identity;

namespace StudentNotes.Core.Entities
{
    public class Group : EntityBase
    {
        public List<User> Users { get; set; }
        
        public string Name { get; set; }
        
        public User Headman { get; set; }
        
        public string InviteCode { get; set; }
    }
}
