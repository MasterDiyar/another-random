
using Godot;
using trash.scripts.units;
using trash.scripts.weapons;

[GlobalClass]
public partial class WeaponResource : Resource
{
    [Export] public WeaponType Type = WeaponType.Sword;
    
    [Export] public BulletResource Resource;
    [Export] public Texture2D WeaponTexture;
    
    [Export] public float SpawnOffset;
    [Export] public float Damage;
    [Export] public float AttackSpeed;

    public virtual void SpawnBullet(Node SpawnNode, Vector2 SpawnPosition, float Rotation, Unit Parent)
    {
        var bullet = Resource.BulletScene.Instantiate<Bullet>();
        bullet.SetResource(Resource, Damage*Parent.MoveMultiplier*Parent.AdrenalineMultiplier*GetDamageFromType(Parent, Type));
        bullet.Position = SpawnPosition + Vector2.FromAngle(Rotation) * SpawnOffset;
        bullet.Rotation = Rotation;
        bullet.Parent =  Parent;
        SpawnNode.AddChild(bullet);
    }

    public static float GetDamageFromType(Unit unit, WeaponType type)
    {
        float mult = type switch
        {
            WeaponType.Sword => unit.Stats.Strength 
                * 0.15f + unit.Stats.MaxHp 
                * 0.17f + unit.Stats.Agility 
                * 0.05f,
    
            WeaponType.Axe => unit.Stats.Strength 
                * 0.3f + unit.Stats.MaxHp 
                * 0.1f,
    
            WeaponType.Pike => unit.Stats.Strength 
                * 0.22f + unit.Stats.MaxShield 
                * 0.4f,
    
            WeaponType.Bow => unit.Stats.Strength 
                * 0.076f + unit.Stats.Agility 
                * 0.18f + unit.Stats.MaxEnergy 
                * 0.1f,
    
            WeaponType.Thrown => unit.Stats.Strength 
                * 0.26f + unit.Stats.Agility 
                * 0.18f,
    
            WeaponType.Muscet => unit.Stats.Agility  
                * 0.3f + unit.Stats.MaxEnergy 
                * 0.045f,
    
            WeaponType.Wand => unit.Stats.Intelligence 
                * 0.22f + unit.Stats.MaxMp 
                * 0.17f,
    
            WeaponType.Oculus => unit.Stats.Intelligence 
                * 0.12f + unit.Stats.MaxMp 
                * 0.34f + unit.Stats.MaxEnergy 
                * 0.084f,
    
            WeaponType.Aura => unit.Stats.Intelligence 
                * 0.38f + unit.Stats.MaxMp 
                * 0.10f + unit.Stats.MaxEnergy 
                * 0.176f + unit.Stats.MaxArmor 
                * 0.1f
        };
        
        return mult;
    }
}