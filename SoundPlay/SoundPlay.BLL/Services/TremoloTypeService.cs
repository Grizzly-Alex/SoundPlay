namespace SoundPlay.BLL.Services;

public sealed class TremoloTypeService : IItemGenericService<TremoloTypeViewModel>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ILoggerAdapter<TremoloTypeService> _logger;

    public TremoloTypeService(IUnitOfWork unitOfWork, IMapper mapper, ILoggerAdapter<TremoloTypeService> logger)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<TremoloTypeViewModel> CreateViewModelAsync(TremoloTypeViewModel viewModel)
    {
        var model = _mapper.Map<TremoloType>(viewModel);
			_unitOfWork.TremoloType.Add(model);
			await _unitOfWork.SaveChangesAsync();			
        return viewModel;
    }

    public async Task<TremoloTypeViewModel> DeleteViewModelAsync(TremoloTypeViewModel viewModel)
    {
        var model = _mapper.Map<TremoloType>(viewModel);            
			_unitOfWork.TremoloType.Remove(model);
			await _unitOfWork.SaveChangesAsync();
			return viewModel;
    }

    public async Task<TremoloTypeViewModel> GetViewModelByIdAsync(int id)
    {
        var model = await _unitOfWork.TremoloType.GetFirstOrDefaultAsync(
            predicate: i => i.Id == id,
            isTracking: false);

        if (model is null)
        {
            _logger.LogError("Get_by_id operation is failed");
            throw new ObjectNotFoundException("Object not found");
        }

        var viewModel = _mapper.Map<TremoloTypeViewModel>(model);
        return viewModel;
    }

    public async Task<IEnumerable<TremoloTypeViewModel>> GetViewModelsAsync()
    {
        var models = await _unitOfWork.TremoloType.GetAllAsync(isTracking: false);

        if (models is null)
        {
            _logger.LogError("Get_All operation is failed");
            throw new ObjectNotFoundException("Object not found");
        }

        var viewModels = _mapper.Map<IEnumerable<TremoloTypeViewModel>>(models);
        return viewModels;
    }

    public async Task<TremoloTypeViewModel> UpdateViewModelAsync(TremoloTypeViewModel viewModel)
    {
        var model = _mapper.Map<TremoloType>(viewModel);            
			_unitOfWork.TremoloType.Update(model);
			await _unitOfWork.SaveChangesAsync();
			return viewModel;
    }
}