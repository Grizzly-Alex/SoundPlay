using AutoMapper;
using Microsoft.Extensions.Logging;
using SoundPlay.BLL.Exceptions;
using SoundPlay.BLL.Interfaces;
using SoundPlay.BLL.ViewModels;
using SoundPlay.DAL.Models;
using SoundPlay.DAL.Repository.Interfaces;

namespace SoundPlay.BLL.Services
{
    public sealed class PickupConfigurationService:IItemGenericService<PickupConfigurationViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<PickupConfigurationService> _logger;

        public PickupConfigurationService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<PickupConfigurationService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<PickupConfigurationViewModel> CreateViewModelAsync(PickupConfigurationViewModel viewModel)
        {
            var model = _mapper.Map<PickupConfiguration>(viewModel);

            try
            {
                _unitOfWork.PickupConfiguration.Add(model);
                await _unitOfWork.SaveChangesAsync();
                _logger.LogInformation("Create operation is successfull");
            }

            catch (Exception ex)
            {
                _logger.LogError($"Create operation is failed, {ex.Message}");
            }

            return viewModel;
        }

        public async Task<PickupConfigurationViewModel> DeleteViewModelAsync(PickupConfigurationViewModel viewModel)
        {
            var model = _mapper.Map<PickupConfiguration>(viewModel);

            try
            {
                _unitOfWork.PickupConfiguration.Remove(model);
                await _unitOfWork.SaveChangesAsync();
                _logger.LogInformation("Delete operation is successfull");
            }

            catch (Exception ex)
            {
                _logger.LogInformation($"Delete operation is failed, {ex.Message}");
            }

            return viewModel;
        }

        public async Task<PickupConfigurationViewModel> GetViewModelByIdAsync(int id)
        {
            var model = await _unitOfWork.PickupConfiguration.GetFirstOrDefaultAsync(b => b.Id==id);

            if (model is null)
            {
                _logger.LogError("Get_by_id operation is failed");
                throw new ObjectNotFoundException("Object not found");
            }

            _logger.LogInformation("Get_by_id operation is successfull");
            var viewModel = _mapper.Map<PickupConfigurationViewModel>(model);
            return viewModel;
        }

        public async Task<IEnumerable<PickupConfigurationViewModel>> GetViewModelsAsync()
        {
            var models = await _unitOfWork.PickupConfiguration.GetAllAsync(changeTrackerOn: false);

            if (models is null)
            {
                _logger.LogError("Get_All operation is failed");
                throw new ObjectNotFoundException("Object not found");
            }

            _logger.LogInformation("Get_All operation is successfull");
            var viewModels = _mapper.Map<IEnumerable<PickupConfigurationViewModel>>(models);
            return viewModels;
        }

        public async Task<PickupConfigurationViewModel> UpdateViewModelAsync(PickupConfigurationViewModel viewModel)
        {
            var model = _mapper.Map<PickupConfiguration>(viewModel);

            try
            {
                _unitOfWork.PickupConfiguration.Update(model);
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
