using AutoMapper;
using SoundPlay.DTO.Models;
using SoundPlay.DTO.ViewModels;

namespace SoundPlay.DTO
{
	public class AppMappingProfile : Profile
	{
		public AppMappingProfile()
		{
			CreateMap<Brand, BrandViewModel>().ReverseMap();
			CreateMap<Category, CategoryViewModel>().ReverseMap();
			CreateMap<GuitarShape, GuitarShapeViewModel>().ReverseMap();
			CreateMap<Material, MaterialViewModel>().ReverseMap();
			CreateMap<TremoloType, TremoloTypeViewModel>().ReverseMap();
		}
	}
}
