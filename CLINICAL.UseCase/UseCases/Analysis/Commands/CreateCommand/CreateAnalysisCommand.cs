using CLINICAL.UseCase.Commons.Bases;
using MediatR;

namespace CLINICAL.UseCase.UseCases.Analysis.Commands.CreateCommand;

public class CreateAnalysisCommand : IRequest<BaseResponse<bool>>
{
    public string Name { get; set; }
    
}