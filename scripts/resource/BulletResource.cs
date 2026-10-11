using Godot;

[GlobalClass]
public partial class BulletResource : Resource
{
    [Export] public PackedScene BulletScene;
    [Export] public float Speed;

    public virtual void OnSpawn()
    {
        
    }
    
    public virtual void OnDieSpawn()
    {
    }

    public virtual void PerFlight(float lifetime)
    {
        
    }
}