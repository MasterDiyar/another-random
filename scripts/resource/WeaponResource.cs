
using Godot;
using trash.scripts.units;
using trash.scripts.weapons;

[GlobalClass]
public partial class WeaponResource : Resource
{
    [Export] public BulletResource Resource;
    [Export] public Texture2D WeaponTexture;
    
    [Export] public float SpawnOffset;
    [Export] public float Damage;
    [Export] public float AttackSpeed;

    public virtual void SpawnBullet(Node SpawnNode, Vector2 SpawnPosition, float Rotation, Unit Parent)
    {
        var bullet = Resource.BulletScene.Instantiate<Bullet>();
        bullet.SetResource(Resource, Damage);
        bullet.Position = SpawnPosition + Vector2.FromAngle(Rotation) * SpawnOffset;
        bullet.Rotation = Rotation;
        bullet.Parent =  Parent;
        SpawnNode.AddChild(bullet);
    }
}