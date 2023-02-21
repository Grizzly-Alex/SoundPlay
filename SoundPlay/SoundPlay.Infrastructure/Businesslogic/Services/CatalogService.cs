namespace SoundPlay.Infrastructure.Businesslogic.Services;

public class CatalogService : ICatalogService<CatalogProductViewModel>
{
    private readonly IRepresentationService _representService;
    private readonly IUnitOfWork _unitOfWork;

    public CatalogService(
        IUnitOfWork unitOfWork,
        IRepresentationService representService)
    {
        _unitOfWork = unitOfWork;
        _representService = representService;
    }

    public async Task<IEnumerable<CatalogProductViewModel>> GetCatalogModelsAsync<TModel>(Expression<Func<TModel, bool>>? filter)
        where TModel : Product
    {
        return await _unitOfWork.GetRepository<TModel>().GetAllAsync(
            predicate: filter,
            selector: i => new CatalogProductViewModel
            {
                Id = i.Id,
                Name = i.Name,
                Price = i.Price,
                PictureUrl = i.PictureUrl
            });
    }

    public async Task<TFilterModel> GetFilterModelAsync<TFilterModel>(IEnumerable<CatalogProductViewModel> catalogProducts, TFilterModel filter)
        where TFilterModel : GuitarFilterViewModel
    {
        throw new NotImplementedException();
    }


    //public async Task<GuitarFilterViewModel> GetGuitarCatalogFilterAsync(IEnumerable<CatalogProductViewModel> catalogProducts, GuitarFilterViewModel filter)
    //{
    //    var allItems = new SelectListItem() { Value = null, Text = "All", Selected = true };

    //    var selectBrands = await _representService.GetSelectListAsync<Brand>(allItems);
    //    var selectColors = await _representService.GetSelectListAsync<Color>(allItems);
    //    var selectGuitarShapes = await _representService.GetSelectListAsync<GuitarShape>(allItems);
    //    var selectMaterials = await _representService.GetSelectListAsync<Material>(allItems);
    //    var selectPickupSets = await _representService.GetSelectListAsync<PickupSet>(allItems);
    //    var selectTremoloTypes = await _representService.GetSelectListAsync<TremoloType>(allItems);

    //    return new GuitarFilterViewModel()
    //    {
    //        PriceEnd = filter.PriceEnd ?? catalogProducts.MaxBy(i => i.Price)?.Price,
    //        PriceStart = filter.PriceStart ?? default,
    //        Products = catalogProducts.ToList(),
    //        Category = filter.Category,
    //        Brands = selectBrands,
    //        Colors = selectColors,
    //        GuitarShapes = selectGuitarShapes,
    //        Soundboards = selectMaterials,
    //        Necks = selectMaterials,
    //        Fretboards = selectMaterials,
    //        PickupSets = selectPickupSets,
    //        TremoloTypes = selectTremoloTypes,
    //    };
}