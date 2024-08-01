using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CLINICAL.Domain;
using CLINICAL.Interface.Autthentication;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace CLINICAL.Infrastructure.Authentication;

public class JwtTokenGenerator: IJwtTokenGenerator
{
    private readonly JwtSettings _jwtSettings;

    public JwtTokenGenerator( IOptions<JwtSettings> jwtSettings )
    {
        _jwtSettings = jwtSettings.Value;
    }

    public string GenerateToken(User user)
    {
        var signingCreadentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret)),SecurityAlgorithms.HmacSha256);
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.UserId.ToString()!),
            new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName!),
            new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName!),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

        var SecurityToken = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            expires: DateTime.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes),
            claims: claims,
            signingCredentials: signingCreadentials
        );
        
        return new JwtSecurityTokenHandler().WriteToken(SecurityToken);
    }
}