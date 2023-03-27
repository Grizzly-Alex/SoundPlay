using SoundPlay.Core.Models.Entities.Items;
using SoundPlay.Core.Models.Entities.Products;
using SoundPlay.Web.ViewModels.Basket;
using SoundPlay.Web.ViewModels.Entities;
using SoundPlay.Web.ViewModels.Pagination;
using SoundPlay.Web.ViewModels.Products;
using SoundPlay.Web.ViewModels.User;

namespace SoundPlay.Web.Utilities;

public sealed class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<AppUser, RegisterUserViewModel>().ReverseMap();
		CreateMap<AppUser, EditUserViewModel>().ReverseMap();
		CreateMap(typeof(PagedList<>), typeof(PagedListViewModel<>));
		CreateMap<GuitarCategory, GuitarCategoryViewModel>().ReverseMap();
		CreateMap<Brand, BrandViewModel>().ReverseMap();
        CreateMap<GuitarShape, GuitarShapeViewModel>().ReverseMap();
        CreateMap<Material, MaterialViewModel>().ReverseMap();
        CreateMap<TremoloType, TremoloTypeViewModel>().ReverseMap();
        CreateMap<Color, ColorViewModel>().ReverseMap();
        CreateMap<PickupSet, PickupSetViewModel>().ReverseMap();
        CreateMap<Guitar, GuitarViewModel>().ReverseMap();
        CreateMap<GuitarViewModel, BasketItemViewModel>()
            .ForMember(position => position.ProductId, opt => opt.MapFrom(guitar => guitar.Id))
            .ForMember(position => position.ProductName, opt => opt.MapFrom(guitar => guitar.Name))
            .ForMember(position => position.ProductPictureUrl, opt => opt.MapFrom(guitar => guitar.PictureUrl))
            .ForMember(position => position.ProductPrice, opt => opt.MapFrom(guitar => guitar.Price));
    }
}