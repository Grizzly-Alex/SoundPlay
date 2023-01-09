using AutoMapper;
using Microsoft.Extensions.Logging;
using SoundPlay.BLL.Exceptions;
using SoundPlay.BLL.Interfaces;
using SoundPlay.BLL.ViewModels;
using SoundPlay.DAL.Models;
using SoundPlay.DAL.Repository.Interfaces;

namespace SoundPlay.BLL.Services
{
    public class CategoryService:ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CategoryService> _logger;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CategoryService> logger)
        {
            _unitOfWork=unitOfWork;
            _mapper=mapper;
            _logger=logger;
        }

        public async Task<CategoryViewModel> CreateViewModelAsync(CategoryViewModel viewModel)
        {
            var model = _mapper.Map<Category>(viewModel);

            try
            {
                _unitOfWork.Category.Add(model);
                await _unitOfWork.SaveChangesAsync();
                _logger.LogInformation("Create operation is successfull");
            }

            catch (Exception ex)
            {
                _logger.LogError($"Create operation is failed, {ex.Message}");
            }

            return viewModel;
        }

        public async Task<CategoryViewModel> DeleteViewModelAsync(CategoryViewModel viewModel)
        {
            var model = _mapper.Map<Category>(viewModel);

            try
            {
                _unitOfWork.Category.Remove(model);
                await _unitOfWork.SaveChangesAsync();
                _logger.LogInformation("Delete operation is successfull");
            }

            catch (Exception ex)
            {
                _logger.LogInformation($"Delete operation is failed, {ex.Message}");
            }

            return viewModel;
        }

        public async Task<CategoryViewModel> GetViewModelByIdAsync(int id)
        {
            var model = await _unitOfWork.Category.GetFirstOrDefaultAsync(b => b.Id==id);

            if (model==null)
            {
                _logger.LogError("Get_by_id operation is failed");
                throw new ObjectNotFoundException("No object found");
            }

            _logger.LogInformation("Get_by_id operation is successfull");
            var viewModel = _mapper.Map<CategoryViewModel>(model);
            return viewModel;
        }

        public async Task<IEnumerable<CategoryViewModel>> GetViewModelsAsync()
        {
            var models = await _unitOfWork.Category.GetAllAsync();

            if (models.Count()==0||models==null)
            {
                _logger.LogError("Get_All operation is failed");
                throw new ObjectNotFoundException("No object found");
            }

            _logger.LogInformation("Get_All operation is successfull");
            var viewModels = _mapper.Map<IEnumerable<CategoryViewModel>>(models);
            return viewModels;
        }

        public async Task<CategoryViewModel> UpdateViewModelAsync(CategoryViewModel viewModel)
        {
            var model = _mapper.Map<Category>(viewModel);

            try
            {
                _unitOfWork.Category.Update(model);
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