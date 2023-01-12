namespace SoundPlay.BLL.Interfaces
{
    public interface IItemGenericService<TViewModel> where TViewModel : class
    {
        public Task<IEnumerable<TViewModel>> GetViewModelsAsync();
        public Task<TViewModel> GetViewModelByIdAsync(int id);
        public Task<TViewModel> CreateViewModelAsync(TViewModel viewModel);
        public Task<TViewModel> UpdateViewModelAsync(TViewModel viewModel);
        public Task<TViewModel> DeleteViewModelAsync(TViewModel viewModel);
    }
}