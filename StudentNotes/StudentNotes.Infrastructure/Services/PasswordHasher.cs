using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace StudentNotes.Infrastructure.Services
{
    public class PasswordHasher : StudentNotes.Application.IServices.IPasswordHasher
    {
        public string Hash(string password)
        {
            var salt = new byte[128 / 8];
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetNonZeroBytes(salt);
            }

            var r = new Random();
            int iterationCount = r.Next(0, 1000);

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: iterationCount,
                numBytesRequested: 256 / 8));

            string passwordHash = iterationCount.ToString() + "." + Convert.ToBase64String(salt) + "." + hashed;
            return passwordHash;
        }

        public bool Check(string password, string passwordHash)
        {
            var salt = Convert.FromBase64String(passwordHash.Split(".")[1]);
            int iterationCount = int.Parse(passwordHash.Split(".").First());
            
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: iterationCount,
                numBytesRequested: 256 / 8));
                
            return hashed == passwordHash.Split(".").Last();
        }
    }
}
