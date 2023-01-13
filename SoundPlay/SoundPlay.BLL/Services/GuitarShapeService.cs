using AutoMapper;
using SoundPlay.BLL.Exceptions;
using SoundPlay.BLL.Interfaces;
using SoundPlay.BLL.ViewModels;
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

            try
            {
                _unitOfWork.GuitarShape.Add(model);
                await _unitOfWork.SaveChangesAsync();
                _logger.LogInformation("Create operation is successfull");
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, $"Create operation is failed, {ex.Message}");
            }

            return viewModel;
        }

        public async Task<GuitarShapeViewModel> DeleteViewModelAsync(GuitarShapeViewModel viewModel)
        {
            var model = _mapper.Map<GuitarShape>(viewModel);

            try
            {
                _unitOfWork.GuitarShape.Remove(model);
                await _unitOfWork.SaveChangesAsync();
                _logger.LogInformation("Delete operation is successfull");
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, $"Delete operation is failed, {ex.Message}");
            }

            return viewModel;
        }

        public async Task<GuitarShapeViewModel> GetViewModelByIdAsync(int id)
        {
            var model = await _unitOfWork.Category.GetFirstOrDefaultAsync(
                predicate: i => i.Id == id,
                changeTrackerOn: false);

            if (model is null)
            {
                _logger.LogError("Get_by_id operation is failed");
                throw new ObjectNotFoundException("Object not found");
            }

            _logger.LogInformation("Get_by_id operation is successfull");
            var viewModel = _mapper.Map<GuitarShapeViewModel>(model);
            return viewModel;
        }

        public async Task<IEnumerable<GuitarShapeViewModel>> GetViewModelsAsync()
        {
            var models = await _unitOfWork.GuitarShape.GetAllAsync(changeTrackerOn: false);

            if (models is null)
            {
                _logger.LogError("Get_All operation is failed");
                throw new ObjectNotFoundException("Object not found");
            }

            _logger.LogInformation("Get_All operation is successfull");
            var viewModels = _mapper.Map<IEnumerable<GuitarShapeViewModel>>(models);
            return viewModels;
        }

        public async Task<GuitarShapeViewModel> UpdateViewModelAsync(GuitarShapeViewModel viewModel)
        {
            var model = _mapper.Map<GuitarShape>(viewModel);

            try
            {
                _unitOfWork.GuitarShape.Update(model);
                await _unitOfWork.SaveChangesAsync();
                _logger.LogInformation("Update operation is successfull");
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, $"Update operation is failed, {ex.Message}");
            }

            return viewModel;
        }
    }
}