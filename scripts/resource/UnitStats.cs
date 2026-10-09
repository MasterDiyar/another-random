
using Godot;

[GlobalClass]
public partial class UnitStats : Resource
{
    [Export] public float Speed;
    [Export] public float MaxHp;
    [Export] public float MaxMp;
    [Export] public float MaxEnergy;
    [Export] public float MaxArmor; //true damage absorption
    [Export] public float MaxShield; //percentage damage absorption
    [Export] public float Strength;
    [Export] public float Agility;
    [Export] public float Intelligence;
    
    
}