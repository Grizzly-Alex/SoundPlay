namespace SoundPlay.BLL.Services;

public sealed class MaterialService : IItemGenericService<MaterialViewModel>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ILoggerAdapter<MaterialService> _logger;

    public MaterialService(IUnitOfWork unitOfWork, IMapper mapper, ILoggerAdapter<MaterialService> logger)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<MaterialViewModel> CreateViewModelAsync(MaterialViewModel viewModel)
    {
        var model = _mapper.Map<Material>(viewModel);
			_unitOfWork.Material.Add(model);
			await _unitOfWork.SaveChangesAsync();
			return viewModel;
    }

    public async Task<MaterialViewModel> DeleteViewModelAsync(MaterialViewModel viewModel)
    {
        var model = _mapper.Map<Material>(viewModel);
			_unitOfWork.Material.Remove(model);
			await _unitOfWork.SaveChangesAsync();
			return viewModel;
    }

    public async Task<MaterialViewModel> GetViewModelByIdAsync(int id)
    {
        var model = await _unitOfWork.Material.GetFirstOrDefaultAsync(
            predicate: i => i.Id == id,
            isTracking: false);

        if (model is null)
        {
            _logger.LogError("Get_by_id operation is failed");
            throw new ObjectNotFoundException("Object not found");
        }

        var viewModel = _mapper.Map<MaterialViewModel>(model);
        return viewModel;
    }

    public async Task<IEnumerable<MaterialViewModel>> GetViewModelsAsync()
    {
        var models = await _unitOfWork.Material.GetAllAsync(isTracking: false);

        if (models is null)
        {
            _logger.LogError("Get_All operation is failed");
            throw new ObjectNotFoundException("Object not found");
        }

        var viewModels = _mapper.Map<IEnumerable<MaterialViewModel>>(models);
        return viewModels;
    }

    public async Task<MaterialViewModel> UpdateViewModelAsync(MaterialViewModel viewModel)
    {
        var model = _mapper.Map<Material>(viewModel);
			_unitOfWork.Material.Update(model);
			await _unitOfWork.SaveChangesAsync();
			return viewModel;
    }
}