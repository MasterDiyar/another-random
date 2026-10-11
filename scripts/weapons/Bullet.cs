using Godot;

namespace trash.scripts.weapons;

public partial class Bullet : Area2D
{
    [Export] public BulletResource Resource;
    private float Damage, Speed;
    
    
    public void SetResource(BulletResource resource, float damage)
    {
        Resource = resource;

        Speed += Resource.Speed;
    }
}