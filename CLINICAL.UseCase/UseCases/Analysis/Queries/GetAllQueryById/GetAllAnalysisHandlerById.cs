using AutoMapper;
using CLINICAL.Application;
using CLINICAL.Interface;
using CLINICAL.UseCase.Commons.Bases;
using CLINICAL.Utilities.Constants;
using MediatR;

namespace CLINICAL.UseCase.UseCases.Analysis.Queries.GetAllQueryById;

public class GetAllAnalysisHandlerById: IRequestHandler<GetAllAnalysisQueryById, BaseResponse<GetAllAnalysisByIdResponseDto>>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    public GetAllAnalysisHandlerById(IMapper mapper, IUnitOfWork UnitOfWork )
    {
        _mapper = mapper;
        _unitOfWork = UnitOfWork;
    }
    
    public async  Task<BaseResponse<GetAllAnalysisByIdResponseDto>> Handle(GetAllAnalysisQueryById request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<GetAllAnalysisByIdResponseDto>();
        try
        {
            var analysis = await _unitOfWork.Analysis
                .GetByIdAsync( SP.uspAnalysisById, request );
            if (analysis is null )
            {
                response.IsSucces = false;
                response.Message = "La consulta falla";
            }
            response.IsSucces = true;
            response.Data =  _mapper.Map<GetAllAnalysisByIdResponseDto>(analysis);
            response.Message = "La consulta exitosa";
        }
        catch( Exception ex )
        {
            response.Message = ex.Message;
        }

        return response;
    }
}