namespace SoundPlay.BLL.Services;

public sealed class PickupSetService:IItemGenericService<PickupSetViewModel>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ILoggerAdapter<PickupSetService> _logger;

    public PickupSetService(IUnitOfWork unitOfWork, IMapper mapper, ILoggerAdapter<PickupSetService> logger)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<PickupSetViewModel> CreateViewModelAsync(PickupSetViewModel viewModel)
    {
        var model = _mapper.Map<PickupSet>(viewModel);
			_unitOfWork.PickupSet.Add(model);
			await _unitOfWork.SaveChangesAsync();			
        return viewModel;
    }

    public async Task<PickupSetViewModel> DeleteViewModelAsync(PickupSetViewModel viewModel)
    {
        var model = _mapper.Map<PickupSet>(viewModel);
			_unitOfWork.PickupSet.Remove(model);
			await _unitOfWork.SaveChangesAsync();
			return viewModel;
    }

    public async Task<PickupSetViewModel> GetViewModelByIdAsync(int id)
    {
        var model = await _unitOfWork.PickupSet.GetFirstOrDefaultAsync(
            predicate: i => i.Id == id,
            isTracking: false);

        if (model is null)
        {
            _logger.LogError("Get_by_id operation is failed");
            throw new ObjectNotFoundException("Object not found");
        }

        var viewModel = _mapper.Map<PickupSetViewModel>(model);
        return viewModel;
    }

    public async Task<IEnumerable<PickupSetViewModel>> GetViewModelsAsync()
    {
        var models = await _unitOfWork.PickupSet.GetAllAsync(isTracking: false);

        if (models is null)
        {
            _logger.LogError("Get_All operation is failed");
            throw new ObjectNotFoundException("Object not found");
        }

        var viewModels = _mapper.Map<IEnumerable<PickupSetViewModel>>(models);
        return viewModels;
    }

    public async Task<PickupSetViewModel> UpdateViewModelAsync(PickupSetViewModel viewModel)
    {
        var model = _mapper.Map<PickupSet>(viewModel);
			_unitOfWork.PickupSet.Update(model);
			await _unitOfWork.SaveChangesAsync();
			return viewModel;
    }
}
