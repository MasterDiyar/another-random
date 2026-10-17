using Godot;
using System;
using trash.scripts.resource;

namespace trash.scripts.units;

public partial class Player : Unit
{

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
}