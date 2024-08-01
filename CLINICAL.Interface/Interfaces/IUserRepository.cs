using CLINICAL.Domain;

namespace CLINICAL.Interface;

public interface IUserRepository: IGenericRepository<User>
{
    Task<User> GetUserByEmailAsync(string procedure, string email);
}