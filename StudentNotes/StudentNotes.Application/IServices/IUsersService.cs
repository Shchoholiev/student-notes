using StudentNotes.Application.Descriptions;
using StudentNotes.Application.DTOs;
using StudentNotes.Core.Entities.Identity;

namespace StudentNotes.Application.IServices
{
    public interface IUsersService
    {
        Task<OperationDetails> RegisterAsync(UserDTO userDTO);

        Task<OperationDetails> LoginAsync(UserDTO userDTO);

        Task<User?> GetAsync(string email);

        Task UpdateAsync(User user);

        Task DeleteAsync(string email);
    }
}
