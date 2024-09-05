using System;
using System.Security.Cryptography;

namespace CodingInterviewQuestionsApi.Services
{
    public class JwtKeyGeneratorService
    {
        public string GenerateKey()
        {
            var key = new byte[32]; // Generate a 256-bit key (32 bytes)
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(key);
            }
            return Convert.ToBase64String(key);
        }
    }
}
