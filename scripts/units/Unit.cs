using Godot;
using trash.scripts.item;
using trash.scripts.resource;

namespace trash.scripts.units;

public partial class Unit : CharacterBody2D
{
    [Export] public UnitStats BaseStats { get; set; }
    [Export] public Inventory Inventory { get; set; }
    public float MoveMultiplier=1, AdrenalineMultiplier=1; 

    public UnitStatsInstance Stats { get; private set; }

    public override void _Ready()
    {
        base._Ready();

        if (BaseStats != null)
        {
            Stats = new UnitStatsInstance(BaseStats);
        }

        if (Inventory == null)
        {
            Inventory = new Inventory();
        }
    }
    
    [Signal] public delegate void OnShootEventHandler(float angle, Vector2 position, Unit unit);
    [Signal] public delegate void OnDamagedEventHandler(float damage);

    public virtual void TakeDamage(float damage)
    {
        DamageNumPool.Instance.SetDamage(GlobalPosition, damage);
        EmitSignalOnDamaged(damage);
    }

    public void DropItemOnDeath()
    {
        
    }
}