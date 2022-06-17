using AutoMapper;
using FishingBattle.Anglers.Service.DTOs;
using FishingBattle.Anglers.Service.Models;

namespace FishingBattle.Anglers.Service.MappingProfiles
{
    public class AnglerProfile : Profile
    {
        public AnglerProfile()
        {
            CreateMap<Angler, AnglerDto>().ReverseMap();
        }
    }
}
