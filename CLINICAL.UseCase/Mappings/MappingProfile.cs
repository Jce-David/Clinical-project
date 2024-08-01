using AutoMapper;
using CLINICAL.Application;
using CLINICAL.Domain;
using CLINICAL.UseCase.UseCases.Analysis.Commands.ChangeStateCommand;
using CLINICAL.UseCase.UseCases.Analysis.Commands.CreateCommand;
using CLINICAL.UseCase.UseCases.Analysis.Commands.RemoveCommand;
using CLINICAL.UseCase.UseCases.Analysis.Commands.UpdateCommand;

namespace CLINICAL.UseCase.Mappings;

public class MappingProfile: Profile
{
    public MappingProfile()
    {
        CreateMap<Analysis, GetAllAnalysisResponseDto>()
            .ForMember(x => x.StateList,
                x
                    => x.MapFrom(y =>
                    y.State == 1 ? "ACTIVE" : "INACTIVE"))
            .ReverseMap();
        CreateMap<Analysis, GetAllAnalysisByIdResponseDto>()
            .ReverseMap();
        CreateMap<CreateAnalysisCommand, Analysis>();
        CreateMap<UpdateAnalysisCommand, Analysis>();
        CreateMap<RemoveAnalysisCommand, Analysis>();
        CreateMap<ChangeStateAnalysisCommand, Analysis>();
    }
}