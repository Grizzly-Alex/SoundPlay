namespace SoundPlay.Web.Services;

public sealed class CatalogService : ICatalogService
{
    private readonly IUnitOfWork _unitOfWork;

    public CatalogService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
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

    public async Task<GuitarFilterViewModel> GetGuitarFilterAsync(IEnumerable<CatalogProductViewModel> catalogProducts, GuitarFilterViewModel filter)
    {
        var brands = await _unitOfWork.GetRepository<Brand>().GetAllAsync();
        var colors = await _unitOfWork.GetRepository<Color>().GetAllAsync();
        var shapes = await _unitOfWork.GetRepository<GuitarShape>().GetAllAsync();
        var materials = await _unitOfWork.GetRepository<Material>().GetAllAsync();
        var pickupSets = await _unitOfWork.GetRepository<PickupSet>().GetAllAsync();
        var tremoloTypes = await _unitOfWork.GetRepository<TremoloType>().GetAllAsync();

        var allSelect = new SelectListItem { Text = "All" };

        return new GuitarFilterViewModel(
            filter.PriceStart ?? default,
            filter.PriceEnd ?? catalogProducts.MaxBy(i => i.Price)?.Price,
            filter.Category,
            catalogProducts.ToList(),
            brands.ToSelectListItems(allSelect),
            colors.ToSelectListItems(allSelect),
            shapes.ToSelectListItems(allSelect),
            materials.ToSelectListItems(allSelect),
            pickupSets.ToSelectListItems(allSelect),
            tremoloTypes.ToSelectListItems(allSelect));
    }
}