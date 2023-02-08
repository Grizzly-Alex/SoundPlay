namespace SoundPlay.BLL.Services;

public sealed class CatalogService : ICatalogService
{
	private readonly IRepresentationService _representService;
	private readonly IUnitOfWork _unitOfWork;

	public CatalogService(
		IUnitOfWork unitOfWork,
		IRepresentationService representService)
	{
		_unitOfWork = unitOfWork;
		_representService= representService;
	}

	public async Task<IEnumerable<CatalogProductViewModel>> GetCatalogProductsAsync<TProduct>(Expression<Func<TProduct, bool>>? filter)
		where TProduct : Product
	{
		return await _unitOfWork.GetRepository<TProduct>().GetAllAsync(
			predicate: filter,
			selector: i => new CatalogProductViewModel
			{
				Id = i.Id,
				Name = i.Name,
				Price = i.Price,
				PictureUrl = i.PictureUrl
			});
	}

	public async Task<GuitarFilterViewModel> GetGuitarCatalogFilterAsync(IEnumerable<CatalogProductViewModel> catalogProducts)
	{
		var selectBrands = await _representService.GetSelectListAsync<Brand>();
		var selectColors = await _representService.GetSelectListAsync<Color>();
		var selectGuitarShapes = await _representService.GetSelectListAsync<GuitarShape>();
		var selectMaterials = await _representService.GetSelectListAsync<Material>();
		var selectPickupSets = await _representService.GetSelectListAsync<PickupSet>();
		var selectTremoloTypes = await _representService.GetSelectListAsync<TremoloType>();

		return new GuitarFilterViewModel()
		{
			Products = catalogProducts.ToList(),
			Brands = selectBrands,
			Colors = selectColors,
			GuitarShapes = selectGuitarShapes,
			Soundboards = selectMaterials,
			Necks = selectMaterials,
			Fretboards = selectMaterials,
			PickupSets = selectPickupSets,
			TremoloTypes = selectTremoloTypes,
		};
	}
}
