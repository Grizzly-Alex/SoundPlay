namespace SoundPlay.BLL.Services;

public sealed class GuitarService : EntityService<Guitar, GuitarViewModel>
{
	public GuitarService(
        IMapper mapper,
        IUnitOfWork unitOfWork,
        ILoggerAdapter<EntityService<Guitar, GuitarViewModel>> logger) : base(mapper, unitOfWork, logger)
	{
	}

	public override async Task<IEnumerable<GuitarViewModel>> GetViewModelsAsync()
    {
        var models = await _unitOfWork.GetRepository<Guitar>()
            .GetAllAsync(
                include: query => query
                    .Include(guitar => guitar.Category)
                    .Include(guitar => guitar.Brand)
                    .Include(guitar => guitar.Color)
                    .Include(guitar => guitar.Shape)
                    .Include(guitar => guitar.Soundboard)
                    .Include(guitar => guitar.Neck)
                    .Include(guitar => guitar.Fretboard)
                    .Include(guitar => guitar.PickupSet)
                    .Include(guitar => guitar.TremoloType)!,
                isTracking: false);

        if (models is null)
        {
            _logger.LogError("Get_All operation is failed");
            throw new ObjectNotFoundException("Object not found");
        }

        var viewModels = _mapper.Map<IEnumerable<GuitarViewModel>>(models);
        return viewModels;
    }

    public override async Task<GuitarViewModel> GetViewModelByIdAsync(int id)
    {
        var model = await _unitOfWork.GetRepository<Guitar>()
            .GetFirstOrDefaultAsync(
                predicate: i => i.Id == id,
                include: query => query
                    .Include(guitar => guitar.Category)
                    .Include(guitar => guitar.Brand)
                    .Include(guitar => guitar.Color)
                    .Include(guitar => guitar.Shape)
                    .Include(guitar => guitar.Soundboard)
                    .Include(guitar => guitar.Neck)
                    .Include(guitar => guitar.Fretboard)
                    .Include(guitar => guitar.PickupSet)
                    .Include(guitar => guitar.TremoloType)!,
                isTracking: false);

        if (model is null)
        {
            _logger.LogError("Get_by_id operation is failed");
            throw new ObjectNotFoundException("Object not found");
        }

        var viewModel = _mapper.Map<GuitarViewModel>(model);
        return viewModel;
    }

    public override async Task<GuitarViewModel> CreateViewModelAsync(GuitarViewModel viewModel)
    {
        viewModel.DateDelivery = DateTime.Now;
        var model = _mapper.Map<Guitar>(viewModel);
        _unitOfWork.GetRepository<Guitar>().Add(model);
        await _unitOfWork.SaveChangesAsync();
        return viewModel;
    }

    public override async Task<GuitarViewModel> UpdateViewModelAsync(GuitarViewModel viewModel)
    {
        viewModel.DateDelivery = await _unitOfWork.GetRepository<Guitar>()
            .GetFirstOrDefaultAsync(
            selector: i => i.DateDelivery,
            predicate: i => i.Id == viewModel.Id);

        var model = _mapper.Map<Guitar>(viewModel);
        _unitOfWork.GetRepository<Guitar>().Update(model);
        await _unitOfWork.SaveChangesAsync();
        return viewModel;
    }
}