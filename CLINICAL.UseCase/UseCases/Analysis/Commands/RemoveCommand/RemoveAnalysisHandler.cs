using AutoMapper;
using CLINICAL.Interface;
using CLINICAL.UseCase.Commons.Bases;
using CLINICAL.Utilities.Constants;
using MediatR;

namespace CLINICAL.UseCase.UseCases.Analysis.Commands.RemoveCommand;

public class RemoveAnalysisHandler: IRequestHandler<RemoveAnalysisCommand, BaseResponse<bool>>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public RemoveAnalysisHandler(IMapper mapper, IUnitOfWork unitOfWork )
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;   
    }
    
    public async Task<BaseResponse<bool>> Handle(RemoveAnalysisCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<bool>();

        try
        {
            
            response.Data = await _unitOfWork.Analysis
                .ExecAsync( SP.uspAnalysisRemove, new { request.AnalysisId });
            if (response.Data)
            {
                response.IsSucces = true;
                response.Message = "Eliminación Exitosa";
            }
        }
        catch( Exception ex )
        {
            response.Message = ex.Message;
        }

        return response;
    }
}