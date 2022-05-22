namespace StudentNotes.API.ViewModels
{
    public class RegisterViewModel
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public bool isLeader { get; set; }

        public string AdditionalText { get; set; }
    }
}
