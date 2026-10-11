using Godot;
using System;

public partial class Weapon : Node2D
{
	[Export] public WeaponResource Resource;
	[Export] public Sprite2D Texture;
	
	public override void _Ready()
	{
		

		if (Resource != null)
		{
			
		}
	}

	public void SetWeapon(WeaponResource resource)
	{
		Resource = resource;
		
		
	}
}
