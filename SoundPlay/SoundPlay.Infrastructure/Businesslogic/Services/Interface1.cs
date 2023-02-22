namespace SoundPlay.Infrastructure.BusinessLogic.Services;

public interface IFilterService<TFilterModel, TProductModel>
    where TProductModel : class
    where TFilterModel : class
{
    public Task<TFilterModel> GetFilterModelAsync(IEnumerable<TProductModel> catalogProducts, TFilterModel filter);
}
