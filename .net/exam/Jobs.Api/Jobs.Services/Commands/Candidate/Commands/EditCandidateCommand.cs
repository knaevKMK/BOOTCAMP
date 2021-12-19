namespace Jobs.Services.Commands.Candidate.Commands
{
    using AutoMapper;
    using Jobs.Services.Common.Infrastructure;
    using Jobs.Services.Common.Interfaces;
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    public class EditCandidateCommand : AddCandidateCommand
    {
        public string Id { get; set; }
    }

    public class EditCandidateCommandHandler : AppRequestHandler<EditCandidateCommand, string>
    {
    public EditCandidateCommandHandler(IApplicaitonDbContext data, IMapper mapper) : base(data, mapper)
    {
    }
        public override async Task<string> Handle(EditCandidateCommand request, CancellationToken cancellationToken)
    {

            Domain.Entites.Candidate candidate = _data.Candidates.FirstOrDefault(c => c.Id.ToString().Equals(request.Id));
        if (candidate == null)
        {
            throw new NullReferenceException("Candidate with this Id is unvaileble");
        }
        candidate.FirstName = request.FirstName;
        candidate.LastName = request.LastName;
        candidate.Email = request.Email;
        candidate.Bio = request.Bio;
        candidate.BirthDate = request.BirthDate;


        await _data.SaveChangesAsync(CancellationToken.None);
        return candidate.Id;
    }
}
}
