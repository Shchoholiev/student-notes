namespace StudentNotes.Core.Entities
{
    public class Subject : EntityBase
    {
        public string Name { get; set; }
        
        public Teacher Teacher { get; set; }
    }
}
