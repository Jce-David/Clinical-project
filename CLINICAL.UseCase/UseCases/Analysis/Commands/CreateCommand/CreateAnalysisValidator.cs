    using FluentValidation;

    namespace CLINICAL.UseCase.UseCases.Analysis.Commands.CreateCommand;

    public class CreateAnalysisValidator : AbstractValidator<CreateAnalysisCommand>
    {
        public CreateAnalysisValidator()
        {
            RuleFor(x => x.Name)
                .NotNull().WithMessage("El campo Nombre no puede ser nulo")
                .NotEmpty().WithMessage("El Campo nombre no puede ser vacío");
        }
    }