using AutoMapper;
using SoundPlay.BLL.Exceptions;
using SoundPlay.BLL.Interfaces;
using SoundPlay.BLL.ViewModels.Admin;
using SoundPlay.DAL.Models;
using SoundPlay.DAL.Repository.Interfaces;

namespace SoundPlay.BLL.Services
{
    public sealed class GuitarShapeService : IItemGenericService<GuitarShapeViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILoggerAdapter<GuitarShapeService> _logger;

        public GuitarShapeService(IUnitOfWork unitOfWork, IMapper mapper, ILoggerAdapter<GuitarShapeService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<GuitarShapeViewModel> CreateViewModelAsync(GuitarShapeViewModel viewModel)
        {
            var model = _mapper.Map<GuitarShape>(viewModel);
			_unitOfWork.GuitarShape.Add(model);
			await _unitOfWork.SaveChangesAsync();
			return viewModel;
        }

        public async Task<GuitarShapeViewModel> DeleteViewModelAsync(GuitarShapeViewModel viewModel)
        {
            var model = _mapper.Map<GuitarShape>(viewModel);
			_unitOfWork.GuitarShape.Remove(model);
			await _unitOfWork.SaveChangesAsync();
			return viewModel;
        }

        public async Task<GuitarShapeViewModel> GetViewModelByIdAsync(int id)
        {
            var model = await _unitOfWork.GuitarShape.GetFirstOrDefaultAsync(
                predicate: i => i.Id == id,
                isTracking: false);

            if (model is null)
            {
                _logger.LogError("Get_by_id operation is failed");
                throw new ObjectNotFoundException("Object not found");
            }

            var viewModel = _mapper.Map<GuitarShapeViewModel>(model);
            return viewModel;
        }

        public async Task<IEnumerable<GuitarShapeViewModel>> GetViewModelsAsync()
        {
            var models = await _unitOfWork.GuitarShape.GetAllAsync(isTracking: false);

            if (models is null)
            {
                _logger.LogError("Get_All operation is failed");
                throw new ObjectNotFoundException("Object not found");
            }

            var viewModels = _mapper.Map<IEnumerable<GuitarShapeViewModel>>(models);
            return viewModels;
        }

        public async Task<GuitarShapeViewModel> UpdateViewModelAsync(GuitarShapeViewModel viewModel)
        {
            var model = _mapper.Map<GuitarShape>(viewModel);
			_unitOfWork.GuitarShape.Update(model);
			await _unitOfWork.SaveChangesAsync();
			return viewModel;
        }
    }
}