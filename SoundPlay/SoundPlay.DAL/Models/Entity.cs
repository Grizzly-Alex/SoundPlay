﻿namespace SoundPlay.DAL.Models;

public abstract class Entity
{
	[Key] public int Id { get; set; }
	public string Name { get;set; }
}
