using AutoMapper;
using CLINICAL.Application;
using CLINICAL.Interface;
using CLINICAL.UseCase.Commons.Bases;
using CLINICAL.Utilities.Constants;
using MediatR;

namespace CLINICAL.UseCase.UseCases.Analysis.Queries.GetAllQuery;

public class GetAllAnalysisHandler : IRequestHandler< GetAllAnalysisQuery, 
    BaseResponse<IEnumerable<GetAllAnalysisResponseDto>>>


{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    //  private readonly IAnalysisRepository _analysisRepository;

    public GetAllAnalysisHandler( IUnitOfWork unitOfWork,  IMapper mapper )
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<BaseResponse<IEnumerable<GetAllAnalysisResponseDto>>> Handle(GetAllAnalysisQuery request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<IEnumerable<GetAllAnalysisResponseDto>>() ;
        try
        {
            var analysis = await _unitOfWork.Analysis
                .GetAllAsync(SP.uspAnalysisList);
            if (analysis is not null)
            {
                response.IsSucces = true;
                response.Data = _mapper.Map<IEnumerable<GetAllAnalysisResponseDto>>(analysis);
                response.Message = "Consulta Exitosa";
                return response;
            }
        }
        catch (Exception ex)
        {
            response.Message = ex.Message;
        }

        return response;
    }
}