using Godot;

namespace trash.scripts.units;

public partial class Unit : CharacterBody2D
{
    
    
    [Signal] public delegate void OnShootEventHandler(float angle, Vector2 position);
    [Signal] public delegate void OnDamagedEventHandler(float damage);

    public virtual void TakeDamage(float damage)
    {
        
        EmitSignalOnDamaged(damage);
    }
}