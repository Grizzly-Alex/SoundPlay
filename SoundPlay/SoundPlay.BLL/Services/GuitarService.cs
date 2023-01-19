using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SoundPlay.BLL.Exceptions;
using SoundPlay.BLL.Interfaces;
using SoundPlay.BLL.ViewModels.Admin;
using SoundPlay.DAL.Models;
using SoundPlay.DAL.Repository.Interfaces;

namespace SoundPlay.BLL.Services
{
    public sealed class GuitarService : IItemGenericService<GuitarViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILoggerAdapter<GuitarService> _logger;

        public GuitarService(IUnitOfWork unitOfWork, IMapper mapper, ILoggerAdapter<GuitarService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<GuitarViewModel>> GetViewModelsAsync()
        {
            var models = await _unitOfWork.Guitar
                .GetAllAsync(
                    include:query => query
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

        public async Task<GuitarViewModel> GetViewModelByIdAsync(int id)
        {
            var model = await _unitOfWork.Guitar
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

        public async Task<GuitarViewModel> CreateViewModelAsync(GuitarViewModel viewModel)
        {
            var model = _mapper.Map<Guitar>(viewModel);
			_unitOfWork.Guitar.Add(model);
			await _unitOfWork.SaveChangesAsync();
			return viewModel;
        }
                
        public async Task<GuitarViewModel> UpdateViewModelAsync(GuitarViewModel viewModel)
        {
            var model = _mapper.Map<Guitar>(viewModel);
			_unitOfWork.Guitar.Update(model);
			await _unitOfWork.SaveChangesAsync();
			return viewModel;
        }

        public async Task<GuitarViewModel> DeleteViewModelAsync(GuitarViewModel viewModel)
        {
            var model = _mapper.Map<Guitar>(viewModel);
			_unitOfWork.Guitar.Remove(model);
			await _unitOfWork.SaveChangesAsync();
			return viewModel;
        }
    }
}