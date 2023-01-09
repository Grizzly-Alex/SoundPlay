using AutoMapper;
using SoundPlay.BLL.ViewModels;
using SoundPlay.DAL.Models;

namespace SoundPlay.BLL.Models
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Brand, BrandViewModel>().ReverseMap();
            CreateMap<Category, CategoryViewModel>().ReverseMap();
            CreateMap<GuitarShape, GuitarShapeViewModel>().ReverseMap();
            CreateMap<Material, MaterialViewModel>().ReverseMap();
            CreateMap<TremoloType, TremoloTypeViewModel>().ReverseMap();
        }
    }
}