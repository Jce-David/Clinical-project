using AutoMapper;
using CLINICAL.Domain;
using CLINICAL.UseCase.UseCases.User.Commands.CreateCommand;

namespace CLINICAL.UseCase.Mappings;

public class UserMappingProfile: Profile
{
    public UserMappingProfile()
    {
        CreateMap<CreateUserCommand, User>();
    }
}