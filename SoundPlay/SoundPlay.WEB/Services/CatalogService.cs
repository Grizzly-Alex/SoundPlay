namespace SoundPlay.Web.Services;

public sealed class CatalogService : ICatalogService
{
    private readonly IUnitOfWork _unitOfWork;

    public CatalogService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<PagedInfoViewModel<CatalogProductViewModel>> GetProductPagedInfoAsync<TModel>(
        Expression<Func<TModel, bool>>? filter, int itemsPerPage, int totalItems, int pageIndex) where TModel : Product
    {
        var items =  await _unitOfWork.GetRepository<TModel>()
            .GetPagedListAsync(
            pageIndex: pageIndex,
            itemsPerPage: itemsPerPage, 
            predicate: filter,
            selector: i => new CatalogProductViewModel
            {
                Id = i.Id,
                Name = i.Name,
                Price = i.Price,
                PictureUrl = i.PictureUrl
            });

        return new PagedInfoViewModel<CatalogProductViewModel>()
        {
            PageIndex = pageIndex,
            ItemsPerPage = itemsPerPage,
            TotalItems = totalItems,
            TotalPages = (int)Math.Ceiling(totalItems / (double)itemsPerPage),
            Products = items.ToList(),
        };
    }

    public async Task<GuitarFilterViewModel> GetGuitarFilterAsync(GuitarType category, decimal? minPrice, decimal? maxPrice)
    {
        var brands = await _unitOfWork.GetRepository<Brand>().GetAllAsync();
        var colors = await _unitOfWork.GetRepository<Color>().GetAllAsync();
        var shapes = await _unitOfWork.GetRepository<GuitarShape>().GetAllAsync();
        var materials = await _unitOfWork.GetRepository<Material>().GetAllAsync();
        var pickupSets = await _unitOfWork.GetRepository<PickupSet>().GetAllAsync();
        var tremoloTypes = await _unitOfWork.GetRepository<TremoloType>().GetAllAsync();

        var allSelect = new SelectListItem { Text = "All" };

        return new GuitarFilterViewModel(
            brands.ToSelectListItems(allSelect),
            colors.ToSelectListItems(allSelect),
            shapes.ToSelectListItems(allSelect),
            materials.ToSelectListItems(allSelect),
            pickupSets.ToSelectListItems(allSelect),
            tremoloTypes.ToSelectListItems(allSelect),
            minPrice,
            maxPrice,
            category);
    }
}