namespace StudentNotes.Application.IServices
{
    public interface ICloudStorageService
    {
        Task<string> UploadAsync(Stream fileStream, string fileName, string fileType, string containerName);

        Task DeleteAsync(string fileName, string containerName);
    }
}
