namespace SoundPlay.BLL.Services;

public sealed class RepresentationService : IRepresentationService
{
	private readonly IUnitOfWork _unitOfWork;

	public RepresentationService(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}

	public async Task<IEnumerable<SelectListItem>> GetSelectListAsync<TEntity>() where TEntity : Entity
	{
		var listEntity = await _unitOfWork.GetRepository<TEntity>().GetAllAsync();
		var selectList = listEntity!.OrderBy(i => i.Name).Select(i => new SelectListItem { Value = i.Id.ToString(), Text = i.Name });
		return selectList;
	}
}
