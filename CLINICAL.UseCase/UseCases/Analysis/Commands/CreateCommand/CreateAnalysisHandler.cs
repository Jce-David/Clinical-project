using System.Reflection.Metadata;
using AutoMapper;
using CLINICAL.Interface;
using CLINICAL.UseCase.Commons.Bases;
using MediatR;
using CLINICAL.Domain;
using CLINICAL.Utilities.Constants;
using CLINICAL.Utilities.HelperExtensions;

namespace CLINICAL.UseCase.UseCases.Analysis.Commands.CreateCommand;

public class CreateAnalysisHandler: IRequestHandler<CreateAnalysisCommand, BaseResponse<bool>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateAnalysisHandler( IMapper mapper, IUnitOfWork unitOfWork )
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;   
    }
    public async Task<BaseResponse<bool>> Handle(CreateAnalysisCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<bool>();
        try
        {
            var analysis = _mapper.Map<Domain.Analysis>(request);
            var parameters = new { analysis.Name };
            
            response.Data = await _unitOfWork.Analysis
                .ExecAsync(SP.uspAnalysisRegister, parameters); 
            if (response.Data)
            {
                response.IsSucces = true;
                response.Message = "Se registró correctamemte";
            }
        }
        catch( Exception ex)
        {
            response.Message = ex.Message;
        }
        return response;
    }
}