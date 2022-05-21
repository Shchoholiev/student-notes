using Microsoft.AspNetCore.Mvc;
using StudentNotes.Application.IServices;

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
    }
}
