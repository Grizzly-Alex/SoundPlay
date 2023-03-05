﻿namespace SoundPlay.Web.Services;

public sealed class CatalogService : ICatalogService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CatalogService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<decimal> GetMaxPrice<TModel>(Expression<Func<TModel, bool>>? filter) where TModel : Product
    {
        return await _unitOfWork.GetRepository<TModel>().MaxAsync(
            selector: i => i.Price,
            predicate: filter);
    }

    public async Task<PagedListViewModel<CatalogProductViewModel>> GetCatalogPageInfoAsync<TModel>(
        Expression<Func<TModel, bool>>? filter, int itemsPerPage, int pageIndex) where TModel : Product
    {
        var pagedList =  await _unitOfWork.GetRepository<TModel>()
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

        var pagedInfo = _mapper.Map<PagedListViewModel<CatalogProductViewModel>>(pagedList);

        return pagedInfo;
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