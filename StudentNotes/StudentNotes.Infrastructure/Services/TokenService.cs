using System.Security.Claims;

namespace StudentNotes.Infrastructure.Services
{
    public class TokenService : StudentNotes.Application.IServices.ITokenService
    {
        public string GenerateAccessToken(IEnumerable<Claim> claims)
        {
            throw new NotImplementedException();
        }

        public string GenerateRefreshToken()
        {
            throw new NotImplementedException();
        }

        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            throw new NotImplementedException();
        }
    }
}
