using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using OnlineFoodDelivery.Module;


namespace OnlineFoodDelivery.Utility
{
    public class JwtHelper
    {
        private readonly IConfiguration _configuration;

        public JwtHelper(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            
        }

        public string GenerateToken(User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            if (string.IsNullOrEmpty(user.Username)) throw new ArgumentException("Username cannot be null or empty.", nameof(user.Username));

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Username),
         
            };

            var key = GetSymmetricSecurityKey("JwtSettings:Key");
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["JwtSettings:Issuer"],
                audience: _configuration["JwtSettings:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string GenerateResetToken(User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            if (string.IsNullOrEmpty(user.Email)) throw new ArgumentException("Username cannot be null or empty.", nameof(user.Email));

            var claims = new[]
            {
                new Claim(ClaimTypes.Email, user.Username),

            };

            var key = GetSymmetricSecurityKey("JwtSettings:Key");
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["JwtSettings:Issuer"],
                audience: _configuration["JwtSettings:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }






        public async Task<bool> ValidateResetTokenAsync(string token)
        {
            if (string.IsNullOrEmpty(token)) throw new ArgumentException("Token cannot be null or empty.", nameof(token));

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]);
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true, 
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidIssuer = _configuration["JwtSettings:Issuer"],
                ValidAudience = _configuration["JwtSettings:Audience"]
            };

            try
            {
                tokenHandler.ValidateToken(token, validationParameters, out var validatedToken);

               
                if (validatedToken is JwtSecurityToken jwtToken &&
                    jwtToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                {
                    return true; 
                }

                return false; 
            }
            catch (Exception)
            {
                return false; 
            }
        }





        private SymmetricSecurityKey GetSymmetricSecurityKey(string configKey)
        {
            var secretKey = _configuration[configKey];
            if (string.IsNullOrEmpty(secretKey))
            {
                throw new InvalidOperationException($"Configuration for {configKey} is missing or invalid.");
            }
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        }
    }
}
