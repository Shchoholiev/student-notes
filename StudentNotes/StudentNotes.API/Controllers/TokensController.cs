using Microsoft.AspNetCore.Mvc;
using StudentNotes.API.ViewModels;
using StudentNotes.Application.IServices;
using System.Security.Claims;

namespace StudentNotes.API.Controllers
{
    public class TokensController : Controller
    {
        private readonly ITokenService _tokenService;

        private readonly IUsersService _usersService;

        public TokensController(ITokenService tokenService, IUsersService usersService)
        {
            this._tokenService = tokenService;
            this._usersService = usersService;
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh([FromBody] TokensModel tokensModel)
        {
            var principal = _tokenService.GetPrincipalFromExpiredToken(tokensModel.AccessToken);
            var email = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;

            var user = await _usersService.GetAsync(email);
            if (user == null || user?.UserToken?.RefreshToken != tokensModel.RefreshToken
                             || user?.UserToken?.RefreshTokenExpiryTime <= DateTime.Now)
            {
                return BadRequest();
            }

            var newAccessToken = _tokenService.GenerateAccessToken(principal.Claims);
            var newRefreshToken = _tokenService.GenerateRefreshToken();
            user.UserToken.RefreshToken = newRefreshToken;
            await this._usersService.UpdateAsync(user);

            return Ok(new TokensModel
            {
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken
            });
        }
    }
}
