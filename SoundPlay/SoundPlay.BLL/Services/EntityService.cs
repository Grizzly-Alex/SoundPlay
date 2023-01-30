using SoundPlay.BLL.ViewModels;

namespace SoundPlay.BLL.Services;

public sealed class EntityService<TModel, TViewModel> : IItemGenericService<TViewModel>
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


	public Task<TViewModel> CreateViewModelAsync(TViewModel viewModel)
	{
		var model = _mapper.Map<TModel>(viewModel);

		_unitOfWork.GetRepository<Brand>().Remove(model);
			
		throw new NotImplementedException();
	}

	public Task<TViewModel> DeleteViewModelAsync(TViewModel viewModel)
	{
		throw new NotImplementedException();
	}

	public Task<TViewModel> GetViewModelByIdAsync(int id)
	{
		throw new NotImplementedException();
	}

	public Task<IEnumerable<TViewModel>> GetViewModelsAsync()
	{
		throw new NotImplementedException();
	}

	public Task<TViewModel> UpdateViewModelAsync(TViewModel viewModel)
	{
		throw new NotImplementedException();
	}
}
