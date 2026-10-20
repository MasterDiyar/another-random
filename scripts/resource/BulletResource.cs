using Godot;
using trash.scripts.resource;
using trash.scripts.weapons;

[GlobalClass]
public partial class BulletResource : Resource, IResourceInit<BulletResource>
{
    [Export] public PackedScene BulletScene;
    [Export] public BulletResource Resource;
    [Export] public Texture2D Texture;
    [Export] public Shape2D Shape;
    [Export] public float Speed;
    [Export] public float LifeTime;
    [Export] public float Pierce;
    [Export] public float Acceleration;

    public virtual void OnSpawn(Bullet bullet)
    {
        Resource?.OnSpawn(bullet);
    }
    
    public virtual void OnDieSpawn()
    {
        Resource?.OnDieSpawn();
    }

    /// <summary>
    /// lifetime is how much time left to free bullet
    /// </summary>
    /// <param name="lifetime"></param>
    public virtual void PerFlight(float lifetime, ref Bullet bullet)
    {
        Resource?.PerFlight(lifetime, ref bullet);
    }
    
    public virtual BulletResource Copy() 
    {
        return (BulletResource) MemberwiseClone();
    }
}