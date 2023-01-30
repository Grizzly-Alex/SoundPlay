﻿namespace SoundPlay.BLL.ViewModels.Admin;

public sealed class GuitarShapeViewModel
{
    public int Id { get; set; }

    [DisplayName("Guitar shape")]
	[Required(ErrorMessage = "This field must not be empty!")]
	public string Name { get; set; }
}