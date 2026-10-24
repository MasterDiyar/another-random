
using Godot;
using trash.scripts.units;

[GlobalClass]
public partial class AttackingCrown : AccesoryResource
{
    [Export] public WeaponResource weapon;

    public override AttackingCrown Copy()
    {
        weapon = weapon.Copy();
        return (AttackingCrown) MemberwiseClone();
    }

    public override void OnAttack(float angle, Unit unit)
    {
        
    }
}