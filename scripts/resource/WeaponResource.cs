
using Godot;
using trash.scripts.weapons;

[GlobalClass]
public partial class WeaponResource : Resource
{
    [Export] public BulletResource Resource;
    [Export] public Texture2D WeaponTexture; 
    
    [Export] public float Damage;
    [Export] public float AttackSpeed;

    public virtual void SpawnBullet(Node SpawnNode, Vector2 SpawnPosition, float Rotation)
    {
        var bullet = Resource.BulletScene.Instantiate<Bullet>();
        bullet.SetResource(Resource, Damage);
        bullet.Position = SpawnPosition;
        bullet.Rotation = Rotation;
        SpawnNode.AddChild(bullet);
    }
}