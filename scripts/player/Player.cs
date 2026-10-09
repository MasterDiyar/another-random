using Godot;
using System;
using trash.scripts.resource;

namespace trash.scripts.units;

public partial class Player : Unit
{
    [Export] public UnitStats BaseStats { get; set; }

    public UnitStatsInstance Stats { get; private set; }

    public override void _Ready()
    {
        base._Ready();

        if (BaseStats != null)
        {
            Stats = new UnitStatsInstance(BaseStats);
        }
    }

    public override void _PhysicsProcess(double delta)
    {
        Vector2 direction = Input.GetVector("a","d","w","s");

        float currentSpeed = Stats?.Speed ?? 300.0f;

        if (direction != Vector2.Zero)
        {
            Velocity = direction * currentSpeed;
        }
        else
        {
            Velocity = Velocity.MoveToward(Vector2.Zero, currentSpeed);
        }

        MoveAndSlide();
    }
}