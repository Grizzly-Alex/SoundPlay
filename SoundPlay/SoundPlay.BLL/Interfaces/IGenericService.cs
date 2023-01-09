namespace SoundPlay.BLL.Interfaces
{
    public interface IGenericService<TViewModel> where TViewModel : class
    {
        public Task<IEnumerable<TViewModel>> GetMeetupsAsync();

        public Task<TViewModel> GetMeetupByIdAsync(int id);

        public Task<TViewModel> CreateMeetupAsync(TViewModel viewModel);

        public Task<TViewModel> UpdateMeetupAsync(TViewModel viewModel);

        public Task<TViewModel> DeleteMeetupAsync(TViewModel viewModel);
    }
}