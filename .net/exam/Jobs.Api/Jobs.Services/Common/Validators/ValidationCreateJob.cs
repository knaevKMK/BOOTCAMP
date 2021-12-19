namespace Jobs.Services.Common.Validators
{
    using FluentValidation;
    using Jobs.Services.Commands.Job.Commnads;

    public  class ValidationCreateJob : AbstractValidator<AddJobCommand>
    {

        public ValidationCreateJob()
        {

            RuleFor(j => j.Title)
            .NotNull()
            .NotEmpty();

            RuleFor(j => j.Description)
           .NotNull()
           .NotEmpty();

            RuleFor(j => j.Salary)
              .NotNull()
              .GreaterThan(decimal.Parse("500.00"));

            RuleFor(j => j.Skills)
                .NotNull();
        }
    }
}
