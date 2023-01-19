using AutoMapper;
using SoundPlay.BLL.Exceptions;
using SoundPlay.BLL.Interfaces;
using SoundPlay.BLL.ViewModels.Admin;
using SoundPlay.DAL.Models;
using SoundPlay.DAL.Repository.Interfaces;

namespace SoundPlay.BLL.Services
{
    public sealed class CategoryService : IItemGenericService<CategoryViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILoggerAdapter<CategoryService> _logger;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper, ILoggerAdapter<CategoryService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<CategoryViewModel> CreateViewModelAsync(CategoryViewModel viewModel)
        {
            var model = _mapper.Map<Category>(viewModel);
			_unitOfWork.Category.Add(model);
			await _unitOfWork.SaveChangesAsync();
			return viewModel;
        }

        public async Task<CategoryViewModel> DeleteViewModelAsync(CategoryViewModel viewModel)
        {
            var model = _mapper.Map<Category>(viewModel);
			_unitOfWork.Category.Remove(model);
			await _unitOfWork.SaveChangesAsync();
			return viewModel;
        }

        public async Task<CategoryViewModel> GetViewModelByIdAsync(int id)
        {
            var model = await _unitOfWork.Category.GetFirstOrDefaultAsync(
                predicate: i => i.Id == id,
                isTracking: false);

            if (model is null)
            {
                _logger.LogError("Get_by_id operation is failed");
                throw new ObjectNotFoundException("Object not found");
            }

            var viewModel = _mapper.Map<CategoryViewModel>(model);
            return viewModel;
        }

        public async Task<IEnumerable<CategoryViewModel>> GetViewModelsAsync()
        {
            var models = await _unitOfWork.Category.GetAllAsync(isTracking: false);

            if (models is null)
            {
                _logger.LogError("Get_All operation is failed");
                throw new ObjectNotFoundException("Object not found");
            }

            var viewModels = _mapper.Map<IEnumerable<CategoryViewModel>>(models);
            return viewModels;
        }

        public async Task<CategoryViewModel> UpdateViewModelAsync(CategoryViewModel viewModel)
        {
            var model = _mapper.Map<Category>(viewModel);
			_unitOfWork.Category.Update(model);
			await _unitOfWork.SaveChangesAsync();
			return viewModel;
        }
    }
}