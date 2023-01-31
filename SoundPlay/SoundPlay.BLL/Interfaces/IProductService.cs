namespace SoundPlay.BLL.Interfaces;

public interface IProductService<TViewModel> where TViewModel : ProductViewModel
{
    public Task<IEnumerable<TViewModel>> GetViewModelsAsync();
    public Task<TViewModel> GetViewModelByIdAsync(int id);
    public Task<TViewModel> CreateViewModelAsync(TViewModel viewModel);
    public Task<TViewModel> UpdateViewModelAsync(TViewModel viewModel);
    public Task<TViewModel> DeleteViewModelAsync(TViewModel viewModel);
}