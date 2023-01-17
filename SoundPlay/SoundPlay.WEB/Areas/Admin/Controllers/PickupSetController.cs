﻿using Microsoft.AspNetCore.Mvc;
using SoundPlay.BLL.Exceptions;
using SoundPlay.BLL.Interfaces;
using SoundPlay.BLL.ViewModels;

namespace SoundPlay.WEB.Areas.Admin.Controllers
{
    [Area("Admin")]
    public sealed class PickupSetController : Controller
    {
		private readonly IItemGenericService<PickupSetViewModel> _pickupSetService;
		private readonly ILoggerAdapter<PickupSetController> _logger;

		public PickupSetController(
			IItemGenericService<PickupSetViewModel> brandService,
			ILoggerAdapter<PickupSetController> logger)
		{
			_pickupSetService = brandService;
			_logger = logger;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			try
			{
				var viewModels = await _pickupSetService.GetViewModelsAsync();
				return View(viewModels);
			}

			catch (ObjectNotFoundException ex)
			{
				_logger!.LogError(ex.Message);
				return NotFound(ex.Message);
			}

			catch (Exception ex)
			{
				_logger!.LogError(ex.Message);
				return BadRequest(ex.Message);
			}
		}


		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(PickupSetViewModel obj)
		{
			try
			{
				if (ModelState.IsValid)
				{
					await _pickupSetService.CreateViewModelAsync(obj);
					return RedirectToAction("Index");
				}
				else return View(obj);
			}

			catch (Exception ex)
			{
				_logger!.LogError(ex.Message);
				return BadRequest(ex.Message);
			}
		}

		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
			try
			{
				var viewModel = await _pickupSetService.GetViewModelByIdAsync(id);
				return View(viewModel);
			}

			catch (ObjectNotFoundException ex)
			{
				_logger!.LogError(ex.Message);
				return NotFound(ex.Message);
			}

			catch (Exception ex)
			{
				_logger!.LogError(ex.Message);
				return BadRequest(ex.Message);
			}
		}

		[HttpPost]
		public async Task<IActionResult> Edit(PickupSetViewModel obj)
		{
			try
			{
				if (ModelState.IsValid)
				{
					await _pickupSetService.UpdateViewModelAsync(obj);
					return RedirectToAction("Index");
				}
				return View(obj);
			}

			catch (Exception ex)
			{
				_logger!.LogError(ex.Message);
				return BadRequest(ex.Message);
			}
		}


		[HttpPost]
		public async Task<IActionResult> Delete(int id)
		{
			try
			{
				var viewModel = await _pickupSetService.GetViewModelByIdAsync(id);
				await _pickupSetService.DeleteViewModelAsync(viewModel);
				return RedirectToAction("Index");
			}

			catch (ObjectNotFoundException ex)
			{
				_logger!.LogError(ex.Message);
				return NotFound(ex.Message);
			}

			catch (Exception ex)
			{
				_logger!.LogError(ex.Message);
				return BadRequest(ex.Message);
			}
		}
	}
}
