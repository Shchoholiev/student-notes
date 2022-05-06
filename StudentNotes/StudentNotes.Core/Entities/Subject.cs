using System;

namespace StudentNotes.Core.Entities
{
    public class Subject
    {
        int Id { get; set; }
        string Name { get; set; }
        Teacher Teacher { get; set; }
    }
}
