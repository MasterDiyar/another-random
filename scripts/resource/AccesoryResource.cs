using Godot;
using trash.scripts.resource;
using trash.scripts.units;

[GlobalClass]
public partial class AccesoryResource : Resource, IResourceInit<AccesoryResource>
{
    [Export] public UnitStats AccesoryStats;

    public virtual AccesoryResource Copy()
    {
        return (AccesoryResource) MemberwiseClone();
    }

    public virtual void OnAttack(float angle, Unit unit)
    {
        
    }
}