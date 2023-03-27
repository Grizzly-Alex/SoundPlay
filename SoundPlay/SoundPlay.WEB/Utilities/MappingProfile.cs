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
        CreateMap<Basket, BasketViewModel>().ReverseMap()
            .ForMember(model => model.Id, opt => opt.MapFrom(view => view.Id))
            .ForMember(model => model.BuyerId, opt => opt.MapFrom(view => view.BuyerId));
    }
}