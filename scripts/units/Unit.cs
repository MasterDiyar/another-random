using Godot;
using trash.scripts.resource;

namespace trash.scripts.units;

public partial class Unit : CharacterBody2D
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
    
    [Signal] public delegate void OnShootEventHandler(float angle, Vector2 position);
    [Signal] public delegate void OnDamagedEventHandler(float damage);

    public virtual void TakeDamage(float damage)
    {
        DamageNumPool.Instance.SetDamage(GlobalPosition, damage);
        EmitSignalOnDamaged(damage);
    }
}