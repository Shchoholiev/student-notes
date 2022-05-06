using System;

namespace StudentNotes.Core.Entities
{
    public class Teacher
    {
        int Id { get; set; }
        string Name { get; set; }
        string Email { get; set; }
        string Avatar { get; set; }
        List<Subject> Subjects { get; set; }
    }
}
