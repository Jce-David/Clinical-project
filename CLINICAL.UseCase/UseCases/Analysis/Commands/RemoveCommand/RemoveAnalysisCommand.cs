using CLINICAL.UseCase.Commons.Bases;
using MediatR;

namespace CLINICAL.UseCase.UseCases.Analysis.Commands.RemoveCommand;

public class RemoveAnalysisCommand: IRequest<BaseResponse<bool>>
{
    public int AnalysisId { get; set; }
}