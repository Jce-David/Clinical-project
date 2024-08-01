using CLINICAL.Application;
using CLINICAL.UseCase.Commons.Bases;
using MediatR;

namespace CLINICAL.UseCase.UseCases.Analysis.Queries.GetAllQuery;

public class GetAllAnalysisQuery : IRequest<BaseResponse<IEnumerable<GetAllAnalysisResponseDto>>>
{
    
}