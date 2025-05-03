namespace StudentNotes.Application.IServices
{
    public interface IPasswordHasher
    {
        string Hash(string password);

        bool Check(string password, string passwordHash);
    }
}
