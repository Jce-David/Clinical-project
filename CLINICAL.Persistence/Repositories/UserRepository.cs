using System.Data;
using CLINICAL.Domain;
using CLINICAL.Interface;
using CLINICAL.Persistence.Context;
using Dapper;

namespace CLINICAL.Persistence.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    private readonly ApplicationDbContext _context;
    public UserRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }


    public async Task<User> GetUserByEmailAsync(string procedure, string email)
    {
        using var connection = _context.CreateConnection();
        var parameters = new DynamicParameters();
        parameters.Add("Email", email);
        var user = await connection
            .QuerySingleOrDefaultAsync<User>(procedure, param: parameters, commandType: CommandType.StoredProcedure);
        return user;
    }
}