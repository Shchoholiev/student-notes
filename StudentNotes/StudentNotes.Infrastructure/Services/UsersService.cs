using StudentNotes.Application.Descriptions;
using StudentNotes.Application.DTOs;
using StudentNotes.Application.IRepositories;
using StudentNotes.Application.IServices;
using StudentNotes.Core.Entities.Identity;

namespace StudentNotes.Infrastructure.Services
{
    public class UsersService : IUsersService
    {
        private readonly IGenericRepository<User> _usersRepository;

        private readonly IPasswordHasher _passwordHasher;

        public UsersService(IGenericRepository<User> userRepository, IPasswordHasher passwordHasher)
        {
            this._usersRepository = userRepository;
            this._passwordHasher = passwordHasher;
        }

        public async Task<OperationDetails> RegisterAsync(UserDTO userDTO)
        {
            var operationDetails = new OperationDetails();
            if ((await this._usersRepository.GetAllAsync(u => u.Email == userDTO.Email)).Any())
            {
                operationDetails.AddError("This email is already used!");
                return operationDetails;
            }

            var user = new User
            {
                Name = userDTO.Name,
                Email = userDTO.Email,
                Avatar = "https://educationalportal.blob.core.windows.net/avatars/profile_default.jpg",
                //Roles = new List<Role> { new Role { Id = 1 } },
            };

            try
            {
                user.PasswordHash = this._passwordHasher.Hash(userDTO.Password);
                await this._usersRepository.AddAsync(user);
            }
            catch (Exception e)
            {
                operationDetails.AddError(e.Message);
            }

            return operationDetails;
        }

        public async Task<OperationDetails> LoginAsync(UserDTO userDTO)
        {
            var user = await this.GetAsync(userDTO.Email);

            var operationDetails = new OperationDetails();
            if (user == null)
            {
                operationDetails.AddError("User with this email not found!");
                return operationDetails;
            }

            if (!this._passwordHasher.Check(userDTO.Password, user.PasswordHash))
            {
                operationDetails.AddError("Incorrect password!");
            }

            return operationDetails;
        }

        public async Task<User?> GetAsync(string email)
        {
            return (await this._usersRepository.GetAllAsync(u => u.Email == email)).FirstOrDefault();
        }

        public async Task UpdateAsync(User user)
        {
            this._usersRepository.Attach(user);
            await this._usersRepository.UpdateAsync(user);
        }

        public async Task DeleteAsync(string email)
        {
            var user = await this.GetAsync(email);
            await this._usersRepository.DeleteAsync(user);
        }
    }
}
