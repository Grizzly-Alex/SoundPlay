using AutoMapper;
using SoundPlay.BLL.ViewModels.Admin;
using SoundPlay.DAL.Models;

namespace SoundPlay.BLL.Utility
{
    public sealed class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Brand, BrandViewModel>().ReverseMap();
            CreateMap<Category, CategoryViewModel>().ReverseMap();
            CreateMap<GuitarShape, GuitarShapeViewModel>().ReverseMap();
            CreateMap<Material, MaterialViewModel>().ReverseMap();
            CreateMap<TremoloType, TremoloTypeViewModel>().ReverseMap();
            CreateMap<Color, ColorViewModel>().ReverseMap();
            CreateMap<PickupSet, PickupSetViewModel>().ReverseMap();
            CreateMap<Guitar, GuitarViewModel>().ReverseMap();
        }
    }
}