using CLINICAL.UseCase.Commons.Bases;
using MediatR;

namespace CLINICAL.UseCase.UseCases.Analysis.Commands.UpdateCommand;

public class UpdateAnalysisCommand: IRequest<BaseResponse<bool>>
{
    public string? Name { get; set; }
    public int AnalysisId { get; set; }
}