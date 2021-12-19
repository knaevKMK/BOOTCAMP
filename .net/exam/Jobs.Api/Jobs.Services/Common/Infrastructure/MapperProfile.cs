namespace Jobs.Services.Common.Infrastructure
{
using AutoMapper;
    using Jobs.Domain.Entites;
    using Jobs.Domain.ViewModels;
    using Jobs.Services.Commands.Candidate.Commands;

    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            this.CreateMap<AddCandidateCommand, Candidate>();

            this.CreateMap<Candidate, CandidateDetailsViewModel>()
                .ForMember(c=>c.Recruiter, opt=>opt.MapFrom(c=>c.Recruiter.LastName));

            this.CreateMap<Recruiter, RecruiterViewModel>();
            
            
            this.CreateMap<Skill, SkillViewModel>();

            this.CreateMap<Interview, InterviewViewModel>()
               .ForMember(c => c.Recruiter, opt => opt.MapFrom(c => c.Candidate.Recruiter.LastName))
               .ForMember(c => c.Job, opt => opt.MapFrom(c => c.Job.Title))
               .ForMember(c => c.Candidate, opt => opt.MapFrom(c => c.Candidate.LastName +" "+c.Candidate.FirstName ));
        }


    }
}
