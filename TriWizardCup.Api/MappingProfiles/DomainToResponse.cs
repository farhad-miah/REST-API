using AutoMapper;
using TriWizardCup.Entities.DbSet;
using TriWizardCup.Entities.Dtos.Responses;
using TriWizardCup.Entities.Dtos.Responses.v1;

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

            CreateMap<Achievement, Entities.Dtos.Responses.v2.WizardAchievementResponse>()
                .ForMember(
                dest => dest.Wins,
                opt => opt.MapFrom(src => src.DuelsWon))
                .ForMember(
                dest => dest.NameInAnnouncement,
                opt => opt.MapFrom(src => $"{src.Wizard!.FirstName} {src.Wizard.LastName}"));


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
