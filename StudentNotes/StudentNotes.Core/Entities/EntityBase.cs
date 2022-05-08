using System;
using System.ComponentModel.DataAnnotations;

namespace StudentNotes.Core.Entities
{
    public class EntityBase
    {
        [Key]
        public int Id { get; set; }

    }
}
