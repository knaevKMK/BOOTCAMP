
namespace Jobs.Services.Common.Validators
{
    using FluentValidation;
    using Jobs.Services.Commands.Candidate.Commands;
    using System;

    public    class ValidationCandidateCreate  : AbstractValidator<AddCandidateCommand>
    {
        public ValidationCandidateCreate()
        {
            RuleFor(c => c.FirstName)
             .NotNull()
             .NotEmpty();
            RuleFor(c => c.LastName)
            .NotNull()
            .NotEmpty();

            RuleFor(c => c.Email)
            .NotNull()
            .NotEmpty();

            RuleFor(c => c.Bio)
            .NotNull()
            .NotEmpty();

            RuleFor(c => c.BirthDate)
               .NotNull()
               .InclusiveBetween(DateTime.Parse("1970/01/01"), DateTime.Parse("2003/01/01"));


            RuleFor(c => c.Recruiter.LastName)
                 .NotNull()
                 .NotEmpty();

            RuleFor(c => c.Recruiter.Email)
                 .NotNull()
                 .NotEmpty();

            RuleFor(c => c.Recruiter.Country)
                 .NotNull()
                 .NotEmpty();


            RuleFor(c => c.Skills)
                .NotNull();

        }


    }
}
