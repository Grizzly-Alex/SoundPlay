using AutoMapper;
using Microsoft.Extensions.Logging;
using SoundPlay.BLL.Exceptions;
using SoundPlay.BLL.Interfaces;
using SoundPlay.DAL.Repository.Interfaces;
using SoundPlay.DTO.Models;
using SoundPlay.DTO.ViewModels;

namespace SoundPlay.BLL.Services
{
    public class TremoloTypeService:IGenericService<TremoloTypeViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<TremoloTypeService> _logger;

        public TremoloTypeService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<TremoloTypeService> logger)
        {
            _unitOfWork=unitOfWork;
            _mapper=mapper;
            _logger=logger;
        }

        public async Task<TremoloTypeViewModel> CreateViewModelAsync(TremoloTypeViewModel viewModel)
        {
            var model = _mapper.Map<TremoloType>(viewModel);

            try
            {
                _unitOfWork.TremoloType.Add(model);
                await _unitOfWork.SaveChangesAsync();
                _logger.LogInformation("Create operation is successfull");
            }

            catch (Exception ex)
            {
                _logger.LogError($"Create operation is failed, {ex.Message}");
            }

            return viewModel;
        }

        public async Task<TremoloTypeViewModel> DeleteViewModelAsync(TremoloTypeViewModel viewModel)
        {
            var model = _mapper.Map<TremoloType>(viewModel);

            try
            {
                _unitOfWork.TremoloType.Remove(model);
                await _unitOfWork.SaveChangesAsync();
                _logger.LogInformation("Delete operation is successfull");
            }

            catch (Exception ex)
            {
                _logger.LogInformation($"Delete operation is failed, {ex.Message}");
            }

            return viewModel;
        }

        public async Task<TremoloTypeViewModel> GetViewModelByIdAsync(int id)
        {
            var model = await _unitOfWork.TremoloType.GetFirstOrDefaultAsync(b => b.Id==id);

            if (model==null)
            {
                _logger.LogError("Get_by_id operation is failed");
                throw new ObjectNotFoundException("No object found");
            }

            _logger.LogInformation("Get_by_id operation is successfull");
            var viewModel = _mapper.Map<TremoloTypeViewModel>(model);
            return viewModel;
        }

        public async Task<IEnumerable<TremoloTypeViewModel>> GetViewModelsAsync()
        {
            var models = await _unitOfWork.TremoloType.GetAllAsync();

            if (models.Count()==0||models==null)
            {
                _logger.LogError("Get_All operation is failed");
                throw new ObjectNotFoundException("No object found");
            }

            _logger.LogInformation("Get_All operation is successfull");
            var viewModels = _mapper.Map<IEnumerable<TremoloTypeViewModel>>(models);
            return viewModels;
        }

        public async Task<TremoloTypeViewModel> UpdateViewModelAsync(TremoloTypeViewModel viewModel)
        {
            var model = _mapper.Map<TremoloType>(viewModel);

            try
            {
                _unitOfWork.TremoloType.Update(model);
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