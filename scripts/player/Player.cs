using Godot;
using System;
using trash.scripts.resource;

namespace trash.scripts.units;

public partial class Player : Unit
{
    [Export] private Camera2D camera;
    [Export] private Weapon weapon;
    public override void _PhysicsProcess(double delta)
    {
        Vector2 direction = Input.GetVector("a","d","w","s");

        float currentSpeed = Stats?.Speed ?? 300.0f;
        if (direction != Vector2.Zero) {
            Velocity = direction * currentSpeed;
        }else {
            Velocity = Velocity.MoveToward(Vector2.Zero, currentSpeed);
        }

        if (Input.IsActionPressed("lm")) {
            var angle = (-GetGlobalPosition() + GetGlobalMousePosition()).Angle();
            EmitSignalOnShoot(angle, GetGlobalPosition(), this);
        }

        MoveAndSlide();
    }

    public void CameraShake(float strength)
    {
        Tween tween = CreateTween();
        
        tween.TweenProperty(camera, "offset", new Vector2(9,0), 0.2);
                
    }

    public void SetWeapon(WeaponResource resource)
    {
        weapon.SetWeapon(resource);
    }
}