using AutoMapper;
using CLINICAL.Interface;
using CLINICAL.UseCase.Commons.Bases;
using CLINICAL.Utilities.Constants;
using CLINICAL.Utilities.HelperExtensions;
using MediatR;

namespace CLINICAL.UseCase.UseCases.Analysis.Commands.ChangeStateCommand;

public class ChangeStateAnalysisHandler : IRequestHandler<ChangeStateAnalysisCommand, BaseResponse<bool>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ChangeStateAnalysisHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task<BaseResponse<bool>> Handle(ChangeStateAnalysisCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<bool>();
        try
        {
            var analysis = _mapper.Map<Domain.Analysis>(request);
            var parameters = new { analysis.AnalysisId, analysis.State };
            response.Data = await _unitOfWork.Analysis
                .ExecAsync(SP.uspAnalysisChangeState, parameters);
            if ( response.Data)
            {
                response.IsSucces = true;
                response.Message = "Cambio de estado exitoso";
            }
        }
        catch (Exception ex)
        {
            response.Message = ex.Message;
        }
        return response;
    }
}