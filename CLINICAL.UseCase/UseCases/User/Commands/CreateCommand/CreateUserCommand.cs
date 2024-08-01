using CLINICAL.UseCase.Commons.Bases;
using MediatR;

namespace CLINICAL.UseCase.UseCases.User.Commands.CreateCommand;

public class CreateUserCommand  : IRequest<BaseResponse<bool>>
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? PassWord { get; set; }
    public int RoleId { get; set; }
    
}