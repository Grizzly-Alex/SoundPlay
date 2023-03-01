namespace SoundPlay.Web.Services;

public sealed class CatalogService : ICatalogService
{
    private readonly IUnitOfWork _unitOfWork;

    public CatalogService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<CatalogProductViewModel>> GetProductsPerPageAsync<TModel>(Expression<Func<TModel, bool>>? filter, int itemsPerPage, int pageIndex)
        where TModel : Product
    {
        return await _unitOfWork.GetRepository<TModel>().GetPagedListAsync(
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
    }
    public async Task<PaginationInfoViewModel> GetPaginationInfoAsync<TModel>(int ItemsPerPage, int pageIndex)
        where TModel : Entity
    {
        var totalItems = await _unitOfWork.GetRepository<TModel>().GetAllAsync();

        var paginationInfo = new PaginationInfoViewModel();
        paginationInfo.PageIndex = pageIndex;
        paginationInfo.ItemsPerPage = ItemsPerPage;
        //paginationInfo.TotalPages = 
        paginationInfo.HasPreviousPage = pageIndex > 0;
        //paginationInfo.HasNextPage = 

        return paginationInfo;
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