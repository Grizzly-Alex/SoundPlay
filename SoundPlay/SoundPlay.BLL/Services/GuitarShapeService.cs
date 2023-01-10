using AutoMapper;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;
using SoundPlay.BLL.Exceptions;
using SoundPlay.BLL.Interfaces;
using SoundPlay.BLL.ViewModels;
using SoundPlay.DAL.Models;
using SoundPlay.DAL.Repository.Interfaces;

namespace SoundPlay.BLL.Services
{
    public class GuitarShapeService : IItemGenericService<GuitarShapeViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<GuitarShapeService> _logger;

        public GuitarShapeService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<GuitarShapeService> logger)
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
                _logger.LogError($"Create operation is failed, {ex.Message}");
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
                _logger.LogInformation($"Delete operation is failed, {ex.Message}");
            }

            return viewModel;
        }

        public async Task<GuitarShapeViewModel> GetViewModelByIdAsync(int id)
        {
            var model = await _unitOfWork.GuitarShape.GetFirstOrDefaultAsync(b => b.Id == id);

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

            if (models.Count == 0 || models is null)
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
                _logger.LogError($"Update operation is failed, {ex.Message}");
            }

            return viewModel;
        }
    }
}