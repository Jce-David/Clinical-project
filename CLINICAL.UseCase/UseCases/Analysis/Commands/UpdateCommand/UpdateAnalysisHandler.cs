    using AutoMapper;
    using CLINICAL.Interface;
    using CLINICAL.UseCase.Commons.Bases;
    using CLINICAL.UseCase.UseCases.Analysis.Queries.GetAllQuery;
    using CLINICAL.Utilities.Constants;
    using CLINICAL.Utilities.HelperExtensions;
    using MediatR;

    namespace CLINICAL.UseCase.UseCases.Analysis.Commands.UpdateCommand;

    public class UpdateAnalysisHandler: IRequestHandler<UpdateAnalysisCommand, BaseResponse<bool>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateAnalysisHandler( IMapper mapper, IUnitOfWork unitOfWork )
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        
        public async Task<BaseResponse<bool>> Handle(UpdateAnalysisCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();

            try
            {
                var analysis = _mapper.Map<Domain.Analysis>(request);
                var parameters = new { analysis.Name, analysis.AnalysisId };
                response.Data = await _unitOfWork.Analysis
                    .ExecAsync(SP.uspAnalysisEdit, parameters);
                if (response.Data)
                {
                    response.Message = "Mensaje exitosa";
                    response.IsSucces = true;
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
    }