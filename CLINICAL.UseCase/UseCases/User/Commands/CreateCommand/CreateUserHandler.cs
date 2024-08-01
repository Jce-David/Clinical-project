using System.Reflection.Metadata;
using AutoMapper;
using CLINICAL.Interface;
using CLINICAL.UseCase.Commons.Bases;
using CLINICAL.Utilities.HelperExtensions;
using MediatR;
using Entity = CLINICAL.Domain;
using BC = BCrypt.Net.BCrypt;

namespace CLINICAL.UseCase.UseCases.User.Commands.CreateCommand;

public class CreateUserHandler: IRequestHandler<CreateUserCommand, BaseResponse<bool>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateUserHandler( IUnitOfWork unitOfWork, IMapper mapper )
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<BaseResponse<bool>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<bool>();

        try
        {
            var user = _mapper.Map<Entity.User>(request);
            user.Password = BC.HashPassword(user.Password);
            var parameters = new
            {
                user.FirstName, user.LastName, user.Email,
                user.Password, user.RoleId
            };

            response.Data = await _unitOfWork.User.ExecAsync("uspUserRegister", parameters);
            if (response.Data)
            {
                response.IsSucces = true;
                response.Message = "Mensaje Exitoso";
            }
        }
        catch (Exception ex)
        {
            response.Message = ex.Message;
        }

        return response;
    }
}