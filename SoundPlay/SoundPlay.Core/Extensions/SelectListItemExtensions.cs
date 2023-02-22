namespace SoundPlay.Core.Extensions;

public static class SelectListItemExtensions
{
    public static readonly SelectListItem DefaultSelectListItem = new() { Text = "All", Value = null, Selected = true };
    public static IList<SelectListItem> ToSelectListItems<TItem>(this IList<TItem> items)
        where TItem : Item
    {
        return items.Select(i => new SelectListItem { Value = i.Id.ToString(), Text = i.Name }).ToList();
    }
}
