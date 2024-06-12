using AutoMapper;
using GodlessAPI.Models;
using GodlessAPI.Models.Dto;

namespace GodlessAPI
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Godless, GodlessDTO>();
            CreateMap<GodlessDTO, Godless>();

            CreateMap<Godless, GodlessCreatedDTO>().ReverseMap();
            CreateMap<Godless, GodlessUpdateDTO>().ReverseMap();
         //--------------------------------------------------------
            CreateMap<GodNumber, GodNumberDTO>();
            CreateMap<GodNumberDTO, GodNumber>();

            CreateMap<GodNumber, GodNumberCreatedDTO>().ReverseMap();
            CreateMap<GodNumber, GodNumberUpdatedDTO>().ReverseMap();

        }
    }
}
