using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace CLINICAL.Persistence.Context;

public class ApplicationDbContext
{
    private readonly IConfiguration _configuration;
    private readonly string _connection;
    
    public ApplicationDbContext( IConfiguration configuration )
    {
        _configuration = configuration;
        _connection = _configuration.GetConnectionString("ClinicalConnection");
    }

    public IDbConnection CreateConnection()
    {
        return new SqlConnection(_connection);
    }
    
}