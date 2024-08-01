using CLINICAL.Application;
using CLINICAL.UseCase.Commons.Bases;
using MediatR;

namespace CLINICAL.UseCase.UseCases.Analysis.Queries.GetAllQueryById;

public class GetAllAnalysisQueryById: IRequest<BaseResponse<GetAllAnalysisByIdResponseDto>>
{
    public int AnalysisId { get; set; }
}