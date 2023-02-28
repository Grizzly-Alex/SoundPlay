namespace SoundPlay.Web.Services;

public sealed class CatalogService : ICatalogService
{
    private readonly IUnitOfWork _unitOfWork;

    public CatalogService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IPagedList<CatalogProductViewModel>> GetCatalogPageAsync<TModel>(Expression<Func<TModel, bool>>? filter, int currentPageIndex, int totalItems)
        where TModel : Product
    {
        return await _unitOfWork.GetRepository<TModel>().GetPagedListAsync(
            pageIndex: currentPageIndex,
            itemsPerPage: totalItems,
            predicate: filter,
            selector: i => new CatalogProductViewModel
            {
                Id = i.Id,
                Name = i.Name,
                Price = i.Price,
                PictureUrl = i.PictureUrl
            });
    }

    public async Task<GuitarFilterViewModel> GetGuitarFilterAsync(IPagedList<CatalogProductViewModel> catalogProducts, GuitarFilterViewModel filter)
    {
        var brands = await _unitOfWork.GetRepository<Brand>().GetAllAsync();
        var colors = await _unitOfWork.GetRepository<Color>().GetAllAsync();
        var shapes = await _unitOfWork.GetRepository<GuitarShape>().GetAllAsync();
        var materials = await _unitOfWork.GetRepository<Material>().GetAllAsync();
        var pickupSets = await _unitOfWork.GetRepository<PickupSet>().GetAllAsync();
        var tremoloTypes = await _unitOfWork.GetRepository<TremoloType>().GetAllAsync();

        var allSelect = new SelectListItem { Text = "All" };

        return new GuitarFilterViewModel(
            filter.MinPrice ?? default,
            filter.MaxPrice ?? catalogProducts.Items.MaxBy(i => i.Price)?.Price,
            filter.Category,
            catalogProducts,
            brands.ToSelectListItems(allSelect),
            colors.ToSelectListItems(allSelect),
            shapes.ToSelectListItems(allSelect),
            materials.ToSelectListItems(allSelect),
            pickupSets.ToSelectListItems(allSelect),
            tremoloTypes.ToSelectListItems(allSelect));
    }
}