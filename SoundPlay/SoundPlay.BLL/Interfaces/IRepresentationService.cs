namespace SoundPlay.BLL.Interfaces;

public interface IRepresentationService
{
	public Task<IEnumerable<SelectListItem>> GetSelectListAsync<TEntity>() where TEntity : Entity;
}
