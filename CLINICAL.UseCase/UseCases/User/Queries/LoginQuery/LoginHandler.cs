using System.Reflection.Metadata;
using CLINICAL.Interface;
using CLINICAL.Interface.Autthentication;
using CLINICAL.UseCase.Commons.Bases;
using MediatR;

namespace CLINICAL.UseCase.UseCases.User.Queries.LoginQuery;

public class LoginHandler : IRequestHandler<LoginQuery, BaseResponse<string>>
{
    public readonly IUnitOfWork _UnitOfWork;
    public readonly IJwtTokenGenerator _JwtTokenGenerator;

    public LoginHandler(IUnitOfWork unitOfWork, IJwtTokenGenerator jwtTokenGenerator   )
    {
        _UnitOfWork = unitOfWork;
        _JwtTokenGenerator = jwtTokenGenerator;
    }
    public async Task<BaseResponse<string>> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<string>();
        try
        {
            var user = await _UnitOfWork.User.GetUserByEmailAsync("uspUserByEmail", request.Email);
            if (user is null)
            {
                response.IsSucces = true;
                response.Message = "EL usuario no existe en la base de datos";
                return response;
            }
            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
            {
                response.IsSucces = false;
                response.Message = "La contraseña es incorrecta";
                return response;
            }

            response.IsSucces = true;
            response.Data = _JwtTokenGenerator.GenerateToken(user);
            response.Message = "Correcto";
        }
        catch (Exception ex)
        {
            response.Message = ex.Message;
        }
        return response;
    }
}