namespace SoundPlay.BLL.Utility;

public sealed class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Brand, BrandViewModel>().ReverseMap();
        CreateMap<GuitarShape, GuitarShapeViewModel>().ReverseMap();
        CreateMap<Material, MaterialViewModel>().ReverseMap();
        CreateMap<TremoloType, TremoloTypeViewModel>().ReverseMap();
        CreateMap<Color, ColorViewModel>().ReverseMap();
        CreateMap<PickupSet, PickupSetViewModel>().ReverseMap();
        CreateMap<Guitar, GuitarViewModel>().ReverseMap();
        CreateMap<GuitarViewModel, BasketPosition>()
            .ForMember(position => position.ProductId, opt => opt.MapFrom(guitar => guitar.Id))
            .ForMember(position => position.ProductName, opt => opt.MapFrom(guitar => guitar.Name))
            .ForMember(position => position.ProductPictureUrl, opt => opt.MapFrom(guitar => guitar.PictureUrl))
            .ForMember(position => position.ProductPrice, opt => opt.MapFrom(guitar => guitar.Price));
    }
}