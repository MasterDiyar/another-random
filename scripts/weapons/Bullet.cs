using Godot;
using trash.scripts.units;

namespace trash.scripts.weapons;

public partial class Bullet : Area2D
{
    [Export] public BulletResource Resource;
    private float Damage, Speed, LifeTime = 1;
    
    public void SetResource(BulletResource resource, float damage)
    {
        Resource = resource;

        Speed += Resource.Speed;
        Resource.OnSpawn();
    }

    public override void _Ready()
    {
        BodyEntered += OnBodyEntered;
    }

    public override void _Process(double delta)
    {
        float dt =  (float)delta;
        Position += Speed * dt * Vector2.FromAngle(Rotation);
        LifeTime -= dt;
        Resource.PerFlight(LifeTime);
        if (LifeTime <= 0)
            QueueFree();
    }

    private void OnBodyEntered(Node2D body)
    {
        if (body is Unit target)
        {
            target.TakeDamage(Damage);
        }
    }

    public virtual void OnDie()
    {
        Resource.OnDieSpawn();
        QueueFree();
    }
}