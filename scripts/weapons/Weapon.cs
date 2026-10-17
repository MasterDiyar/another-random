using Godot;
using System;
using trash.scripts.units;

public partial class Weapon : Node2D
{
	[Export] public WeaponResource Resource;
	[Export] public Sprite2D Texture;

	protected bool CanShoot = true;
	private double between = 0;
	
	public override void _Ready()
	{
		if (Resource != null) {
			SetWeapon(resource:Resource);
		}
	}

	public override void _Process(double delta)
	{
		LookAt(GetGlobalMousePosition());
		if (CanShoot) return;
		between -= delta;
		if (between <= 0) CanShoot = true;
	}

	public void SetWeapon(WeaponResource resource)
	{
		Resource = resource;
		Texture.Texture = Resource.WeaponTexture;

		if (GetParent() is not Unit unit) return;
		var shootCallable = new Callable(this, MethodName.OnShoot);
		if (!unit.IsConnected(Unit.SignalName.OnShoot, shootCallable))
			unit.OnShoot += OnShoot;
		
	}

	protected virtual void OnShoot(float angle, Vector2 position, Unit shooter)
	{
		if (!CanShoot)  return;
		CanShoot = false;
		between = Resource.AttackSpeed;
		Resource.SpawnBullet(GetTree().Root.GetChild(0), position, angle, shooter);
	}
}
