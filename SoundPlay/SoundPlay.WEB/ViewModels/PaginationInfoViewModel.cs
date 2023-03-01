﻿namespace SoundPlay.Web.ViewModels;

public sealed class PaginationInfoViewModel
{
    public int PageIndex { get; set; }
    public int TotalPages { get; set; }
    public int ItemsPerPage { get; set; }
    public int TotalItems { get; set; }
    public bool HasPreviousPage { get; set; }
    public bool HasNextPage { get; set; }
}
