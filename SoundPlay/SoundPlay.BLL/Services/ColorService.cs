namespace SoundPlay.BLL.Services;

public sealed class ColorService:IItemGenericService<ColorViewModel>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ILoggerAdapter<ColorService> _logger;

    public ColorService(IUnitOfWork unitOfWork, IMapper mapper, ILoggerAdapter<ColorService> logger)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<ColorViewModel> CreateViewModelAsync(ColorViewModel viewModel)
    {
        var model = _mapper.Map<Color>(viewModel);
			_unitOfWork.Color.Add(model);
			await _unitOfWork.SaveChangesAsync();
			return viewModel;
    }

    public async Task<ColorViewModel> DeleteViewModelAsync(ColorViewModel viewModel)
    {
        var model = _mapper.Map<Color>(viewModel);
			_unitOfWork.Color.Remove(model);
			await _unitOfWork.SaveChangesAsync();
			return viewModel;
    }

    public async Task<ColorViewModel> GetViewModelByIdAsync(int id)
    {
        var model = await _unitOfWork.Color.GetFirstOrDefaultAsync(
            predicate: i => i.Id == id,
            isTracking: false);

        if (model is null)
        {
            _logger.LogError("Get_by_id operation is failed");
            throw new ObjectNotFoundException("Object not found");
        }

        var viewModel = _mapper.Map<ColorViewModel>(model);
        return viewModel;
    }

    public async Task<IEnumerable<ColorViewModel>> GetViewModelsAsync()
    {
        var models = await _unitOfWork.Color.GetAllAsync(isTracking: false);

        if (models is null)
        {
            _logger.LogError("Get_All operation is failed");
            throw new ObjectNotFoundException("Object not found");
        }

        var viewModels = _mapper.Map<IEnumerable<ColorViewModel>>(models);
        return viewModels;
    }

    public async Task<ColorViewModel> UpdateViewModelAsync(ColorViewModel viewModel)
    {
        var model = _mapper.Map<Color>(viewModel);
			_unitOfWork.Color.Update(model);
			await _unitOfWork.SaveChangesAsync();
			return viewModel;
    }
}
