
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
            WeaponType.Sword =>  unit.BaseStats.Strength * 0.15f  + unit.BaseStats.MaxHp * 0.17f+ unit.BaseStats.Agility * 0.05f,
            WeaponType.Axe =>    unit.BaseStats.Strength * 0.3f   + unit.BaseStats.MaxHp * 0.1f,
            WeaponType.Pike =>   unit.BaseStats.Strength * 0.22f  + unit.BaseStats.MaxShield * 0.4f,
            WeaponType.Bow =>    unit.BaseStats.Strength * 0.076f + unit.BaseStats.Agility * .18f + unit.BaseStats.MaxEnergy * 0.1f,
            WeaponType.Thrown => unit.BaseStats.Strength * 0.26f  + unit.BaseStats.Agility * .18f,
            WeaponType.Muscet => unit.BaseStats.Agility  * 0.3f   + unit.BaseStats.MaxEnergy * .045f,
            WeaponType.Wand =>   unit.BaseStats.Intelligence * .22f + unit.BaseStats.MaxMp * .17f,
            WeaponType.Oculus => unit.BaseStats.Intelligence * .12f + unit.BaseStats.MaxMp * .34f + unit.BaseStats.MaxEnergy * .084f,
            WeaponType.Aura =>   unit.BaseStats.Intelligence * .38f + unit.BaseStats.MaxMp * .10f + unit.BaseStats.MaxEnergy * .176f + unit.BaseStats.MaxArmor * .1f
        };
        
        return mult;
    }
}