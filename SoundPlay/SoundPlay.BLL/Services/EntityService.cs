namespace SoundPlay.BLL.Services;

public sealed class EntityService<TModel, TViewModel> : IEntityService<TModel, TViewModel>
	where TModel : Entity
	where TViewModel : EntityViewModel
{
	private readonly IMapper _mapper;
	private readonly IUnitOfWork _unitOfWork;
	private readonly ILoggerAdapter<EntityService<TModel, TViewModel>> _logger;

	public EntityService(
		IMapper mapper,
		IUnitOfWork unitOfWork,
		ILoggerAdapter<EntityService<TModel, TViewModel>> logger)
	{
		_mapper = mapper;
		_unitOfWork = unitOfWork;
		_logger = logger;
	}

	public async Task<TViewModel> CreateViewModelAsync(TViewModel viewModel)
	{
		var model = _mapper.Map<TModel>(viewModel);
		_unitOfWork.GetRepository<TModel>().Add(model);
		await _unitOfWork.SaveChangesAsync();
		return viewModel;
	}

	public async Task<TViewModel> DeleteViewModelAsync(TViewModel viewModel)
	{
		var model = _mapper.Map<TModel>(viewModel);
		_unitOfWork.GetRepository<TModel>().Remove(model);
		await _unitOfWork.SaveChangesAsync();
		return viewModel;
	}

	public async Task<TViewModel> GetViewModelByIdAsync(int id)
	{
		var model = await _unitOfWork.GetRepository<TModel>().GetFirstOrDefaultAsync(
			predicate: i => i.Id == id,
			isTracking: false);

		if (model is null)
		{
			_logger.LogError("Get_by_id operation is failed");
			throw new ObjectNotFoundException("Object not found");
		}

		var viewModel = _mapper.Map<TViewModel>(model);
		return viewModel;
	}

	public async Task<IEnumerable<TViewModel>> GetViewModelsAsync()
	{
		var models = await _unitOfWork.GetRepository<TModel>().GetAllAsync(isTracking: false);

		if (models is null)
		{
			_logger.LogError("Get_All operation is failed");
			throw new ObjectNotFoundException("Object not found");
		}

		var viewModels = _mapper.Map<IEnumerable<TViewModel>>(models);
		return viewModels;
	}

	public async Task<TViewModel> UpdateViewModelAsync(TViewModel viewModel)
	{
		var model = _mapper.Map<TModel>(viewModel);
		_unitOfWork.GetRepository<TModel>().Update(model);
		await _unitOfWork.SaveChangesAsync();
		return viewModel;
	}
}
