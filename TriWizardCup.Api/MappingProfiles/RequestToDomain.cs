using AutoMapper;
using TriWizardCup.Entities.DbSet;
using TriWizardCup.Entities.Dtos.Requests;

namespace TriWizardCup.Api.MappingProfiles
{
    public class RequestToDomain : Profile
    {
        public RequestToDomain()
        {
            CreateMap<CreateWizardAchievementRequest, Achievement>()
                .ForMember(
                dest => dest.DuelsWon,
                opt => opt.MapFrom(src => src.Wins))
                .ForMember(
                dest => dest.Status,
                opt => opt.MapFrom(src => 1))
                .ForMember(
                dest => dest.AddedDate,
                opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(
                dest => dest.UpdatedDate,
                opt => opt.MapFrom(src => DateTime.UtcNow)).ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => src.WizardId));

            CreateMap<UpdateWizardAchievementRequest, Achievement>()
                .ForMember(
                dest => dest.DuelsWon,
                opt => opt.MapFrom(src => src.Wins))
                .ForMember(
                dest => dest.UpdatedDate,
                opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => src.WizardId));

            CreateMap<CreateWizardRequest, Wizard>()
                .ForMember(
                dest => dest.Status,
                opt => opt.MapFrom(src => 1))
                .ForMember(
                dest => dest.AddedDate,
                opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(
                dest => dest.UpdatedDate,
                opt => opt.MapFrom(src => DateTime.UtcNow));

            CreateMap<UpdateWizardRequest, Wizard>()
                .ForMember(
                dest => dest.UpdatedDate,
                opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => src.WizardId));
        }
    }
}
