
using Godot;

[GlobalClass]
public partial class WeaponResource : Resource
{
    [Export] public BulletResource Resource;
    
    [Export] public float Damage;
    [Export] public float AttackSpeed;

    public void SpawnBullet(Node SpawnNode, Vector2 SpawnPosition, float Rotation)
    {
        var bullet = Resource.BulletScene.Instantiate();
    }
}