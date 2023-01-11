﻿using AutoMapper;
using Microsoft.Extensions.Logging;
using SoundPlay.BLL.Exceptions;
using SoundPlay.BLL.Interfaces;
using SoundPlay.BLL.ViewModels;
using SoundPlay.DAL.Models;
using SoundPlay.DAL.Repository.Interfaces;

namespace SoundPlay.BLL.Services
{
    public class BrandService : IItemGenericService<BrandViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<BrandService> _logger;

        public BrandService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<BrandService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<BrandViewModel> CreateViewModelAsync(BrandViewModel viewModel)
        {
            var model = _mapper.Map<Brand>(viewModel);

            try
            {
                _unitOfWork.Brand.Add(model);
                await _unitOfWork.SaveChangesAsync();
                _logger.LogInformation("Create operation is successfull");
            }

            catch (Exception ex)
            {
                _logger.LogError($"Create operation is failed, {ex.Message}");
            }

            return viewModel;
        }

        public async Task<BrandViewModel> DeleteViewModelAsync(BrandViewModel viewModel)
        {
            var model = _mapper.Map<Brand>(viewModel);

            try
            {
                _unitOfWork.Brand.Remove(model);
                await _unitOfWork.SaveChangesAsync();
                _logger.LogInformation("Delete operation is successfull");
            }

            catch (Exception ex)
            {
                _logger.LogInformation($"Delete operation is failed, {ex.Message}");
            }

            return viewModel;
        }

        public async Task<BrandViewModel> GetViewModelByIdAsync(int id)
        {
            var model = await _unitOfWork.Brand.GetFirstOrDefaultAsync(b=>b.Id==id);
            
            if (model is null)
            {
                _logger.LogError("Get_by_id operation is failed");
                throw new ObjectNotFoundException("Object not found");
            }

            _logger.LogInformation("Get_by_id operation is successfull");
            var viewModel=_mapper.Map<BrandViewModel>(model);
            return viewModel;
        }

        public async Task<IEnumerable<BrandViewModel>> GetViewModelsAsync()
        {
            var models = await _unitOfWork.Brand.GetAllAsync(changeTrackerOn: false);

            if (models is null)
            {
                _logger.LogError("Get_All operation is failed");
                throw new ObjectNotFoundException("Object not found");
            }

            _logger.LogInformation("Get_All operation is successfull");
            var viewModels = _mapper.Map<IEnumerable<BrandViewModel>>(models);
            return viewModels;
        }

        public async Task<BrandViewModel> UpdateViewModelAsync(BrandViewModel viewModel)
        {
            var model = _mapper.Map<Brand>(viewModel);

            try
            {
                _unitOfWork.Brand.Update(model);
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