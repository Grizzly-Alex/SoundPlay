namespace SoundPlay.BLL.Interfaces;

public interface IRepresentationService
{
	public Task<IEnumerable<SelectListItem>> GetSelectListAsync<TItem>() where TItem : Item;
    public Task<IEnumerable<SelectListItem>> GetSelectListAsync<TItem>(SelectListItem selectList, int indexInsert = 0) where TItem : Item;
}
