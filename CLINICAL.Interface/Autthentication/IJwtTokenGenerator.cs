using CLINICAL.Domain;

namespace CLINICAL.Interface.Autthentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}