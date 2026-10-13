using Godot;
using System;
using trash.scripts.units;

public partial class Weapon : Node2D
{
	[Export] public WeaponResource Resource;
	[Export] public Sprite2D Texture;
	
	public override void _Ready()
	{
		

		if (Resource != null)
		{
			SetWeapon(resource:Resource);
		}
		
		
	}

	public void SetWeapon(WeaponResource resource)
	{
		Resource = resource;
		
		Texture.Texture = Resource.WeaponTexture;

		if (GetParent() is not Unit unit) return;
		if (!IsConnected(Unit.SignalName.OnShoot, new Callable(this, MethodName.OnShoot)))
			unit.OnShoot += OnShoot;
	}

	private void OnShoot(float angle, Vector2 position)
	{
		Resource.SpawnBullet(GetTree().Root.GetChild(0), position, angle);
	}
}
