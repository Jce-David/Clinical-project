using CLINICAL.UseCase.Commons.Bases;
using MediatR;

namespace CLINICAL.UseCase.UseCases.Analysis.Commands.ChangeStateCommand;

public class ChangeStateAnalysisCommand : IRequest<BaseResponse<bool>>
{
    public int AnalysisId { get; set; }
    public int State { get; set; }
}