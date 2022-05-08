using System;

namespace StudentNotes.Core.Entities.Identity
{
    public class Role : EntityBase
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
