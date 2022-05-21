namespace StudentNotes.Core.Entities
{
    public class Subject : EntityBase
    {
        public string Name { get; set; }
        
        public List<Teacher> Teachers { get; set; }
    }
}
