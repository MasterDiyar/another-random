using Godot;

[GlobalClass]
public partial class BulletResource : Resource
{
    [Export] public PackedScene BulletScene;
    [Export] public float Speed;
    [Export] public float LifeTime;
    [Export] public float Pierce;

    public virtual void OnSpawn()
    {
        
    }
    
    public virtual void OnDieSpawn()
    {
    }

    /// <summary>
    /// lifetime is how much time left to free bullet
    /// </summary>
    /// <param name="lifetime"></param>
    public virtual void PerFlight(float lifetime)
    {
        
    }
}