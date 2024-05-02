using AutoMapper;
using TriWizardCup.Entities.DbSet;
using TriWizardCup.Entities.Dtos.Responses;

namespace TriWizardCup.Api.MappingProfiles
{
    public class DomainToResponse : Profile
    {
        public DomainToResponse()
        {
            CreateMap<Achievement, WizardAchievementResponse>()
                .ForMember(
                dest => dest.Wins,
                opt => opt.MapFrom(src => src.DuelsWon));

            CreateMap<Wizard, GetWizardResponse>()
                .ForMember(
                dest => dest.WizardId,
                opt => opt.MapFrom(src => src.Id))
                .ForMember(
                dest => dest.FullName,
                opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));
        }
    }
}
