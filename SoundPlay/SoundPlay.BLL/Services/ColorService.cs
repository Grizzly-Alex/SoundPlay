using AutoMapper;
using Microsoft.Extensions.Logging;
using SoundPlay.BLL.Exceptions;
using SoundPlay.BLL.Interfaces;
using SoundPlay.BLL.ViewModels;
using SoundPlay.DAL.Models;
using SoundPlay.DAL.Repository.Interfaces;

namespace SoundPlay.BLL.Services
{
    public sealed class ColorService:IItemGenericService<ColorViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<ColorService> _logger;

        public ColorService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<ColorService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ColorViewModel> CreateViewModelAsync(ColorViewModel viewModel)
        {
            var model = _mapper.Map<Color>(viewModel);

            try
            {
                _unitOfWork.Color.Add(model);
                await _unitOfWork.SaveChangesAsync();
                _logger.LogInformation("Create operation is successfull");
            }

            catch (Exception ex)
            {
                _logger.LogError($"Create operation is failed, {ex.Message}");
            }

            return viewModel;
        }

        public async Task<ColorViewModel> DeleteViewModelAsync(ColorViewModel viewModel)
        {
            var model = _mapper.Map<Color>(viewModel);

            try
            {
                _unitOfWork.Color.Remove(model);
                await _unitOfWork.SaveChangesAsync();
                _logger.LogInformation("Delete operation is successfull");
            }

            catch (Exception ex)
            {
                _logger.LogInformation($"Delete operation is failed, {ex.Message}");
            }

            return viewModel;
        }

        public async Task<ColorViewModel> GetViewModelByIdAsync(int id)
        {
            var model = await _unitOfWork.Color.GetFirstOrDefaultAsync(b => b.Id==id);

            if (model is null)
            {
                _logger.LogError("Get_by_id operation is failed");
                throw new ObjectNotFoundException("Object not found");
            }

            _logger.LogInformation("Get_by_id operation is successfull");
            var viewModel = _mapper.Map<ColorViewModel>(model);
            return viewModel;
        }

        public async Task<IEnumerable<ColorViewModel>> GetViewModelsAsync()
        {
            var models = await _unitOfWork.Color.GetAllAsync(changeTrackerOn: false);

            if (models is null)
            {
                _logger.LogError("Get_All operation is failed");
                throw new ObjectNotFoundException("Object not found");
            }

            _logger.LogInformation("Get_All operation is successfull");
            var viewModels = _mapper.Map<IEnumerable<ColorViewModel>>(models);
            return viewModels;
        }

        public async Task<ColorViewModel> UpdateViewModelAsync(ColorViewModel viewModel)
        {
            var model = _mapper.Map<Color>(viewModel);

            try
            {
                _unitOfWork.Color.Update(model);
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
