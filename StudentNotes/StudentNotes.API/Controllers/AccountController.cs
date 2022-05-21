using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentNotes.API.ViewModels;
using StudentNotes.Application.DTOs;
using StudentNotes.Application.IRepositories;
using StudentNotes.Application.IServices;
using StudentNotes.Core.Entities.Identity;
using System.Security.Claims;

namespace StudentNotes.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/account")]
    public class AccountController : Controller
    {
        private readonly IUsersService _usersService;

        private readonly ITokenService _tokenService;

        private readonly IGenericRepository<Role> _rolesRepository;

        public AccountController(IUsersService usersService, ITokenService tokenService,
                                 IGenericRepository<Role> rolesRepository)
        {
            this._usersService = usersService;
            this._tokenService = tokenService;
            this._rolesRepository = rolesRepository;
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userDTO = new UserDTO { Name = model.Name, Email = model.Email, Password = model.Password };
                var result = await this._usersService.RegisterAsync(userDTO);

                if (result.Succeeded)
                {
                    var user = await this._usersService.GetAsync(userDTO.Email);
                    var tokens = await this.UpdateUserTokens(user);
                    return Ok(tokens);
                }
                else
                {
                    return BadRequest(result.Messages);
                }
            }

            return BadRequest();
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userDTO = new UserDTO { Email = model.Email, Password = model.Password };
                var result = await this._usersService.LoginAsync(userDTO);

                if (result.Succeeded)
                {
                    var user = await this._usersService.GetAsync(userDTO.Email);
                    var tokens = await this.UpdateUserTokens(user);
                    return Ok(tokens);
                }
                else
                {
                    return BadRequest(result.Messages);
                }
            }

            return BadRequest();
        }

        [HttpGet]
        public async Task<ActionResult<User>> Profile()
        {
            var email = User?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            var user = await this._usersService.GetAsync(email);
            return user;
        }

        private async Task<Object> UpdateUserTokens(User user)
        {
            var claims = await this.GetClaims(user);
            var accessToken = this._tokenService.GenerateAccessToken(claims);
            var refreshToken = this._tokenService.GenerateRefreshToken();

            user.UserToken = new UserToken
            {
                RefreshToken = refreshToken,
                RefreshTokenExpiryTime = DateTime.Now.AddDays(7),
            };
            await this._usersService.UpdateAsync(user);

            return new
            {
                Token = accessToken,
                RefreshToken = refreshToken
            };
        }

        private async Task<IEnumerable<Claim>> GetClaims(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email),
            };

            foreach (var r in user.Roles)
            {
                var role = await this._rolesRepository.GetOneAsync(r.Id);
                claims.Add(new Claim(ClaimTypes.Role, role.Name));
            }

            return claims;
        }
    }
}
