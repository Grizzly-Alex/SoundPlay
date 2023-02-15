namespace SoundPlay.BLL.Services;

public sealed class RepresentationService : IRepresentationService
{
	private readonly IUnitOfWork _unitOfWork;

	public RepresentationService(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}

	public async Task<IEnumerable<SelectListItem>> GetSelectListAsync<TEntity>()
		where TEntity : Item
	{
		var entityList = await _unitOfWork.GetRepository<TEntity>().GetAllAsync();
        return entityList!.OrderBy(i => i.Name).Select(i => new SelectListItem { Value = i.Id.ToString(), Text = i.Name }).ToList();
	}

    public async Task<IEnumerable<SelectListItem>> GetSelectListAsync<TEntity>(SelectListItem selectList, int indexInsert = 0)
		where TEntity : Item
    {
        var entityList = await _unitOfWork.GetRepository<TEntity>().GetAllAsync();
		var selectListItem = entityList!.OrderBy(i => i.Name).Select(i => new SelectListItem { Value = i.Id.ToString(), Text = i.Name }).ToList();
		selectListItem.Insert(indexInsert, selectList);	
        return selectListItem;
    }
}
